using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private NetworkStream stream;

        public ServerForm()
        {
            InitializeComponent();
        }

        private bool StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 10000));

                Thread thread = new Thread(ListenClients);
                thread.Start();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ListenClients()
        {
            serverSocket.Listen(5);

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                stream = new NetworkStream(clientSocket);

                ApplicationController applicationController = new ApplicationController(stream);
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (StartServer())
            {
                lblServerMessage.Text = "Server is started!";
                btnStartServer.Enabled = false;
            }
        }
    }
}
