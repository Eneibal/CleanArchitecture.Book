using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services;
public class ServerCore
{
    private readonly TcpListener _listener;
    private readonly string _port = "1448";
    private readonly RequestHandler _requestHandler;

    public ServerCore(RequestHandler requestHandler)
    {
        _listener = new TcpListener(IPAddress.Any, int.Parse(_port));
        _requestHandler = requestHandler;
    }

    public async Task StartAsync()
    {
        _listener.Start();

        while (true)
        {
            var client = await _listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using(var stream = client.GetStream())
        {
            var res = await JsonResponse.Receive(stream);
            await _requestHandler.HandleClientRequestAsync(res);
            //var clientReuest = JsonConvert.DeserializeObject<string>(res);
            


        }

        client.Close();
    }
}
