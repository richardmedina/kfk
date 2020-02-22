using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaPoC_Producer
{
    public static class Worker
    {
        public static void ProduceMessages(ProducerConfig config, string topic, int qty)
        {
            if(qty <= 0)
            {
                throw new ArgumentException(nameof(qty), "Cannot be negative or zero");
            }

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    for (int i = 0; i < qty; i++)
                    {
                        var msg = string.Format("Sample message #{0} sent at {1}", i, DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.ffff"));
                        var result = p.ProduceAsync(topic, new Message<Null, string> { Value = msg }).GetAwaiter().GetResult();
                        Console.WriteLine($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}'");
                    }
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed actual error: {e.Error.Reason}");
                }
            }
        }
    }
}
