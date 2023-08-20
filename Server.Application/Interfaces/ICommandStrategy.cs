using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces;
public interface ICommandStrategy
{
    Task Execute(NetworkStream stream, string clientRequest);
}
