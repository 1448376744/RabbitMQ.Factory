﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Factory.Extensions
{
    internal partial class Model : IModel
    {
        public int ChannelNumber => _model.ChannelNumber;

        public ShutdownEventArgs CloseReason => _model.CloseReason;

        public IBasicConsumer DefaultConsumer { get => _model.DefaultConsumer; set => _model.DefaultConsumer = value; }

        public bool IsClosed => _model.IsClosed;

        public bool IsOpen => _model.IsOpen;

        public ulong NextPublishSeqNo => _model.NextPublishSeqNo;

        public TimeSpan ContinuationTimeout { get => _model.ContinuationTimeout; set => _model.ContinuationTimeout = value; }

        public event EventHandler<BasicAckEventArgs> BasicAcks
        {
            add
            {
                _model.BasicAcks += value;
            }

            remove
            {
                _model.BasicAcks -= value;
            }
        }

        public event EventHandler<BasicNackEventArgs> BasicNacks
        {
            add
            {
                _model.BasicNacks += value;
            }

            remove
            {
                _model.BasicNacks -= value;
            }
        }

        public event EventHandler<EventArgs> BasicRecoverOk
        {
            add
            {
                _model.BasicRecoverOk += value;
            }

            remove
            {
                _model.BasicRecoverOk -= value;
            }
        }

        public event EventHandler<BasicReturnEventArgs> BasicReturn
        {
            add
            {
                _model.BasicReturn += value;
            }

            remove
            {
                _model.BasicReturn -= value;
            }
        }

        public event EventHandler<CallbackExceptionEventArgs> CallbackException
        {
            add
            {
                _model.CallbackException += value;
            }

            remove
            {
                _model.CallbackException -= value;
            }
        }

        public event EventHandler<FlowControlEventArgs> FlowControl
        {
            add
            {
                _model.FlowControl += value;
            }

            remove
            {
                _model.FlowControl -= value;
            }
        }

        public event EventHandler<ShutdownEventArgs> ModelShutdown
        {
            add
            {
                _model.ModelShutdown += value;
            }

            remove
            {
                _model.ModelShutdown -= value;
            }
        }

        public void Abort()
        {
            _model.Abort();
        }

        public void Abort(ushort replyCode, string replyText)
        {
            _model.Abort(replyCode, replyText);
        }

        public void BasicAck(ulong deliveryTag, bool multiple)
        {
            _model.BasicAck(deliveryTag, multiple);
        }

        public void BasicCancel(string consumerTag)
        {
            _model.BasicCancel(consumerTag);
        }

        public void BasicCancelNoWait(string consumerTag)
        {
            _model.BasicCancelNoWait(consumerTag);
        }

        public string BasicConsume(string queue, bool autoAck, string consumerTag, bool noLocal, bool exclusive, IDictionary<string, object> arguments, IBasicConsumer consumer)
        {
            return _model.BasicConsume(queue, autoAck, consumerTag, noLocal, exclusive, arguments, consumer);
        }

        public BasicGetResult BasicGet(string queue, bool autoAck)
        {
            return _model.BasicGet(queue, autoAck);
        }

        public void BasicNack(ulong deliveryTag, bool multiple, bool requeue)
        {
            _model.BasicNack(deliveryTag, multiple, requeue);
        }

        public void BasicPublish(string exchange, string routingKey, bool mandatory, IBasicProperties basicProperties, ReadOnlyMemory<byte> body)
        {
            _model.BasicPublish(exchange, routingKey, mandatory, basicProperties, body);
        }

        public void BasicQos(uint prefetchSize, ushort prefetchCount, bool global)
        {
            _model.BasicQos(prefetchSize, prefetchCount, global);
        }

        public void BasicRecover(bool requeue)
        {
            _model.BasicRecover(requeue);
        }

        public void BasicRecoverAsync(bool requeue)
        {
            _model.BasicRecoverAsync(requeue);
        }

        public void BasicReject(ulong deliveryTag, bool requeue)
        {
            _model.BasicReject(deliveryTag, requeue);
        }

        public void Close()
        {
            _model.Close();
        }

        public void Close(ushort replyCode, string replyText)
        {
            _model.Close(replyCode, replyText);
        }

        public void ConfirmSelect()
        {
            _model.ConfirmSelect();
        }

        public uint ConsumerCount(string queue)
        {
            return _model.ConsumerCount(queue);
        }

        public IBasicProperties CreateBasicProperties()
        {
            return _model.CreateBasicProperties();
        }

        public IBasicPublishBatch CreateBasicPublishBatch()
        {
            return _model.CreateBasicPublishBatch();
        }

        public void ExchangeBind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _model.ExchangeBind(destination, source, routingKey, arguments);
        }

        public void ExchangeBindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _model.ExchangeBindNoWait(destination, source, routingKey, arguments);
        }

        public void ExchangeDeclare(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            _model.ExchangeDeclare(exchange, type, durable, autoDelete, arguments);
        }

        public void ExchangeDeclareNoWait(string exchange, string type, bool durable, bool autoDelete, IDictionary<string, object> arguments)
        {
            _model.ExchangeDeclareNoWait(exchange, type, durable, autoDelete, arguments);
        }

        public void ExchangeDeclarePassive(string exchange)
        {
            _model.ExchangeDeclarePassive(exchange);
        }

        public void ExchangeDelete(string exchange, bool ifUnused)
        {
            _model.ExchangeDelete(exchange, ifUnused);
        }

        public void ExchangeDeleteNoWait(string exchange, bool ifUnused)
        {
            _model.ExchangeDeleteNoWait(exchange, ifUnused);
        }

        public void ExchangeUnbind(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _model.ExchangeUnbind(destination, source, routingKey, arguments);
        }

        public void ExchangeUnbindNoWait(string destination, string source, string routingKey, IDictionary<string, object> arguments)
        {
            _model.ExchangeUnbindNoWait(destination, source, routingKey, arguments);
        }

        public uint MessageCount(string queue)
        {
            return _model.MessageCount(queue);
        }

        public void QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _model.QueueBind(queue, exchange, routingKey, arguments);
        }

        public void QueueBindNoWait(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _model.QueueBindNoWait(queue, exchange, routingKey, arguments);
        }

        public QueueDeclareOk QueueDeclare(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            return _model.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
        }

        public void QueueDeclareNoWait(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            _model.QueueDeclareNoWait(queue, durable, exclusive, autoDelete, arguments);
        }

        public QueueDeclareOk QueueDeclarePassive(string queue)
        {
            return _model.QueueDeclarePassive(queue);
        }

        public uint QueueDelete(string queue, bool ifUnused, bool ifEmpty)
        {
            return _model.QueueDelete(queue, ifUnused, ifEmpty);
        }

        public void QueueDeleteNoWait(string queue, bool ifUnused, bool ifEmpty)
        {
            _model.QueueDeleteNoWait(queue, ifUnused, ifEmpty);
        }

        public uint QueuePurge(string queue)
        {
            return _model.QueuePurge(queue);
        }

        public void QueueUnbind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            _model.QueueUnbind(queue, exchange, routingKey, arguments);
        }

        public void TxCommit()
        {
            _model.TxCommit();
        }

        public void TxRollback()
        {
            _model.TxRollback();
        }

        public void TxSelect()
        {
            _model.TxSelect();
        }

        public bool WaitForConfirms()
        {
            return _model.WaitForConfirms();
        }

        public bool WaitForConfirms(TimeSpan timeout)
        {
            return _model.WaitForConfirms(timeout);
        }

        public bool WaitForConfirms(TimeSpan timeout, out bool timedOut)
        {
            return _model.WaitForConfirms(timeout, out timedOut);
        }

        public void WaitForConfirmsOrDie()
        {
            _model.WaitForConfirmsOrDie();
        }

        public void WaitForConfirmsOrDie(TimeSpan timeout)
        {
            _model.WaitForConfirmsOrDie(timeout);
        }
    }
}
