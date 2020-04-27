using RabbitMQ.Factory.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public class RabbitMQFactoryBuilder
    {
        internal RabbitMQFactoryBuilder()
        {

        }

        internal Dictionary<string, ConnectionFactoryOptions> ConnectionFactorys
            = new Dictionary<string, ConnectionFactoryOptions>();

        /// <summary>
        /// 添加连接工厂
        /// </summary>
        /// <param name="clientProvidedName">同一个RabbitMQFactory实例中必须唯一</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool AddConnectionFactory(string clientProvidedName, Action<ConnectionFactoryOptions> action)
        {
            if (ConnectionFactorys.ContainsKey(clientProvidedName))
            {
                return false;
            }
            var options = new ConnectionFactoryOptions();
            action(options);
            ConnectionFactorys.Add(clientProvidedName, options);
            return true;
        }
    }
}
