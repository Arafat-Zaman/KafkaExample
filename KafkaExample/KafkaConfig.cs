using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaExample
{
    public class KafkaConfig
    {
        public const string BootstrapServers = "localhost:9092"; // Kafka server address
        public const string Topic = "test_topic";  // Kafka topic to produce/consume from
    }

}
