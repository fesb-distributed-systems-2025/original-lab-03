// SocketServer.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationProtocols.Server;
public class SocketServer
{
    private readonly int PortNumber;
    private readonly byte[] RequestDataBuffer = new byte[1024];

    public SocketServer(int portNumber)
    {
        PortNumber = portNumber;
    }

    public void StartListening(string responseData)
    {
        var ipAddress = IPAddress.Loopback;
        var localEndPoint = new IPEndPoint(ipAddress, PortNumber);

        // Create a TCP/IP listener socket.  
        var listener = new Socket(
            addressFamily: ipAddress.AddressFamily,
            socketType: SocketType.Stream,
            protocolType: ProtocolType.Tcp);

        try
        {
            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            listener.Bind(localEndPoint);
            listener.Listen();

            while (true)
            {
                Console.WriteLine($"Server is waiting for a connection on port {PortNumber}...");
                // Start listening for connections.  
                AcceptConnectionAndSendResponse(listener, responseData);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void AcceptConnectionAndSendResponse(Socket listener, string responseData)
    {
        // Program is suspended while waiting for an incoming connection.  
        var handler = listener.Accept();
        var bytesReceived = handler.Receive(RequestDataBuffer, RequestDataBuffer.Length, SocketFlags.None);
        var requestData = Encoding.UTF8.GetString(RequestDataBuffer, 0, bytesReceived);

        Console.WriteLine($"Server received data from Client: {requestData}");

        var responseBytes = Encoding.UTF8.GetBytes(responseData);

        _ = handler.Send(responseBytes);
        handler.Close();
    }
}