using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Server.Application.Services;
public static class JsonResponse
{
    public static async Task<string> Receive(NetworkStream stream)
    {
        if(stream is null)
        {
            return string.Empty;
        }

        byte[] buffer = new byte[1024];
        await stream.ReadAsync(buffer, 0, buffer.Length);
        var responseSize = BitConverter.ToInt32(buffer, 0);

        var responseBytes = new byte[responseSize];
        var bytesRead=0;
        while (bytesRead < responseBytes.Length)
        {
            bytesRead += await stream.ReadAsync(responseBytes, bytesRead, responseSize - bytesRead);
        }

        return Encoding.UTF8.GetString(responseBytes);
    }

    public static async Task Write(NetworkStream stream, string MSG)
    {
        var jsonResponse = JsonConvert.SerializeObject(MSG);
        var responseBytes = Encoding.UTF8.GetBytes(jsonResponse);
        var buffer = BitConverter.GetBytes(responseBytes.Length);

        await stream.WriteAsync(buffer, 0, buffer.Length);
        await stream.WriteAsync(responseBytes,0, responseBytes.Length);
    }
}
