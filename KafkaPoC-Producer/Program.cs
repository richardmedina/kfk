using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaPoC_Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            // LOCAL HOST

            //var config = new ProducerConfig
            //{
            //    BootstrapServers = "localhost:9092",
            //    SecurityProtocol = SecurityProtocol.Plaintext,
            //    SaslMechanism = SaslMechanism.Plain,
            //};
            //var topic = "test-topic";

            // AZURE EVENT HUB

            var config = new ProducerConfig
            {
                Acks = Acks.All,
                BootstrapServers = "kafka-lc-poc.servicebus.windows.net:9093",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = "Endpoint=sb://kafka-lc-poc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sh0iOFsv69z91GkHtg8L0FGsITYdUU2BpKCI0sE90Oo=",
            };
            var topic = "test-topic";

            // COFLUENT CLOUD

            //var config = new ProducerConfig
            //{
            //    BootstrapServers = "pkc-lgwgm.eastus2.azure.confluent.cloud:9092",
            //    SaslMechanism = SaslMechanism.Plain,
            //    SecurityProtocol = SecurityProtocol.SaslSsl,
            //    SaslUsername = "IWUYBWIPSHQSBDB7",
            //    SaslPassword = "Jb8KdXaXQgx99UB0SW7dlluhpuPIxSlm3m4kHVaBjqktQNZ2fzdYheFZLsx0qj9B"
            //};
            //var topic = "luistest";

            //Worker.ProduceMessages(config, topic, 100);
            SendOnDemandMessage(config, topic);

            Console.WriteLine("Application end.........");
        }

        public static void SendOnDemandMessage(ProducerConfig config, string topic)
        {
            Console.WriteLine("Press (y) if you want to send a message...");
            var result = Console.ReadLine();

            while (result.ToUpper() == "Y")
            {
                Console.WriteLine("Enter the message...");
                var msg = Console.ReadLine();

                using (var p = new ProducerBuilder<Null, string>(config).Build())
                {
                    try
                    {

                        msg = $"[{DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.ffff")}] => {msg}";
                        var dr = p.ProduceAsync(topic, new Message<Null, string> { Value = msg }).GetAwaiter().GetResult();
                        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}' => {dr.Timestamp}");

                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed actual error: {e.Error.Reason}");
                    }
                }

                Console.WriteLine("Press (y) if you want to send another message...");
                result = Console.ReadLine();
            }
        }

        
    }
}
