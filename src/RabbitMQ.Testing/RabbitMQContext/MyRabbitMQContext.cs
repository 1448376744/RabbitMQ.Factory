using RabbitMQ.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Testing
{
    public class MyRabbitMQContext : RabbitMQContext
    {
        public MyRabbitMQContext(RabbitMQContextBuilder builder)
            :base(builder)
        {

        }
    }
}
