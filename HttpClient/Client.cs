// Client.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CommunicationProtocols.HttpClient;

public static class Client
{
    public static async Task Call()
    {
        var httpClient = new System.Net.Http.HttpClient();

        var httpRequestMessage = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("http://localhost:8008/")
        };

        var response = await httpClient.SendAsync(httpRequestMessage);

        var responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Received from server: {responseContent}");
    }
}