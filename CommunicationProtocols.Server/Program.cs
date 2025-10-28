// Program.cs
//
// © 2025 FESB in cooperation with Zoraja Consulting. All rights reserved.

namespace CommunicationProtocols.Server;

public static class Program
{
    public static void Main()
    {
        var socketServer = new SocketServer(8000);
        var httpResponse = "Hola Mundo de Server";

        //var statusLine = "HTTP/1.1 200 OK\r\n";
        //var responseHeader = "Content-Type: text/html\r\n";
        //var responseBody = $"<!DOCTYPE html><html><head><title>Hello World!</title></head><body><div>Hola Mundo</div></body></html>";
        //var httpResponse = $"{statusLine}{responseHeader}\r\n{responseBody}";

        socketServer.StartListening(httpResponse);
    }
}