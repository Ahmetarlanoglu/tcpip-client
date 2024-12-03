using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
using tcp;

namespace tcpip
{

    public partial class Form1 : Form
    {
        private ClientClass myObject = null;
        public delegate void AddListItem();
        public Form1()
        {            
            InitializeComponent();
            myObject = new ClientClass("John Doe", 30);
            //textBox1.Text = "jogoat";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox2.AppendText("Yeni satırda metin" + Environment.NewLine);
            myObject.SendInfo("m");
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            myObject.DisplayInfo(this);
            myObject.Info();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            myObject.SendInfo("k");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
