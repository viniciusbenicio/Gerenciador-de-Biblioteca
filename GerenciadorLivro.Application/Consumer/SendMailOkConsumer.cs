using GerenciadorLivro.Core.IntegrationEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Consumer
{
    public class SendMailOkConsumer : BackgroundService
    {
        private const string SEND_MAIL_SUCESSS_QUEUE = "MailSendSucess";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public SendMailOkConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: SEND_MAIL_SUCESSS_QUEUE, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var sendMailApprovedBytes = eventArgs.Body.ToArray();
                var sendMailApprovedJson = Encoding.UTF8.GetString(sendMailApprovedBytes);

                var sendMailApprovedIntegrationEvent = JsonSerializer.Deserialize<SendMailOkIntegrationEvents>(sendMailApprovedJson);


                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(SEND_MAIL_SUCESSS_QUEUE, false, consumer);

            return Task.CompletedTask;
        }
        
    }
}
