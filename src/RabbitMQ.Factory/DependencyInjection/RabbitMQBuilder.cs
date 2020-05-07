using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RabbitMQ.Factory
{
    public class RabbitMQBuilder
    {
        private readonly IServiceCollection _services;

        private readonly IRabbitMQFactory _factory;

        public RabbitMQBuilder(IServiceCollection services, IRabbitMQFactory factory)
        {
            _services = services;
            _factory = factory;
        }

        /// <summary>
        /// 添加IRabbitMQContext类型的RabbitMQContext
        /// </summary>
        /// <param name="clientProvidedName"></param>
        /// <returns></returns>
        public RabbitMQBuilder AddRabbitMQContext(string clientProvidedName)
        {
            _services.AddScoped(s =>
            {
                return _factory.GetRabbitMQContext(clientProvidedName);
            });
            return this;
        }
        /// <summary>
        /// 添加TRabbitMQContext类型的RabbitMQContext
        /// </summary>
        /// <typeparam name="TRabbitMQContext"></typeparam>
        /// <param name="clientProvidedName"></param>
        /// <returns></returns>
        public RabbitMQBuilder AddRabbitMQContext<TRabbitMQContext>(string clientProvidedName)
            where TRabbitMQContext : RabbitMQContext
        {
            var p = Expression.Parameter(typeof(RabbitMQContextBuilder));
            var body = Expression.New(typeof(TRabbitMQContext)
                .GetConstructor(new Type[] { typeof(RabbitMQContextBuilder) }), p);
            var lambda = Expression.Lambda(body, p);
            var func = lambda.Compile() as Func<RabbitMQContextBuilder, TRabbitMQContext>;
            _services.AddScoped(s =>
            {
                var connection = _factory.GetConnection(clientProvidedName);
                var channel = connection.CreateModel();
                return func(new RabbitMQContextBuilder
                {
                    Connection = connection,
                    Channel = channel
                });
            });
            return this;
        }
    }
}
