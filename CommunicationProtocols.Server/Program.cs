// Program.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

namespace CommunicationProtocols.Server;

public static class Program
{
    public static void Main()
    {
        var socketServer = new SocketServer(8000);
        socketServer.StartListening("Hola Mundo de Server");
    }
}