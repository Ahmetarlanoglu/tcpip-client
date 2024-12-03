using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
namespace tcpip
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Console.WriteLine("Client connected...");
            //SimpleTcpClient client = new SimpleTcpClient("127.0.0.1:9000");

            //client.Events.Connected += (sender, e) =>
            //{
            //    Console.WriteLine("Connected to server.");
            //};

            //client.Events.Disconnected += (sender, e) =>
            //{
            //    Console.WriteLine("Disconnected from server.");
            //};

            //client.Events.DataReceived += (sender, e) =>
            //{
            //    // ArraySegment<byte> to byte[]
            //    byte[] data = e.Data.ToArray();
            //    string messagek = System.Text.Encoding.UTF8.GetString(data);
            //    Console.WriteLine($"Received from server: {messagek}");
            //};

            //client.Connect();
            //Console.WriteLine("Client connected...");

            //// Sunucuya mesaj gönderelim
            //string message = "Hello, Server!";
            //client.Send(message);
            //Console.WriteLine($"Sent to server: {message}");

            //Console.WriteLine("Press Enter to exit.");
            //Console.ReadLine();

            //client.disconnect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void ShowMessage()
        {
            Console.WriteLine("Press Enter to exit.");
        }
    }
}


