using Confluent.Kafka;
using System;
using System.Threading;

class Consumer
{
    public void ReadMessages()
    {
        var config = new ConsumerConfig
        {
            GroupId = "grupo-mensajeria",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe("mensajes");
            
            Console.WriteLine("Esperando mensajes...");

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true; // Prevenir la salida inmediata
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cts.Token);
                        Console.WriteLine($"Mensaje recibido: {consumeResult.Message.Value}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error al consumir: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}


