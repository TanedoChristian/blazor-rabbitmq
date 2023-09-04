using RabbitMQ.Client;
using System.Text;

namespace BlazorApp.Services
{
    public class RabbitMQService
    {
        private readonly string _rabbitMqHostName = "localhost"; 
        private readonly string _queueName = "fullscalecmsemail";
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitMqHostName };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
    }
}


