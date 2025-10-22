// Program.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

using System.Threading.Tasks;

namespace CommunicationProtocols.HttpClient;

public static class Program
{
    public static async Task Main()
    {
        await Client.Call();
    }
}