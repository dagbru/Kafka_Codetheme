using System.Text.Json;
using Confluent.Kafka;

namespace Kafka.Infrastructure.Serialization;

public class KafkaJsonSerializer<T> : ISerializer<T>
{
    public byte[] Serialize(T data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}