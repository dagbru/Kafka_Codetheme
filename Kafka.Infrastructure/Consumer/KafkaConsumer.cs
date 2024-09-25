using Confluent.Kafka;
using Kafka.Infrastructure.Serialization;
using Kafka.Infrastructure.Shared;

namespace Kafka.Infrastructure.Consumer;

public class KafkaConsumer
{
    private readonly ConsumerConfig _kafkaConsumerConfig;
    private IConsumer<string,KafkaMessage> _kafkaConsumer;

    public KafkaConsumer()
    {
        _kafkaConsumerConfig = new ConsumerConfig
        {
            BootstrapServers = KafkaConstants.ConnectionString,
            GroupId = KafkaConstants.DefaultGroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoOffsetStore = false
        };
    }

    public void Build(string? groupId = null)
    {
        if (!string.IsNullOrEmpty(groupId))
        {
            _kafkaConsumerConfig.GroupId = groupId;
        }
        
        _kafkaConsumer = new ConsumerBuilder<string, KafkaMessage>(_kafkaConsumerConfig)
            .SetValueDeserializer(new KafkaJsonDeserializer<KafkaMessage>())
            .Build();
        
        _kafkaConsumer.Subscribe(KafkaConstants.DefaultTopic);
    }

    public void StoreOffSet(ConsumeResult<string, KafkaMessage> result)
    {
        _kafkaConsumer.StoreOffset(result);
    }

    public ConsumeResult<string, KafkaMessage> Consume(CancellationToken cancellationToken = default)
    {
        return _kafkaConsumer.Consume(cancellationToken);
    }

    public void Dispose()
    {
        _kafkaConsumer.Unsubscribe();
        _kafkaConsumer.Close();
        _kafkaConsumer.Dispose();
    }
}