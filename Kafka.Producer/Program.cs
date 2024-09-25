using Kafka.Infrastructure.Producer;
using Kafka.Infrastructure.Shared;

var producer = new KafkaProducer();

for (var i = 0; i < 100; i++)
{
    await producer.ProduceAsync(new KafkaMessage
    {
        Id = Guid.NewGuid(),
        Message = $"{i} {Guid.NewGuid()}"
    });
}
