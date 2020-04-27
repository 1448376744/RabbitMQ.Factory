using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    internal partial class Connection : IConnection
    {
        public ushort ChannelMax => _connection.ChannelMax;

        public IDictionary<string, object> ClientProperties => _connection.ClientProperties;

        public ShutdownEventArgs CloseReason => _connection.CloseReason;

        public AmqpTcpEndpoint Endpoint => _connection.Endpoint;

        public uint FrameMax => _connection.FrameMax;

        public TimeSpan Heartbeat => _connection.Heartbeat;

        public bool IsOpen => _connection.IsOpen;

        public AmqpTcpEndpoint[] KnownHosts => _connection.KnownHosts;

        public IProtocol Protocol => _connection.Protocol;

        public IDictionary<string, object> ServerProperties => _connection.ServerProperties;

        public IList<ShutdownReportEntry> ShutdownReport => _connection.ShutdownReport;

        public string ClientProvidedName => _connection.ClientProvidedName;

        public int LocalPort => _connection.LocalPort;

        public int RemotePort => _connection.RemotePort;

        public event EventHandler<CallbackExceptionEventArgs> CallbackException
        {
            add
            {
                _connection.CallbackException += value;
            }

            remove
            {
                _connection.CallbackException -= value;
            }
        }

        public event EventHandler<ConnectionBlockedEventArgs> ConnectionBlocked
        {
            add
            {
                _connection.ConnectionBlocked += value;
            }

            remove
            {
                _connection.ConnectionBlocked -= value;
            }
        }

        public event EventHandler<ShutdownEventArgs> ConnectionShutdown
        {
            add
            {
                _connection.ConnectionShutdown += value;
            }

            remove
            {
                _connection.ConnectionShutdown -= value;
            }
        }

        public event EventHandler<EventArgs> ConnectionUnblocked
        {
            add
            {
                _connection.ConnectionUnblocked += value;
            }

            remove
            {
                _connection.ConnectionUnblocked -= value;
            }
        }

        public void Abort()
        {
            _connection.Abort();
        }

        public void Abort(ushort reasonCode, string reasonText)
        {
            _connection.Abort(reasonCode, reasonText);
        }

        public void Abort(TimeSpan timeout)
        {
            _connection.Abort(timeout);
        }

        public void Abort(ushort reasonCode, string reasonText, TimeSpan timeout)
        {
            _connection.Abort(reasonCode, reasonText, timeout);
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Close(ushort reasonCode, string reasonText)
        {
            _connection.Close(reasonCode, reasonText);
        }

        public void Close(TimeSpan timeout)
        {
            _connection.Close(timeout);
        }

        public void Close(ushort reasonCode, string reasonText, TimeSpan timeout)
        {
            _connection.Close(reasonCode, reasonText, timeout);
        }  

        public void HandleConnectionBlocked(string reason)
        {
            _connection.HandleConnectionBlocked(reason);
        }

        public void HandleConnectionUnblocked()
        {
            _connection.HandleConnectionUnblocked();
        }

        public void UpdateSecret(string newSecret, string reason)
        {
            _connection.UpdateSecret(newSecret, reason);
        }
    }
}
