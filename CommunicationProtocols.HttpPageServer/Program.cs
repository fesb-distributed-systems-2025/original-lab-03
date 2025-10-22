using System.Threading.Tasks;

namespace CommunicationProtocols.HttpServer;

public static class Program
{
    public static async Task Main()
    {
        await Server.Listen();
    }
}