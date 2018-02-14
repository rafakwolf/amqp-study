using System;
using Contracts;
using EasyNetQ;

namespace ConsoleApp_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var messageBus = RabbitHutch.CreateBus(Configs.ConnectionString))
            {
                messageBus.Subscribe<HelloMessage>("my_subscription_id",
                    hello =>
                    {
                        Console.WriteLine(hello.SayHello);
                    });
            }

            //Console.WriteLine("Aguardando mensagens...");
            Console.ReadLine();
        }
    }
}
