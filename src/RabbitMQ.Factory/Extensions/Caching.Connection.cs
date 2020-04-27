﻿using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    internal partial class Connection
    {
        internal bool _disposed { get; set; }

        private readonly ConcurrentQueue<Model> _models
            = new ConcurrentQueue<Model>();

        private readonly int _perConnectionChannelCount;

        private readonly IConnection _connection;

        internal event Action<Connection> OnReturnHandler;

        public Connection(IConnection connection, int perConnectionChannelCount)
        {
            _connection = connection;
            _perConnectionChannelCount = perConnectionChannelCount;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                OnReturnHandler?.Invoke(this);
            }
        }

        public IModel CreateModel()
        {
            if (!_models.TryDequeue(out Model model))
            {
                model = new Model(_connection.CreateModel());
                model.OnReturnHandler += (m) =>
                {
                    if (_perConnectionChannelCount <= _models.Count)
                    {
                        m.Close();
                    }
                    else if (m.IsOpen)
                    {
                        _models.Enqueue(m);
                    }
                };
            }
            if (model!=null)
            {
                model._disposed = false;
            }
            return model;
        }

    }
}
