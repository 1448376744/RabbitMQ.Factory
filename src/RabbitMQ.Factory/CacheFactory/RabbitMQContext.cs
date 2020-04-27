using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public class RabbitMQContext : IRabbitMQContext
    {
        public IConnection Connection { get; }

        public IModel Channel { get; }

        public RabbitMQContext(RabbitMQContextBuilder builder)
        {
            Connection = builder.Connection;
            Channel = builder.Channel;
        }

        public void Dispose()
        {
            Channel?.Dispose();
            Connection?.Dispose();
        }
    }
}
