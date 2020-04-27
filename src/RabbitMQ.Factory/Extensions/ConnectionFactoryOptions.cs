using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    public class ConnectionFactoryOptions
    {
        internal ConnectionFactoryOptions()
        {

        }
        /// <summary>
        /// ConnectionFactory
        /// </summary>
        public IConnectionFactory ConnectionFactory { get; set; }
        /// <summary>
        /// 最大连接数，如果连接池中不存在连接则新建，否则从连接池返回(通过释放模式)，如果返回给连接池的连接超过ConnectionMaxCount则直接释放
        /// </summary>
        public int ConnectionMaxCount { get; set; } = 1;
        /// <summary>
        /// 每个连接的最大信道数，如果信道池中不存在信道则新建，否则从信道池返回(通过释放模式)，如果返回给信道池的信道超过ConnectionMaxCount则直接释放
        /// </summary>
        public int PerConnectionChannelMaxCount { get; set; } = 15;
    }
}
