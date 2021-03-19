using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace StockBriefCase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Portafolio portafolio = new Portafolio();
        WishList lista = new WishList();
        AlmacenPortafilio almacenP = new AlmacenPortafilio();
        AlmacenWishlist almacenW = new AlmacenWishlist();

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            FileStream flsp = new FileStream("portafolio.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formateador = new BinaryFormatter();
            formateador.Serialize(flsp, almacenP);
            flsp.Close();
            FileStream flsw = new FileStream("wishlist.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formateadorw = new BinaryFormatter();
            formateadorw.Serialize(flsw, almacenW);
            flsw.Close();

            this.Close();
        }

        private void buttonPortafolio_Click(object sender, EventArgs e)
        {
            portafolio.ShowDialog();
            almacenP.Criptos = portafolio.Criptos;
            almacenP.Etf = portafolio.Etf;
            almacenP.Materias = portafolio.Materias;
            almacenP.Nasdaq = portafolio.Nasdaq;
            almacenP.Nyse = portafolio.Nyse;
            almacenP.NyseP = portafolio.NyseP;
            almacenP.NasdaqP = portafolio.NasdaqP;
            almacenP.MateriasP = portafolio.MateriasP;
            almacenP.CriptoP = portafolio.CriptoP;
            almacenP.ETFP = portafolio.ETFP;
            almacenP.VPorcentaje = portafolio.VPorcentaje;
        }

        private void buttonEstadistica_Click(object sender, EventArgs e)
        {
            Estadisticas estadisticas = new Estadisticas();
            estadisticas.Accion = portafolio.Accion;
            estadisticas.ETF = portafolio.ETF;
            estadisticas.Opciones = portafolio.Opciones;
            estadisticas.Metales = portafolio.Metales;
            estadisticas.Energias = portafolio.Energias;
            estadisticas.Mprimas = portafolio.MPrimas;
            estadisticas.Criptos = portafolio.Criptomonedas;
            estadisticas.Nombres = portafolio.nombre;
            estadisticas.Cantidad = portafolio.cantidad;
            estadisticas.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fls = new FileStream("portafolio.txt", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter formateador = new BinaryFormatter();
            if (fls.Length != 0)
            {
                almacenP = (AlmacenPortafilio)formateador.Deserialize(fls);
                portafolio.Criptos = almacenP.Criptos;
                portafolio.Etf = almacenP.Etf;
                portafolio.Materias = almacenP.Materias;
                portafolio.Nasdaq = almacenP.Nasdaq;
                portafolio.Nyse = almacenP.Nyse;
                portafolio.NyseP = almacenP.NyseP;
                portafolio.NasdaqP = almacenP.NasdaqP;
                portafolio.MateriasP = almacenP.MateriasP;
                portafolio.CriptoP = almacenP.CriptoP;
                portafolio.ETFP = almacenP.ETFP;
                portafolio.VPorcentaje = almacenP.VPorcentaje;
            }
            fls.Close();
            FileStream flsw = new FileStream("wishlist.txt", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter formateadorw = new BinaryFormatter();
            if (flsw.Length != 0)
            {
                almacenW = (AlmacenWishlist)formateadorw.Deserialize(flsw);
                lista.Criptos = almacenW.Criptos;
                lista.Etf = almacenW.Etf;
                lista.Materias = almacenW.Materias;
                lista.Nasdaq = almacenW.Nasdaq;
                lista.Nyse = almacenW.Nyse;
                lista.NyseP = almacenW.NyseP;
                lista.NasdaqP = almacenW.NasdaqP;
                lista.MateriasP = almacenW.MateriasP;
                lista.CriptoP = almacenW.CriptoP;
                lista.ETFP = almacenW.ETFP;
                lista.Nombres = almacenW.Nombres;
                lista.Simbolos = almacenW.Simbolos;
                lista.Precios = almacenW.Precios;
                lista.Notas = almacenW.Notas;
            }
            flsw.Close();
        }

        private void buttonWishlist_Click(object sender, EventArgs e)
        {
            lista.ShowDialog();
            almacenW.Criptos = lista.Criptos;
            almacenW.Etf = lista.Etf;
            almacenW.Materias = lista.Materias;
            almacenW.Nasdaq = lista.Nasdaq;
            almacenW.Nyse = lista.Nyse;
            almacenW.NyseP = lista.NyseP;
            almacenW.NasdaqP = lista.NasdaqP;
            almacenW.MateriasP = lista.MateriasP;
            almacenW.CriptoP = lista.CriptoP;
            almacenW.ETFP = lista.ETFP;
            almacenW.Nombres = lista.Nombres;
            almacenW.Simbolos = lista.Simbolos;
            almacenW.Precios = lista.Precios;
            almacenW.Notas = lista.Notas;
        }
    }
}
