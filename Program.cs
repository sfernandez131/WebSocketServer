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
            try
            {
                Console.WriteLine("Recieved message from client: " + e.Data);
                Send(e.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    internal class Program
    {
        public static WebSocketServer wssv { get; set; } = new("ws://172.16.2.43:8080");
        private static void Main()
        {
            Listener();
        }

        private static void Listener()
        {
            try
            {
                wssv.AddWebSocketService<Echo>("/Echo");

                wssv.Start();
                Console.WriteLine($"WebSocketServer started on ws://172.16.2.43:8080/Echo\n Press any key to stop.");

                Console.ReadKey();
                wssv.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                wssv.Stop();
                Listener();
            }
        }
    }
}