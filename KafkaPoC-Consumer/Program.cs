using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaPoC_Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // LOCALHOST

            //var config = new ConsumerConfig
            //{
            //    BootstrapServers = "localhost:9092",
            //    SecurityProtocol = SecurityProtocol.Plaintext,
            //    SaslMechanism = SaslMechanism.Plain,
            //    SocketTimeoutMs = 60000,                //this corresponds to the Consumer config `request.timeout.ms`
            //    SessionTimeoutMs = 30000,
            //    GroupId = "GroupId-Test",
            //    AutoOffsetReset = AutoOffsetReset.Earliest,
            //    BrokerVersionFallback = "1.0.0",        //Event Hubs for Kafka Ecosystems supports Kafka v1.0+, a fallback to an older API will fail
            //                                            //Debug = "security,broker,protocol"    //Uncomment for librdkafka debugging information
            //};
            //var topic = "test-topic";

            // EVENT HUB

            var topic = "test-topic";
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka-lc-poc.servicebus.windows.net:9093",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SocketTimeoutMs = 60000,                //this corresponds to the Consumer config `request.timeout.ms`
                SessionTimeoutMs = 30000,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = "Endpoint=sb://kafka-lc-poc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sh0iOFsv69z91GkHtg8L0FGsITYdUU2BpKCI0sE90Oo=",

                GroupId = "GroupId-Test",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                BrokerVersionFallback = "1.0.0",        //Event Hubs for Kafka Ecosystems supports Kafka v1.0+, a fallback to an older API will fail
                //Debug = "security,broker,protocol"    //Uncomment for librdkafka debugging information
            };


            // COFLUENT CLOUD

            //var config = new ConsumerConfig
            //{
            //    BootstrapServers = "pkc-lgwgm.eastus2.azure.confluent.cloud:9092",
            //    SaslMechanism = SaslMechanism.Plain,
            //    SecurityProtocol = SecurityProtocol.SaslSsl,
            //    SaslUsername = "IWUYBWIPSHQSBDB7",
            //    SaslPassword = "Jb8KdXaXQgx99UB0SW7dlluhpuPIxSlm3m4kHVaBjqktQNZ2fzdYheFZLsx0qj9B",
            //    SocketTimeoutMs = 60000,                //this corresponds to the Consumer config `request.timeout.ms`
            //    SessionTimeoutMs = 30000,
            //    GroupId = "GroupId-Test",
            //    AutoOffsetReset = AutoOffsetReset.Earliest,
            //    BrokerVersionFallback = "1.0.0",        //Event Hubs for Kafka Ecosystems supports Kafka v1.0+, a fallback to an older API will fail
            //    //Debug = "security,broker,protocol"    //Uncomment for librdkafka debugging information
            //};
            //var topic = "luistest";

            using (var consumer = new ConsumerBuilder<Null, string>(config).SetValueDeserializer(Deserializers.Utf8).Build())
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

                consumer.Subscribe(topic);

                Console.WriteLine("Consuming messages from topic: " + topic);

                while (true)
                {
                    try
                    {
                        var msg = consumer.Consume(cts.Token);
                        Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.ffff")}] => Received: '{msg.Value}'");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consume error: {e.Error.Reason}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
        }
    }
}
