using RabbitMQ.Client;
using RabbitMQ.Factory.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace RabbitMQ.Factory
{
    /// <summary>
    /// RabbitMQ缓存工厂,基于释放模式请不要执行Close来关闭连接或者信道
    /// </summary>
    public class RabbitMQFactory : IRabbitMQFactory
    {
        private bool _disposed = false;

        /// <summary>
        /// 连接命名
        /// </summary>
        private readonly Dictionary<string, ConnectionFactoryOptions> _factorys;           

        /// <summary>
        /// 连接缓存
        /// </summary>
        private readonly ConcurrentDictionary<string, ConcurrentQueue<Connection>> _connections
            = new ConcurrentDictionary<string, ConcurrentQueue<Connection>>();

        internal RabbitMQFactory(Dictionary<string, ConnectionFactoryOptions> factorys)
        {
            _factorys = factorys;
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        private Connection GetConnection(string clientProvidedName)
        {
            if (_factorys.TryGetValue(clientProvidedName, out ConnectionFactoryOptions options))
            {
                var connetions = _connections.GetOrAdd(clientProvidedName, f =>
                {
                    return new ConcurrentQueue<Connection>();
                });
                if (!connetions.TryDequeue(out Connection connection))
                {
                    connection = new Connection(options.ConnectionFactory.CreateConnection(clientProvidedName),
                        options.PerConnectionChannelMaxCount);
                    connection.OnReturnHandler += (c) =>
                    {
                        //如果高于最高配置，则直接释放，否则返还
                        if (options.ConnectionMaxCount <= connetions.Count)
                        {
                            c.Close();
                        }
                        else if(c.IsOpen)
                        {
                            connetions.Enqueue(c);
                        }
                    };
                }
                if (connection!=null)
                {
                    connection._disposed = false;
                }
                return connection;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取信道
        /// </summary>
        /// <param name="clientProvidedName"></param>
        /// <returns></returns>
        public IRabbitMQContext GetRabbitMQContext(string clientProvidedName)
        {
            var connection = GetConnection(clientProvidedName);
            var channel = connection.CreateModel();
            return new RabbitMQContext(new RabbitMQContextBuilder
            {
                Connection=connection,
                Channel=channel
            });
        }

        /// <summary>
        /// 创建RabbitMQFactory实例
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IRabbitMQFactory Create(Action<RabbitMQFactoryBuilder> action)
        {
            var builder = new RabbitMQFactoryBuilder();
            action(builder);
            return new RabbitMQFactory(builder.ConnectionFactorys);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                foreach (var item in _connections.Values)
                {
                    foreach (var iitem in item)
                    {
                        iitem.Close();
                    }
                }
            }
        }

    }
}
