// Program.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

namespace CommunicationProtocols.Client;

public static class Program
{
    public static void Main()
    {
        var clientSocket = new SocketClient(8000);

        clientSocket.SendMessage("Hola Mundo de Client");
    }
}