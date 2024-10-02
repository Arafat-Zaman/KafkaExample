using System.Threading;
using System.Collections.Generic;
using Confluent.Kafka;
using KafkaExample;

class Program
{
    static async Task Main(string[] args)
    {
        var producerTask = ProduceMessagesAsync();

        // Wait for producer to finish
        await producerTask;

        // Now, start consuming messages
        ConsumeMessages();
    }

    static void ConsumeMessages()
    {
        var config = new ConsumerConfig
        {
            GroupId = "test-consumer-group",
            BootstrapServers = KafkaConfig.BootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(KafkaConfig.Topic);
            Console.WriteLine("Consuming messages from Kafka...");

            while (true)
            {
                var consumeResult = consumer.Consume(CancellationToken.None);
                Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' from: {consumeResult.TopicPartitionOffset}");
            }
        }
    }

    static async Task ProduceMessagesAsync()
    {
        // Producer code remains the same as in Step 4
    }
}
