using Confluent.Kafka;
using System;
using Xunit;

namespace KafkaPoC.Tests
{
    public class KafkaProducer
    {
        [Fact]
        public void LocalHostProduce_100Message_LogMessageSent()
        {
            // Arrange
            // LOCAL HOST

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                SecurityProtocol = SecurityProtocol.Plaintext,
                SaslMechanism = SaslMechanism.Plain,
            };
            var topic = "test-topic";

            // Act
            KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 100);

            // Asset
        }

        [Fact]
        public void AzureEventHubProduce_100Message_LogMessageSent()
        {
            // Arrange

            var config = new ProducerConfig
            {
                BootstrapServers = "kafka-lc-poc.servicebus.windows.net:9093",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "$ConnectionString",
                SaslPassword = "Endpoint=sb://kafka-lc-poc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sh0iOFsv69z91GkHtg8L0FGsITYdUU2BpKCI0sE90Oo=",
            };
            var topic = "test-topic";

            // Act
            KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 100);

            // Asset
        }

        //[Fact]
        //public void CofluentCloudProduce_100Messages_LogMessageSent()
        //{
        //    // Arrange
        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "pkc-lgwgm.eastus2.azure.confluent.cloud:9092",
        //        SaslMechanism = SaslMechanism.Plain,
        //        SecurityProtocol = SecurityProtocol.SaslSsl,
        //        SaslUsername = "IWUYBWIPSHQSBDB7",
        //        SaslPassword = "Jb8KdXaXQgx99UB0SW7dlluhpuPIxSlm3m4kHVaBjqktQNZ2fzdYheFZLsx0qj9B"
        //    };
        //    var topic = "luistest";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 100);

        //    // Asset
        //}


        //[Fact]
        //public void LocalHostProduce_500Message_LogMessageSent()
        //{
        //    // Arrange
        //    // LOCAL HOST

        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "localhost:9092",
        //        SecurityProtocol = SecurityProtocol.Plaintext,
        //        SaslMechanism = SaslMechanism.Plain,
        //    };
        //    var topic = "test-topic";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 500);

        //    // Asset
        //}

        //[Fact]
        //public void AzureEventHubProduce_500Message_LogMessageSent()
        //{
        //    // Arrange

        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "kafka-lc-poc.servicebus.windows.net:9093",
        //        SecurityProtocol = SecurityProtocol.SaslSsl,
        //        SaslMechanism = SaslMechanism.Plain,
        //        SaslUsername = "$ConnectionString",
        //        SaslPassword = "Endpoint=sb://kafka-lc-poc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sh0iOFsv69z91GkHtg8L0FGsITYdUU2BpKCI0sE90Oo=",
        //    };
        //    var topic = "test-topic";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 500);

        //    // Asset
        //}

        //[Fact]
        //public void CofluentCloudProduce_500Messages_LogMessageSent()
        //{
        //    // Arrange
        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "pkc-lgwgm.eastus2.azure.confluent.cloud:9092",
        //        SaslMechanism = SaslMechanism.Plain,
        //        SecurityProtocol = SecurityProtocol.SaslSsl,
        //        SaslUsername = "IWUYBWIPSHQSBDB7",
        //        SaslPassword = "Jb8KdXaXQgx99UB0SW7dlluhpuPIxSlm3m4kHVaBjqktQNZ2fzdYheFZLsx0qj9B"
        //    };
        //    var topic = "luistest";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 500);

        //    // Asset
        //}

        //[Fact]
        //public void LocalHostProduce_5000Message_LogMessageSent()
        //{
        //    // Arrange
        //    // LOCAL HOST

        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "localhost:9092",
        //        SecurityProtocol = SecurityProtocol.Plaintext,
        //        SaslMechanism = SaslMechanism.Plain,
        //    };
        //    var topic = "test-topic";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 5000);

        //    // Asset
        //}

        //[Fact]
        //public void AzureEventHubProduce_5000Message_LogMessageSent()
        //{
        //    // Arrange

        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "kafka-lc-poc.servicebus.windows.net:9093",
        //        SecurityProtocol = SecurityProtocol.SaslSsl,
        //        SaslMechanism = SaslMechanism.Plain,
        //        SaslUsername = "$ConnectionString",
        //        SaslPassword = "Endpoint=sb://kafka-lc-poc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sh0iOFsv69z91GkHtg8L0FGsITYdUU2BpKCI0sE90Oo=",
        //    };
        //    var topic = "test-topic";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 5000);

        //    // Asset
        //}

        //[Fact]
        //public void CofluentCloudProduce_5000Messages_LogMessageSent()
        //{
        //    // Arrange
        //    var config = new ProducerConfig
        //    {
        //        BootstrapServers = "pkc-lgwgm.eastus2.azure.confluent.cloud:9092",
        //        SaslMechanism = SaslMechanism.Plain,
        //        SecurityProtocol = SecurityProtocol.SaslSsl,
        //        SaslUsername = "IWUYBWIPSHQSBDB7",
        //        SaslPassword = "Jb8KdXaXQgx99UB0SW7dlluhpuPIxSlm3m4kHVaBjqktQNZ2fzdYheFZLsx0qj9B"
        //    };
        //    var topic = "luistest";

        //    // Act
        //    KafkaPoC_Producer.Worker.ProduceMessages(config, topic, 5000);

        //    // Asset
        //}

    }
}
