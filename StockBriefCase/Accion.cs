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
   public partial class Accion : Form
    {
        public Accion()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accion_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedItem.ToString() == "Acciones")
            {
                comboBoxTipoAccion.Visible = true;
                comboBoxTipoAccion.Enabled = true;
            }
            else if (comboBoxTipo.SelectedItem.ToString() != "Acciones")
            {
                comboBoxTipoAccion.Visible = false;
                comboBoxTipoAccion.Enabled = false;
                comboBoxTipoAccion.Text = "";
            }
        }
    }
}
