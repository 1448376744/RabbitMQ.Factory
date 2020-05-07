using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public interface IRabbitMQContext : IModel
    {
        IConnection GetConnection();
    }
}
