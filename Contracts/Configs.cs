using RabbitMQ.Client;

namespace Contracts
{
    public class Configs
    {
        public static ConnectionFactory NewConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "llama-01.rmq.cloudamqp.com",
                VirtualHost = "azzjbuoq",
                UserName = "azzjbuoq",
                Password = "PT8mfKH7i5qcuKPBqQfZ-gGw19u15Arf"
            };

            return factory;
        }
    }
}
