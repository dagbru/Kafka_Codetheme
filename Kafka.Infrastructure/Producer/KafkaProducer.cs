using Confluent.Kafka;
using Kafka.Infrastructure.Serialization;
using Kafka.Infrastructure.Shared;

namespace Kafka.Infrastructure.Producer;

public class KafkaProducer
{
    private readonly ProducerConfig _kafkaProducerConfig;
    private readonly IProducer<string, KafkaMessage> _kafkaProducer;

    public KafkaProducer()
    {
        _kafkaProducerConfig = new ProducerConfig
        {
            BootstrapServers = KafkaConstants.ConnectionString,
            Acks = Acks.All
        };

        _kafkaProducer = new ProducerBuilder<string, KafkaMessage>(_kafkaProducerConfig)
            .SetValueSerializer(new KafkaJsonSerializer<KafkaMessage>())
            .Build();
    }

    public async Task<bool> ProduceAsync(KafkaMessage kafkaMessage)
    {
        var result = await _kafkaProducer.ProduceAsync(KafkaConstants.DefaultTopic, CreateMessage(kafkaMessage));

        return result.Status == PersistenceStatus.Persisted;
    }

    private Message<string,KafkaMessage> CreateMessage(KafkaMessage kafkaMessage)
    {
        return new Message<string, KafkaMessage>
        {
            Value = kafkaMessage,
            Key = kafkaMessage.Id.ToString(),
            Timestamp = new Timestamp(DateTime.UtcNow)
        };
    }
}