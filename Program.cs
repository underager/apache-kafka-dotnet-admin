// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;using Confluent.Kafka.Admin;

Console.WriteLine("Hello, World!");

string bootstrapServer = "localhost:9092";
string topicName = "Topic2";
int numberOfPartitions = 1;
short replicationFactor = 1;

var config = new AdminClientConfig { BootstrapServers = bootstrapServer };

using (var adminClient = new AdminClientBuilder(config).Build())
{
    try
    {
        var topicSpecification = new TopicSpecification
        {
            Name = topicName,
            NumPartitions = numberOfPartitions,
            ReplicationFactor = replicationFactor
        };

        await adminClient.CreateTopicsAsync(new []{topicSpecification});
        Console.WriteLine($"Topic {topicName} created successfully.");
    }
    catch(CreateTopicsException cte)
    {
        Console.WriteLine($"An error occured while creating topic {topicName} : {cte.Results[0]?.Error.Reason}");
    }


}