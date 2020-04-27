using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public interface IRabbitMQContext:IDisposable
    {
        IConnection Connection { get; }
        IModel Channel { get; }
    }
}
