// SocketClient.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationProtocols.Client;

public class SocketClient
{
    private readonly int PortNumber;
    private readonly byte[] ResponseDataBuffer = new byte[1024];
    public SocketClient(int portNumber)
    {
        PortNumber = portNumber;
    }

    public void SendMessage(string requestData)
    {
        var ipAddress = IPAddress.Loopback;
        var remoteEndPoint = new IPEndPoint(ipAddress, PortNumber);

        // Create a TCP/IP socket.  
        var sender = new Socket(
            addressFamily: ipAddress.AddressFamily,
            socketType: SocketType.Stream,
            protocolType: ProtocolType.Tcp);

        var encodedData = Encoding.UTF8.GetBytes(requestData);

        sender.Connect(remoteEndPoint);

        System.Console.WriteLine("Client is about to send data to server");
        sender.Send(encodedData);

        sender.Receive(ResponseDataBuffer);

        var responseData = Encoding.UTF8.GetString(ResponseDataBuffer);

        System.Console.WriteLine($"Client received data from server:{responseData}");
    }

}