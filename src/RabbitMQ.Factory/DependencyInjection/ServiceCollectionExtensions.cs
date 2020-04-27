using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static RabbitMQBuilder AddRabbitMQFactory(this IServiceCollection services, Action<RabbitMQFactoryBuilder> action)
        {
            var factory = RabbitMQFactory.Create(action);
            services.AddSingleton(RabbitMQFactory.Create(action));
            return new RabbitMQBuilder(services, factory);
        }
    }
}

