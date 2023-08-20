using Server.Application.Interfaces;
using Server.Application.Services.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services;
public class RequestHandler
{
    private readonly Dictionary<string,ICommandStrategy> _commandStrategies;

    public RequestHandler (IBookService bookService)
    {
        _commandStrategies = new Dictionary<string, ICommandStrategy>
        {
            {"GetAll", new GetAllCommand(bookService) },
        };
    }

    public async Task HandleClientRequestAsync(NetworkStream networkStream, string clientRequest)
    {
        if(clientRequest is null)
        {
            return;
        }

        if (_commandStrategies.TryGetValue(clientRequest, out var strategy))
        {
            await strategy.Execute(networkStream, clientRequest);
        }

    }
}
