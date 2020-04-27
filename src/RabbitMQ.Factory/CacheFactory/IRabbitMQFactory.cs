using RabbitMQ.Factory.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public interface IRabbitMQFactory : IDisposable
    {
        /// <summary>
        /// 获取信道
        /// </summary>
        /// <param name="clientProvidedName"></param>
        /// <returns></returns>
        IRabbitMQContext GetRabbitMQContext(string clientProvidedName);
    }
}
