# RabbitMQ.Factory

## 内部采用多线程对象服用技术已优化连接的开启释放，保证你的每个action获取到的RabbitMQContext对象关联的RabbitMQ的连接和信道对象都是线程唯一的

``` c#
//注册RabbitMQ上下文到IOC容器中
services.AddRabbitMQFactory(b =>
{
    b.AddConnectionFactory("test", a =>
                {
//表示同一个时刻该app只能保存10个连接，采用线程共用(每次获取连接采用轮换方式，多线程共用意味着多个线程的连接可能是相同的)
                    a.ConnectionMaxCount = 10;
//表示同一个连接所能关联的信道个数，采用多线程复用（同一个连接只能在一个线程中使用，但是用完之后返回池，等待下一次获取），如果线程被阻塞导致池中的
信道不够用则自动重新创建，待最终返回时，多出的部分直接释放，而不是返回池中
                    a.PerConnectionChannelMaxCount = 1;
                    a.ConnectionFactory = new ConnectionFactory()
                    {
                        HostName = "47.95.214.86",
                        VirtualHost = "dev",
                        UserName = "test",
                        Password = "1024"
                    };
                });
    b.AddConnectionFactory("test2", a =>
                {
                    a.ConnectionMaxCount = 1;
                    a.PerConnectionChannelMaxCount = 10;
                    a.ConnectionFactory = new ConnectionFactory()
                    {
                        HostName = "47.95.214.86",
                        VirtualHost = "dev",
                        UserName = "test",
                        Password = "1024"
                    };
                });
})
.AddRabbitMQContext("test")//注册默认的RabbitMQ上下文，通过IRabbitMQContext获取
.AddRabbitMQContext<MyRabbitMQContext>("test2");//注册之定义的RabbitMQContext，以实现一个application访问多个RabbitMQ实例

```

### 获取RabbitMQContext

``` C#
[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    private readonly ILogger<ValuesController> _logger;
    private readonly IRabbitMQContext _context;

    public ValuesController(ILogger<ValuesController> logger, MyRabbitMQContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public string Get()
    {
        _context.Channel
            .BasicPublish("", "hello", false, null, Encoding.UTF8.GetBytes("rabbitmq"));
        return "success";
    }
}

```
