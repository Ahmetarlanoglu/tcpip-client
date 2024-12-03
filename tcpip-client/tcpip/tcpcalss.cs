using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleTcp;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using tcpip;
using System.Windows.Forms;
namespace tcp
{
    public class ClientClass
    {
        // Sınıfın özelliklerini (properties) tanımlayın
        private TcpClient clientim;
        
        private NetworkStream stream;
        private string Name;
        private int Age;
        public Form1 formum;
        public event EventHandler ValueChanged;
        private string _a;

        public string DATA_prop
        {
            get { return _a; }
            set
            {
                if (_a != value)
                {
                    _a = value;
                    Iread();
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        private void Iread()
        {
            Console.WriteLine("GETO SUGURU");
            
        }
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        public ClientClass(string Name, int Age)
        {
            //clientim = new SimpleTcpClient("127.0.0.1:9000");
            //clientim = new TcpClient("192.168.88.137", 9);
            clientim = new TcpClient("192.168.88.137", 9);
         
            stream = clientim.GetStream();
            
            

            this.Name = Name;
            this.Age = Age;
        }
        public void Info()
        {
            Thread thread = new Thread(new ThreadStart(ReadData));
            thread.Start();
        }

        public string DisplayInfo(Form1 form)
        {
            Console.WriteLine(form);
            formum = form;
            string message = "merhaba";
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            //byte[] buffer = new byte[1024];
            //int byteCount = stream.Read(buffer, 0, buffer.Length);
            //string response = Encoding.UTF8.GetString(buffer, 0, byteCount);

            //Console.WriteLine($"Received: {response}");
            
            return $"server açıldı";
        }
        public void SendInfo(string dat)
        {
            string message = dat;
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public void ReadData()
        {
            while (true)
            {
                Thread.Sleep(70);
                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, byteCount);
                try {
                    double pt = int.Parse(response);
                    pt *= 3.3 / 4095;
                    response = pt.ToString();//AGJILGAJKLAJKŞLJKJKLŞJŞKLJŞKLJŞKLJŞKLJŞKLJŞKLŞKLJJŞKLKLJŞKLJŞGADKLJŞGJKLKLJJKLGDAKL
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" hata: " + ex.Message);
                }
                DATA_prop = response;
                formum.Invoke((MethodInvoker)delegate {
                    formum.textBox2.Clear();
                    formum.textBox2.AppendText(response + Environment.NewLine);
                    
             

                });
                Console.WriteLine(formum);


            }

        }












        // Sınıfın metodlarını tanımlayın
        //public string DisplayInfo()
        //{
        //    Console.WriteLine($"Name: {Name}, Age: {Age}");
        //    clientim.Events.Connected += (sender, e) =>
        //    {
        //        Console.WriteLine("Connected to server.");
        //    };

        //    clientim.Events.Disconnected += (sender, e) =>
        //    {
        //        Console.WriteLine("Disconnected from server.");
        //    };
        //    clientim.Events.DataReceived += (sender, e) =>
        //    {
        //        // ArraySegment<byte> to byte[]
        //        byte[] data = e.Data.ToArray();
        //        string messagek = System.Text.Encoding.UTF8.GetString(data);
        //        Console.WriteLine($"Received from server: {messagek}");
        //    };
        //    clientim.Connect();
        //    string message = "selamun aleykum";
        //    clientim.Send(message);
        //    Console.ReadLine();
        //    return $"server açıldı";
        //}
        //public void SendInfo()
        //{
        //    string message = "datadatadata";
        //    clientim.Send(message);

        //}
    }
}
