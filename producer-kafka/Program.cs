public class Program
{
    static async Task Main(string[] args)
    {
        var producer = new Producer();
        await producer.SendMessage("Test Message");
    }
}