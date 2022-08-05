using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AirlineManagementService.MQListener
{
    public class RabbitListener : IHostedService
    {

        private readonly IConnection connection;
        private readonly IModel channel;


        public RabbitListener(IConfiguration configuration)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    // This is my side of the configuration, you can use it yourself.
                    Uri = new Uri(configuration["rabbitmqUrl"])
                };
                this.connection = factory.CreateConnection();
                this.channel = connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RabbitListener init error,ex:{ex.Message}");
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            return Task.CompletedTask;
        }





        
        protected string QueueName;

        // Method of handling messages
        public virtual bool Process(string message)
        {
            throw new NotImplementedException();
        }

        // Registered Consumer Monitor Here
        public void Register()
        {
            if (connection != null)
            {
                channel.QueueDeclare(QueueName,
                   durable: true,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    var result = Process(message);
                    if (result)
                    {
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };
                channel.BasicConsume(queue: QueueName, consumer: consumer);
            }
        }

        public void DeRegister()
        {
            this.connection.Close();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.connection.Close();
            return Task.CompletedTask;
        }
    }
}
