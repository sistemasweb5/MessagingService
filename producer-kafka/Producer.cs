using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class Producer
{
    public async Task SendMessage(string message)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var deliveryResult = await producer.ProduceAsync("mensajes", new Message<Null, string> { Value = message });
                Console.WriteLine($"Mensaje enviado a {deliveryResult.TopicPartitionOffset}: {message}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Error al enviar el mensaje: {e.Error.Reason}");
            }
        }
    }
}
