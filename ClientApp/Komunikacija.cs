using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace ClientApp
{
    public class Komunikacija
    {
        private NetworkStream stream;
        private BinaryFormatter binaryFormatter;

        public Komunikacija()
        {
            binaryFormatter = new BinaryFormatter();
        }

        public bool ConnectToServer()
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 10000);
            stream = tcpClient.GetStream();

            return true;
        }

        public void DisconnectFromServer()
        {
            TransferClass transferClass = new TransferClass {Operation = (int) Operations.End};
            binaryFormatter.Serialize(stream,transferClass);
        }
    }
}
