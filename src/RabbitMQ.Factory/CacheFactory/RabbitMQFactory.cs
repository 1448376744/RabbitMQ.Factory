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
        /// 连接工厂
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
        /// <param name="clientProvidedName"></param>
        /// <returns></returns>
        public IConnection GetConnection(string clientProvidedName)
        {
            if (_factorys.TryGetValue(clientProvidedName, out ConnectionFactoryOptions options))
            {
                //初始化连接池
                var connections = _connections.GetOrAdd(clientProvidedName, f =>
                {
                    var queue = new ConcurrentQueue<Connection>();
                    for (int i = 0; i < options.ConnectionMaxCount; i++)
                    {
                        var conne = new Connection(
                            options.ConnectionFactory.CreateConnection(clientProvidedName),
                            options.PerConnectionChannelMaxCount);
                        queue.Enqueue(conne);
                    }
                    return queue;
                });
                connections.TryDequeue(out Connection connection);//出队列
                //如果已经被释放，或者获取不到
                if (connection == null || !connection.IsOpen)
                {
                    connection = new Connection(
                        options.ConnectionFactory.CreateConnection(clientProvidedName),
                        options.PerConnectionChannelMaxCount);
                }
                connections.Enqueue(connection);//重新排队
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
                Connection = connection,
                Channel = channel
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
