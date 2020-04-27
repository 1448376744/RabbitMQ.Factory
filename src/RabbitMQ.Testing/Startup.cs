using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Factory;
using RabbitMQ.Factory.Extensions;

namespace RabbitMQ.Testing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRabbitMQFactory(b =>
            {
                b.AddConnectionFactory("test", a =>
                {
                    a.ConnectionMaxCount = 2;
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
                    a.ConnectionMaxCount = 2;
                    a.ConnectionFactory = new ConnectionFactory()
                    {
                        HostName = "47.95.214.86",
                        VirtualHost = "dev",
                        UserName = "test",
                        Password = "1024"
                    };
                });
            })
            .AddRabbitMQContext("test")
            .AddRabbitMQContext<MyRabbitMQContext>("test2");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
