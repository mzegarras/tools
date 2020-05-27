using System;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Data
{
    public class DemoService : BackgroundService
    {
        public const String TOPIC_DESTINATION = "static-topic-1";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

                while (!stoppingToken.IsCancellationRequested)
                {
            //string brokerUri = $"activemq:tcp://activemq1:61616";  // Default port
            string brokerUri = Environment.GetEnvironmentVariable("APP_NET_BROKER_URI");

            if(String.IsNullOrEmpty(brokerUri)){
                    brokerUri = $"activemq:tcp://localhost:61616";  // Default port
            }

            System.Console.WriteLine(brokerUri);


            IConnectionFactory factory = new ConnectionFactory(brokerUri);
            IConnection connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession();

              using (IDestination dest = session.GetTopic(TOPIC_DESTINATION)){
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();
                    if (msg is ITextMessage)
                    {
                        ITextMessage txtMsg = msg as ITextMessage;
                        string body = txtMsg.Text;
                        Console.WriteLine($"Received message: {txtMsg.Text}");
                    }
                    else
                    {
                        Console.WriteLine("Unexpected message type: " + msg.GetType().Name);
                    }

                }
            }


                }

        }
    }
}
