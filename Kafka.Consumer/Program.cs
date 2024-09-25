using Kafka.Infrastructure.Consumer;
using Kafka.Infrastructure.Shared;

var groupId = KafkaConstants.DefaultGroupId;
if (args.Any())
{
    groupId = args[0];
}
var consumer = new KafkaConsumer();
consumer.Build(groupId);

var cts = new CancellationTokenSource();

Task.Run(() =>
{
    while (true)
    {
        var input = Console.ReadLine();
        if (input?.ToLower() == "e")
        {
            cts.Cancel();
            break;
        }
    }
});

try
{
    while (!cts.IsCancellationRequested)
    {
        var result = consumer.Consume(cts.Token);
        
        // Do some logic
        Console.WriteLine($"{result.Message.Timestamp.UtcDateTime.ToLocalTime():HH:mm:ss} {result.Message.Key}: {result.Message.Value.Message}");
        consumer.StoreOffSet(result);
    }
}
catch (OperationCanceledException)
{
    
}
finally
{
    consumer.Dispose();
}
