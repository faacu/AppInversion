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
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        bool limpieza = false;
        int accion, etf, opciones, metales, energias, mPrimas, cripto;
        List<string> empresas = new List<string>();
        List<int> cantidad = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Propiedades
        public int Accion
        {
            get { return accion; }
            set { accion = value; }
        }
        public int ETF
        {
            get { return etf; }
            set { etf = value; }
        }
        public int Opciones
        {
            get { return opciones; }
            set { opciones = value; }
        }
        public int Metales
        {
            get { return metales; }
            set { metales = value; }
        }
        public int Energias
        {
            get { return energias; }
            set { energias = value; }
        }
        public int Mprimas
        {
            get { return mPrimas; }
            set { mPrimas = value; }
        }
        public int Criptos
        {
            get { return cripto; }
            set { cripto = value; }
        }
        //para las el grafico de cantidad de acciones por empresa
        public List<string> Nombres
        {
            get { return empresas; }
            set { empresas = value; }
        }
        public List<int> Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if(limpieza == true)
            {
                chart1.Series["S1"].Points.Clear();
                limpieza = false;
            }
            if(radioButtonDivers.Checked == true) //diversificacion
            {
                chart1.Series["S1"].Points.AddXY("Acciones", Accion);
                chart1.Series["S1"].Points.AddXY("ETF", ETF);
                chart1.Series["S1"].Points.AddXY("Opciones", Opciones);
                chart1.Series["S1"].Points.AddXY("Metales", Metales);
                chart1.Series["S1"].Points.AddXY("Energias", Energias);
                chart1.Series["S1"].Points.AddXY("Materias Primas", Mprimas);
                chart1.Series["S1"].Points.AddXY("Criptomonedas", Criptos);
                radioButtonDivers.Checked = false;
                radioButtonAccion.Checked = false;
                limpieza = true;
            }
            else if(radioButtonAccion.Checked == true) //acciones
            {
                for(int n = 0;n< Nombres.Count;n++)
                {
                    chart1.Series["S1"].Points.AddXY(Nombres[n], Cantidad[n]);
                }
                radioButtonAccion.Checked = false;
                radioButtonDivers.Checked = false;
                limpieza = true;
            }
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            
        }
    }
}
