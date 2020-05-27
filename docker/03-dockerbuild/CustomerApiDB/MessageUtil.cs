using System;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;


namespace CustomerApi.Data
{
    public class MessageUtil
    {   

        private IConnection connection;
        private ISession session;
        public const String TOPIC_DESTINATION = "static-topic-1";

        private MessageUtil()
        {
        }

        private static MessageUtil _instance = null;
        public static MessageUtil Instance()
        {
            if (_instance == null)
                _instance = new MessageUtil();
           return _instance;
        }

        public bool IsConnect()
        {
            if (session == null)
            {
                 //string brokerUri = $"activemq:tcp://activemq1:61616";  // Default port
                string brokerUri = Environment.GetEnvironmentVariable("APP_NET_BROKER_URI");
            
                if(String.IsNullOrEmpty(brokerUri)){
                        brokerUri = $"activemq:tcp://localhost:61616";  // Default port
                }
            
                Console.WriteLine(brokerUri);
                
                if (String.IsNullOrEmpty(brokerUri))
                    return false;

                IConnectionFactory factory = new ConnectionFactory(brokerUri);
                connection = factory.CreateConnection();
                connection.Start();
                session = connection.CreateSession();
            }

            return true;
        }

        public void sendMessage(String text){
            using (IDestination dest = session.GetTopic(TOPIC_DESTINATION)){
                using (IMessageProducer producer = session.CreateProducer(dest))
                { 
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;
                    producer.Send(session.CreateTextMessage(text));
                    Console.WriteLine($"Sent {text} messages");
                }
            }
        }

        public void Close()
        {
            session.Close();
            connection.Close();

            session = null;
            connection = null;
        }        
    }
}