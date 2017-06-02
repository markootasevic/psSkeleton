using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class BeginForm : Form
    {
        private Komunikacija komunikacija;

        public BeginForm()
        {
            InitializeComponent();

            komunikacija = new Komunikacija();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (komunikacija.ConnectToServer())
                {
                    MessageBox.Show("Connected to Server!");

                    new ClientForm(komunikacija).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void BeginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                komunikacija.DisconnectFromServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }
    }
}
