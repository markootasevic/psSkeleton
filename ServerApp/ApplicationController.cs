using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace ServerApp
{
    public class ApplicationController
    {
        private NetworkStream stream;
        private BinaryFormatter binaryFormatter;

        public ApplicationController(NetworkStream stream)
        {
            this.stream = stream;
            binaryFormatter = new BinaryFormatter();

            Thread thread = new Thread(Worker);
            thread.Start();
        }

        private void Worker()
        {
            try
            {
                int operation = 0;

                while (operation != (int) Operations.End)
                {
                    TransferClass transferClass = binaryFormatter.Deserialize(stream) as TransferClass;
                    operation = transferClass.Operation;

                    switch (operation)
                    {
                        case (int)Operations.End:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }
    }
}
