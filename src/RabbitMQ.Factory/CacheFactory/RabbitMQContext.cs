using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory
{
    public class RabbitMQContext : IRabbitMQContext
    {
        private readonly IModel _channel;
        
        private readonly IConnection _connection;

        public RabbitMQContext(RabbitMQContextBuilder builder)
        {
            _channel = builder.Channel;
            _connection = builder.Connection;
        }
       
        public IConnection GetConnection()
        {
            return _connection;
        }

        public int ChannelNumber => _channel.ChannelNumber;

        public ShutdownEventArgs CloseReason => _channel.CloseReason;

        public IBasicConsumer DefaultConsumer { get => _channel.DefaultConsumer; set => _channel.DefaultConsumer = value; }

        public bool IsClosed => _channel.IsClosed;

        public bool IsOpen => _channel.IsOpen;

        public ulong NextPublishSeqNo => _channel.NextPublishSeqNo;

        public TimeSpan ContinuationTimeout { get => _channel.ContinuationTimeout; set => _channel.ContinuationTimeout = value; }

        public event EventHandler<BasicAckEventArgs> BasicAcks
        {
            add
            {
                _channel.BasicAcks += value;
            }

            remove
            {
                _channel.BasicAcks -= value;
            }
        }

        public event EventHandler<BasicNackEventArgs> BasicNacks
        {
            add
            {
                _channel.BasicNacks += value;
            }

            remove
            {
                _channel.BasicNacks -= value;
            }
        }

        public event EventHandler<EventArgs> BasicRecoverOk
        {
            add
            {
                _channel.BasicRecoverOk += value;
            }

            remove
            {
                _channel.BasicRecoverOk -= value;
            }
        }

        public event EventHandler<BasicReturnEventArgs> BasicReturn
        {
            add
            {
                _channel.BasicReturn += value;
            }

            remove
            {
                _channel.BasicReturn -= value;
            }
        }

        public event EventHandler<CallbackExceptionEventArgs> CallbackException
        {
            add
            {
                _channel.CallbackException += value;
            }

            remove
            {
                _channel.CallbackException -= value;
            }
        }

        public event EventHandler<FlowControlEventArgs> FlowControl
        {
            add
            {
                _channel.FlowControl += value;
            }

            remove
            {
                _channel.FlowControl -= value;
            }
        }

        public event EventHandler<ShutdownEventArgs> ModelShutdown
        {
            add
            {
                _channel.ModelShutdown += value;
            }

            remove
            {
                _channel.ModelShutdown -= value;
            }
        }

        public void Abort()
        {
            _channel.Abort();
        }

        public void Abort(ushort replyCode, string replyText)
        {
            _channel.Abort(replyCode, replyText);
        }

        public void BasicAck(ulong deliveryTag, bool multiple)
        {
            _channel.BasicAck(deliveryTag, multiple);
        }

        public void BasicCancel(string consumerTag)
        {
            _channel.BasicCancel(consumerTag);
        }

        public void BasicCancelNoWait(string consumerTag)
        {
            _channel.BasicCancelNoWait(consumerTag);
        }

        public string BasicConsume(string queue, bool autoAck, string consumerTag, bool noLocal, bool exclusive, IDictionary<string, object> arguments, IBasicConsumer consumer)
        {
            return _channel.BasicConsume(queue, autoAck, consumerTag, noLocal, exclusive, arguments, consumer);
        }

        public BasicGetResult BasicGet(string queue, bool autoAck)
        {
            return _channel.BasicGet(queue, autoAck);
        }

        public void BasicNack(ulong deliveryTag, bool multiple, bool requeue)
        {
            _channel.BasicNack(deliveryTag, multiple, requeue);
        }

        public void BasicPublish(string exchange, string routingKey, bool mandatory, IBasicProperties basicProperties, ReadOnlyMemory<byte> body)
        {
            _channel.BasicPublish(exchange, routingKey, mandatory, basicProperties, body);
        }

        public void BasicQos(uint prefetchSize, ushort prefetchCount, bool global)
        {
            _channel.BasicQos(prefetchSize, prefetchCount, global);
        }

        public void BasicRecover(bool requeue)
        {
            _channel.BasicRecover(requeue);
        }

        public void BasicRecoverAsync(bool requeue)
        {
            _channel.BasicRecoverAsync(requeue);
        }

        public void BasicReject(ulong deliveryTag, bool requeue)
        {
            _channel.BasicReject(deliveryTag, requeue);
        }

        public void Close()
        {
            _channel.Close();
        }

        public void Close(ushort replyCode, string replyText)
        {
            _channel.Close(replyCode, replyText);
        }

        public void ConfirmSelect()
        {
            _channel.ConfirmSelect();
        }

        public uint ConsumerCount(string queue)
        {
            return _channel.ConsumerCount(queue);
        }

        public IBasicProperties CreateBasicProperties()
        {
            return _channel.CreateBasicProperties();
        }

        public IBasicPublishBatch CreateBasicPublishBatch()
        {
            return _channel.CreateBasicPublishBatch();
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        public void ExchangeBind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.ExchangeBind(destination, source, routingKey, arguments);
        }

        public void ExchangeBindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.ExchangeBindNoWait(destination, source, routingKey, arguments);
        }

        public void ExchangeDeclare(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            _channel.ExchangeDeclare(exchange, type, durable, autoDelete, arguments);
        }

        public void ExchangeDeclareNoWait(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            _channel.ExchangeDeclareNoWait(exchange, type, durable, autoDelete, arguments);
        }

        public void ExchangeDeclarePassive(string exchange)
        {
            _channel.ExchangeDeclarePassive(exchange);
        }

        public void ExchangeDelete(string exchange, bool ifUnused)
        {
            _channel.ExchangeDelete(exchange, ifUnused);
        }

        public void ExchangeDeleteNoWait(string exchange, bool ifUnused)
        {
            _channel.ExchangeDeleteNoWait(exchange, ifUnused);
        }

        public void ExchangeUnbind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.ExchangeUnbind(destination, source, routingKey, arguments);
        }

        public void ExchangeUnbindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.ExchangeUnbindNoWait(destination, source, routingKey, arguments);
        }

        public uint MessageCount(string queue)
        {
            return _channel.MessageCount(queue);
        }

        public void QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.QueueBind(queue, exchange, routingKey, arguments);
        }

        public void QueueBindNoWait(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.QueueBindNoWait(queue, exchange, routingKey, arguments);
        }

        public QueueDeclareOk QueueDeclare(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            return _channel.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
        }

        public void QueueDeclareNoWait(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            _channel.QueueDeclareNoWait(queue, durable, exclusive, autoDelete, arguments);
        }

        public QueueDeclareOk QueueDeclarePassive(string queue)
        {
            return _channel.QueueDeclarePassive(queue);
        }

        public uint QueueDelete(string queue, bool ifUnused, bool ifEmpty)
        {
            return _channel.QueueDelete(queue, ifUnused, ifEmpty);
        }

        public void QueueDeleteNoWait(string queue, bool ifUnused, bool ifEmpty)
        {
            _channel.QueueDeleteNoWait(queue, ifUnused, ifEmpty);
        }

        public uint QueuePurge(string queue)
        {
            return _channel.QueuePurge(queue);
        }

        public void QueueUnbind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _channel.QueueUnbind(queue, exchange, routingKey, arguments);
        }

        public void TxCommit()
        {
            _channel.TxCommit();
        }

        public void TxRollback()
        {
            _channel.TxRollback();
        }

        public void TxSelect()
        {
            _channel.TxSelect();
        }

        public bool WaitForConfirms()
        {
            return _channel.WaitForConfirms();
        }

        public bool WaitForConfirms(TimeSpan timeout)
        {
            return _channel.WaitForConfirms(timeout);
        }

        public bool WaitForConfirms(TimeSpan timeout, out bool timedOut)
        {
            return _channel.WaitForConfirms(timeout, out timedOut);
        }

        public void WaitForConfirmsOrDie()
        {
            _channel.WaitForConfirmsOrDie();
        }

        public void WaitForConfirmsOrDie(TimeSpan timeout)
        {
            _channel.WaitForConfirmsOrDie(timeout);
        }
    }
}
