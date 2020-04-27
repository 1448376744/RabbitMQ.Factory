using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public class RabbitMQContextBuilder
    {
        public IConnection Connection { get; set; }

        public IModel Channel { get; set; }
    }
}
