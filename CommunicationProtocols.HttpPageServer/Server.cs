// Server.cs
//
// © 2021 FESB in cooperation with Zoraja Consulting. All rights reserved.

using System;
using System.Net;
using System.Threading.Tasks;

namespace CommunicationProtocols.HttpServer;

public static class Server
{
    public static async Task Listen()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add($"http://localhost:8008/");

        listener.Start();

        Console.WriteLine("Server is listening...");
        try
        {
            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                var context = await listener.GetContextAsync();

                Console.WriteLine("Server got request...");

                // Obtain a response object.
                var response = context.Response;

                // Construct a response.
                var responseString = @"
<!DOCTYPE html>

<html>
	<head>
		<title>My HTML Page</title>
	</head>

	<body>
		<style>
			.my-container
			{
				background-color: aqua;
			}
            .my-button
            {
            	color: teal;
                background-color: crimson;
                height: 100px;
                width: 100px;
                margin-left: 100px;
            }
		</style>
		
		<div class=""my-container"">
			<button class=""my-button"" onclick=""onButtonClick()"">Click me!</button>
		<div>
		
		<script type=""text/javascript"">
        	function onButtonClick()
            {
                const today = new Date();
                let h = today.getHours();
                let m = today.getMinutes();
                let s = today.getSeconds();
            	alert(`Time: ${h}:${m}:${s}`)
            }
		</script>
	</body>
</html>
                ";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;

                var output = response.OutputStream;
                await output.WriteAsync(buffer);

                // You must close the output stream.
                output.Close();
            }
        }
        catch
        {
            listener.Stop();
        }
    }
}