using System;
using System.Text;
using Contracts;
using RabbitMQ.Client;

namespace ConsoleApp_Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = Configs.NewConnection();

            var conn = factory.CreateConnection();
            var model = conn.CreateModel();

            model.ExchangeDeclare("my_exchange", ExchangeType.Direct);
            model.QueueDeclare("my_queue", false, false, false, null);
            model.QueueBind("my_queue", "my_exchange", "my_routing_key", null);

            var message = Encoding.UTF8.GetBytes("Hello world!!!");
            model.BasicPublish("my_exchange", "my_routing_key",null, message);

            Console.WriteLine("Mensagem publicada!");
            Console.ReadLine();
        }
    }
}
