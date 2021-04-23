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
        public List<string> empresas = new List<string>(); //para estadisticas por accion
        public List<int> cantidad = new List<int>();     //para estadisticas por accion
        public List<int> cantidadS = new List<int>(); //para estadisticas por tipo
        public List<string> sectores = new List<string> {"ETF", "Opciones","Metales","Materias Primas","Criptomonedas","Aerolíneas",
                                                                                                                        "Agua",
                                                                                                                        "Alimentación",
                                                                                                                        "Automóviles",
                                                                                                                        "Autopistas e infraestructuras",
                                                                                                                        "Bancos comerciales",
                                                                                                                        "Bancos de inversión",
                                                                                                                        "Biotecnología",
                                                                                                                        "Construcción",
                                                                                                                        "Consumo",
                                                                                                                        "Distribución",
                                                                                                                        "Eléctricas",
                                                                                                                        "Farmacéuticas",
                                                                                                                        "Gasistas",
                                                                                                                        "Holdings",
                                                                                                                        "Industriales",
                                                                                                                        "Inmobiliarias",
                                                                                                                        "Medios de comunicación",
                                                                                                                        "Petroleras",
                                                                                                                        "Químicas",
                                                                                                                        "Seguros",
                                                                                                                        "Tecnologicas",
                                                                                                                        "Telecomunicaciones"}; //para estadisticas por tipo
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accionesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accionesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDAccionesDataSet);

        }

        private void accionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if(limpieza == true)
            {
                chart1.Series["S1"].Points.Clear();
                limpieza = false;
            }
            if(radioButtonSectores.Checked == true) //diversificacion
            {
                for (int n = 0; n < sectores.Count; n++)
                {
                    chart1.Series["S1"].Points.AddXY(sectores[n], cantidadS[n]);
                }
                radioButtonSectores.Checked = false;
                radioButtonAccion.Checked = false;
                limpieza = true;
            }
            else if(radioButtonAccion.Checked == true) //acciones
            {
                for(int n = 0;n< empresas.Count;n++)
                {
                    chart1.Series["S1"].Points.AddXY(empresas[n], cantidad[n]);
                }
                radioButtonAccion.Checked = false;
                radioButtonSectores.Checked = false;
                limpieza = true;
            }
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDAccionesDataSet.Acciones' Puede moverla o quitarla según sea necesario.
            this.accionesTableAdapter.Fill(this.bDAccionesDataSet.Acciones);
            for (int n = 0; n < accionesDataGridView.Rows.Count; n++)
            {
                if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Aerolíneas")
                {
                    cantidadS[5] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Agua")
                {
                    cantidadS[6] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Alimentación")
                {
                    cantidadS[7] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Automóviles")
                {
                    cantidadS[8] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Autopistas e infraestructuras")
                {
                    cantidadS[9] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Bancos comerciales")
                {
                    cantidadS[10] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Bancos de inversión")
                {
                    cantidadS[11] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Biotecnología")
                {
                    cantidadS[12] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Construcción")
                {
                    cantidadS[13] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Consumo")
                {
                    cantidadS[14] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Distribución")
                {
                    cantidadS[15] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Eléctricas")
                {
                    cantidadS[16] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Farmacéuticas")
                {
                    cantidadS[17] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Gasistas")
                {
                    cantidadS[18] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Holdings")
                {
                    cantidadS[19] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Industriales")
                {
                    cantidadS[20] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Inmobiliarias")
                {
                    cantidadS[21] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Medios de comunicación")
                {
                    cantidadS[22] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Petroleras")
                {
                    cantidadS[23] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Químicas")
                {
                    cantidadS[24] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Seguros")
                {
                    cantidadS[25] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Tecnologicas")
                {
                    cantidadS[26] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Telecomunicaciones")
                {
                    cantidadS[27] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "ETF")
                {
                    cantidadS[0] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Opciones")
                {
                    cantidadS[1] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Metales")
                {
                    cantidadS[2] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Materias Primas")
                {
                    cantidadS[3] += 1;
                }
                else if (Convert.ToString(accionesDataGridView.Rows[n].Cells[6].Value) == "Criptomonedas")
                {
                    cantidadS[4] += 1;
                }
            }
            //ARREGLAR
            for (int o = 0; o < accionesDataGridView.Rows.Count; o++)
            {
                if (Convert.ToString(accionesDataGridView.Rows[o].Cells[2].Value) != "" && Convert.ToInt32(accionesDataGridView.Rows[o].Cells[3].Value) == 0)
                {
                    empresas.Add(Convert.ToString(accionesDataGridView.Rows[o].Cells[2].Value));
                    cantidad.Add(Convert.ToInt32(0));
                }
                else
                {
                    empresas.Add(Convert.ToString(accionesDataGridView.Rows[o].Cells[2].Value));
                    cantidad.Add(Convert.ToInt32(accionesDataGridView.Rows[o].Cells[3].Value));
                }
            }
        }
    }
}
