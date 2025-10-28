// Program.cs
//
// © 2025 FESB in cooperation with Zoraja Consulting. All rights reserved.

namespace CommunicationProtocols.HttpClient;

public static class Program
{
    public static async Task Main()
    {
        await Client.Call();
    }
}