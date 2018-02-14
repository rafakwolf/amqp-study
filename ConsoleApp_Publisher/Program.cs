using System;
using Contracts;
using EasyNetQ;

namespace ConsoleApp_Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var messagePublisher = RabbitHutch.CreateBus(Configs.ConnectionString))
            {
                var hello = new HelloMessage {SayHello = "Olá mundo!!!"};

                messagePublisher.Publish<HelloMessage>(hello);
            }

            //Console.WriteLine("Mensagem publicada!");
            Console.ReadLine();
        }
    }
}
