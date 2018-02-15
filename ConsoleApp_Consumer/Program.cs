using System;
using System.Text;
using Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsoleApp_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = Configs.NewConnection();

            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = Encoding.Default.GetString(ea.Body);
                Console.WriteLine(body);
                channel.BasicAck(ea.DeliveryTag, false);
            };

            var consumerTag = channel.BasicConsume("my_queue", false, consumer);

            Console.WriteLine("Aguardando mensagens...");
            Console.ReadLine();
        }
    }
}
