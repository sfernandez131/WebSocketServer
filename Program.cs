using Newtonsoft.Json;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketSrvrs
{
    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved message from client: " + e.Data);
            Send(e.Data);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            WebSocketServer wssv = new("ws://127.0.0.1:7889");

            wssv.AddWebSocketService<Echo>("/Echo");

            wssv.Start();
            Console.WriteLine($"WebSocketServer started on ws://127.0.0.1:7889/Echo");

            Console.ReadKey();
            wssv.Stop();
        }
    }
}