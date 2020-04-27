using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    internal partial class Model : IModel
    {
        internal bool _disposed { get; set; }

        private readonly IModel _model;

        internal event Action<Model> OnReturnHandler;

        internal Model(IModel model)
        {
            _model = model;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                OnReturnHandler?.Invoke(this);
            }
        }
    }
}
