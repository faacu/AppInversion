using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockBriefCase
{
    public partial class Dividendos : Form
    {
        public Dividendos()
        {
            InitializeComponent();
        }
        decimal hoy, mensual, total;
        List<string> nombres = new List<string>();
        List<int> cantidad = new List<int>();

        public List<string> Nombres
        {
            set { nombres = value; }
        }
        public List<int> Cantidad
        {
            set { cantidad = value; }
        }

        private void Dividendos_Load(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)//salir
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            // scrapper
            scrapper();
            for (int n = 0;n < nombres.Count;n++)
            {
                
            }

            //if para que vea el mes y sume a mensual o no
        }

        public void scrapper()
        {

        }
    }
}
