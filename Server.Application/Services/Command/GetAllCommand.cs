using Server.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Server.Application.Services.Command;
public class GetAllCommand : ICommandStrategy
{
    private readonly IBookService _bookService;
    public GetAllCommand(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async void Execute(NetworkStream stream, string clientRequest)
    {
        var books = await _bookService.GetAllAsync();
        _=JsonResponse.Write(stream, "BooksAll");
    }
}
