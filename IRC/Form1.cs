using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;

namespace IRC
{
    public partial class IRACID : Form
    {
        public IRACID()
        {
            InitializeComponent();
        }

        
        public void Form1_Load(object sender, EventArgs e)
        {
            //connect to the srv when the form is loading
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                label1.Visible = true;

                // use the ipaddress as in the server program

                label2.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                richTextBox1.Visible = true;
            }
            else
            {
                error1.Visible = true;
            }
   
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                string userName = textBox2.Text;
                textBox1.Visible = true;
                OK.Visible = false;
                textBox2.ReadOnly = true;
                textBox2.BackColor = Color.LightGray;
                textBox2.Text = userName;
                textBox2.UseWaitCursor = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // string msg = textBox1.Text;
                //textBox1.Text = "";
               // richTextBox1.Text = msg;

                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("127.0.0.1", 8001);
                string msg = textBox1.Text;
                textBox1.Text = "";
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(msg);

                    //transmition de l'info
                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                //reinit de la case
                textBox1.Text = "";
            }

            // for (int i = 0; i < k; i++)
            //    Console.Write(Convert.ToChar(bb[i]));
            // tcpclnt.Close();


        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.DarkBlue;
        }


        public void OK_Click(object sender, EventArgs e)
        {
            string userName = textBox2.Text;
            textBox1.Visible = true;
            OK.Visible = false;
            textBox2.ReadOnly = true;
            textBox2.BackColor = Color.LightGray;
            textBox2.Text = userName;
            textBox2.UseWaitCursor = false;
        }

       
        private void recupDiscut()
        {
         
        }
         
        private void printScreen()
        {
        
        } 
         
         
         
    }
}
