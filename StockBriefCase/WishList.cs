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
   public partial class WishList : Form
    {
        public WishList()
        {
            InitializeComponent();
        }
        List<string> nyseNombres = new List<string>();//Nyse
        List<string> nyseNombresMalo = new List<string>();
        List<string> nysePrecio = new List<string>();
        List<string> nysePrecioMalo = new List<string>();
        List<string> nasdaqNombres = new List<string>();//Nasdaq
        List<string> nasdaqNombresMalo = new List<string>();
        List<string> nasdaqPrecio = new List<string>();
        List<string> nasdaqPrecioMalo = new List<string>();
        List<string> matNombres = new List<string>();//Materias Primas
        List<string> matNombresMalo = new List<string>();
        List<string> matPrecio = new List<string>();
        List<string> matPrecioMalo = new List<string>();
        List<string> etfSimbolos = new List<string>();//ETFs
        List<string> etfPrecio = new List<string>();
        List<string> criptoNombres = new List<string>();//Criptos
        List<string> criptoNombresMalo = new List<string>();
        List<string> criptoPrecio = new List<string>();
        List<string> criptoPrecioMalo = new List<string>();
        string linea;
        bool encontrado = false;
        List<string> nombres = new List<string>();
        List<string> simbolos = new List<string>();
        List<string> precio = new List<string>();
        Eliminar eliminar = new Eliminar();

        //Propiedades
        public string Notas
        {
            get { return linea; }
            set { linea = value; }
        }
        public List<string> Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        public List<string> Simbolos
        {
            get { return simbolos; }
            set { simbolos = value; }
        }
        public List<string> Precios
        {
            get { return precio; }
            set { precio = value; }
        }
        public List<string> Nyse
        {
            get { return nyseNombres; }
            set { nyseNombres = value; }
        }
        public List<string> Nasdaq
        {
            get { return nasdaqNombres; }
            set { nasdaqNombres = value; }
        }
        public List<string> Materias
        {
            get { return matNombres; }
            set { matNombres = value; }
        }
        public List<string> Etf
        {
            get { return etfSimbolos; }
            set { etfSimbolos = value; }
        }
        public List<string> Criptos
        {
            get { return criptoNombres; }
            set { criptoNombres = value; }
        }
        public List<string> NyseP
        {
            get { return nysePrecio; }
            set { nysePrecio = value; }
        }
        public List<string> NasdaqP
        {
            get { return nasdaqPrecio; }
            set { nasdaqPrecio = value; }
        }
        public List<string> MateriasP
        {
            get { return matPrecio; }
            set { matPrecio = value; }
        }
        public List<string> CriptoP
        {
            get { return criptoPrecio; }
            set { criptoPrecio = value; }
        }
        public List<string> ETFP
        {
            get { return etfPrecio; }
            set { etfPrecio = value; }
        }

        private void WishList_Load(object sender, EventArgs e)
        {
            //agregar datos anteriores al datagridview
            for(int n = 0; n < nombres.Count;n++)
            {
                int f = dataGridView1.Rows.Add();
                dataGridView1.Rows[f].Cells[0].Value = nombres[n];
                dataGridView1.Rows[f].Cells[1].Value = simbolos[n];
                dataGridView1.Rows[f].Cells[2].Value = precio[n];
            }
            richTextBoxNotas.Text = linea; //agrega las notas escritas antes de cerrar y guardar
            if (nyseNombres.Any() == false)
            {
                Scrapper();
            }
        }

        private void buttonCargar_Click(object sender, EventArgs e) 
        {
            int f = dataGridView1.Rows.Add();
            dataGridView1.Rows[f].Cells[0].Value = textBoxNombre.Text;
            dataGridView1.Rows[f].Cells[1].Value = textBoxSimbol.Text;

            if(encontrado == false)
            {
                for(int n = 0;n < nyseNombres.Count;n++)
                {
                    if(nyseNombres[n] == textBoxNombre.Text)
                    {
                        dataGridView1.Rows[f].Cells[2].Value = nysePrecio[n];
                        encontrado = true;
                        break;
                    }
                }
            }
            if (encontrado == false)
            {
                for (int n = 0; n < nasdaqNombres.Count; n++)
                {
                    if (nasdaqNombres[n] == textBoxNombre.Text)
                    {
                        dataGridView1.Rows[f].Cells[2].Value = nasdaqPrecio[n];
                        encontrado = true;
                        break;
                    }
                }
            }
            if (encontrado == false)
            {
                for (int n = 0; n < matNombres.Count; n++)
                {
                    if (matNombres[n] == textBoxNombre.Text)
                    {
                        dataGridView1.Rows[f].Cells[2].Value = matPrecio[n];
                        encontrado = true;
                        break;
                    }
                }
            }
            if (encontrado == false)
            {
                for (int n = 0; n < criptoNombres.Count; n++)
                {
                    if (criptoNombres[n] == textBoxSimbol.Text)
                    {
                        dataGridView1.Rows[f].Cells[2].Value = criptoPrecio[n];
                        encontrado = true;
                        break;
                    }
                }
            }
            if (encontrado == false)
            {
                for (int n = 0; n < etfSimbolos.Count; n++)
                {
                    if (etfSimbolos[n] == textBoxSimbol.Text)
                    {
                        dataGridView1.Rows[f].Cells[2].Value = etfPrecio[n];
                        encontrado = true;
                        break;
                    }
                }
            }
            encontrado = false;
            textBoxNombre.Clear();
            textBoxSimbol.Clear();
        }

        public void Scrapper() //agregar mas etfs, commodities y mercados de otros paises
        {
            //NYSE
            if (nysePrecio.Any() == true)
            {
                nysePrecio.Clear();
            }
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse");
            HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/2");
            HtmlAgilityPack.HtmlDocument doc3 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/3");
            HtmlAgilityPack.HtmlDocument doc4 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/4");
            HtmlAgilityPack.HtmlDocument doc5 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/5");
            HtmlAgilityPack.HtmlDocument doc6 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/6");
            HtmlAgilityPack.HtmlDocument doc7 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/7");
            HtmlAgilityPack.HtmlDocument doc8 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/8");
            HtmlAgilityPack.HtmlDocument doc9 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/9");
            HtmlAgilityPack.HtmlDocument doc10 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/10");
            HtmlAgilityPack.HtmlDocument doc11 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/11");
            HtmlAgilityPack.HtmlDocument doc12 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/12");
            HtmlAgilityPack.HtmlDocument doc13 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/13");
            HtmlAgilityPack.HtmlDocument doc14 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/14");
            HtmlAgilityPack.HtmlDocument doc15 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/15");
            HtmlAgilityPack.HtmlDocument doc16 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/16");
            HtmlAgilityPack.HtmlDocument doc17 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/17");
            HtmlAgilityPack.HtmlDocument doc18 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/18");
            HtmlAgilityPack.HtmlDocument doc19 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/19");
            HtmlAgilityPack.HtmlDocument doc20 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nyse/20");
            foreach (var item in doc.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc2.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc3.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc4.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc5.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc6.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc7.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc8.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc9.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc10.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc11.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc12.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc13.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc14.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc15.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc16.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc17.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc18.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc19.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();
            foreach (var item in doc20.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nysePrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nysePrecioMalo.Count; n = n + 2)
            {
                nysePrecio.Add(nysePrecioMalo[n]);
            }
            nysePrecioMalo.Clear();

            nyseNombres.Clear();
            foreach (var item in doc.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//desde 101 empiezan los nombres hasta 250- 1° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++) //modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc2.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//2° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc3.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//3° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++) //modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc4.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//4° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)// modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc5.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//5° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc6.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//6° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++) //modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc7.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//7° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc8.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//8° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc9.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//9° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc10.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//10° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc11.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//11° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc12.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//12° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc13.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//13° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc14.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//14° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc15.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//15° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc16.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//16° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc17.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//17° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc18.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//18° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc19.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//19° pagina
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            foreach (var item in doc20.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//20° pagina - hasta 210
            {
                nyseNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nyseNombres.Add(nyseNombresMalo[d]);
            }
            nyseNombresMalo.Clear();
            //-----------------------------------------------------------------------------------------------------------
            //Nasdaq 
            if (nasdaqPrecio.Any() == true)
            {
                nasdaqPrecio.Clear();
            }
            HtmlAgilityPack.HtmlDocument nas = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx");
            HtmlAgilityPack.HtmlDocument nas2 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/2");
            HtmlAgilityPack.HtmlDocument nas3 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/3");
            HtmlAgilityPack.HtmlDocument nas4 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/4");
            HtmlAgilityPack.HtmlDocument nas5 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/5");
            HtmlAgilityPack.HtmlDocument nas6 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/6");
            HtmlAgilityPack.HtmlDocument nas7 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/7");
            HtmlAgilityPack.HtmlDocument nas8 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/8");
            HtmlAgilityPack.HtmlDocument nas9 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/9");
            HtmlAgilityPack.HtmlDocument nas10 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/10");
            HtmlAgilityPack.HtmlDocument nas11 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/11");
            HtmlAgilityPack.HtmlDocument nas12 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/12");
            HtmlAgilityPack.HtmlDocument nas13 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/13");
            HtmlAgilityPack.HtmlDocument nas14 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/14");
            HtmlAgilityPack.HtmlDocument nas15 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/15");
            HtmlAgilityPack.HtmlDocument nas16 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/16");
            HtmlAgilityPack.HtmlDocument nas17 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/17");
            HtmlAgilityPack.HtmlDocument nas18 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/18");
            HtmlAgilityPack.HtmlDocument nas19 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/19");
            HtmlAgilityPack.HtmlDocument nas20 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/20");
            HtmlAgilityPack.HtmlDocument nas21 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/21");
            HtmlAgilityPack.HtmlDocument nas22 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/22");
            HtmlAgilityPack.HtmlDocument nas23 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/23");
            HtmlAgilityPack.HtmlDocument nas24 = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/indices/nasdaq-omx/24");
            foreach (var item in nas.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas2.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas3.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas4.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas5.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas6.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas7.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas8.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas9.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas10.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas11.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas12.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas13.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas14.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas15.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas16.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas17.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas18.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas19.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas20.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas21.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas22.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas23.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();
            foreach (var item in nas24.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                nasdaqPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < nasdaqPrecioMalo.Count; n = n + 2)
            {
                nasdaqPrecio.Add(nasdaqPrecioMalo[n]);
            }
            nasdaqPrecioMalo.Clear();

            nasdaqNombres.Clear();
            foreach (var item in nas.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//desde 101 empiezan los nombres hasta 250- 1° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas2.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//2° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas3.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//3° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas4.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//4° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas5.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//5° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas6.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//6° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas7.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//7° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas8.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//8° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas9.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//9° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas10.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//10° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas11.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//11° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas12.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//12° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas13.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//13° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas14.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//14° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas15.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//15° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas16.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//16° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas17.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//17° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas18.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//18° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas19.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//19° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas20.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//20° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas21.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//21° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas22.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//22° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 249; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas23.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//23° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 248; d++)//modificado
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            foreach (var item in nas24.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//24° pagina
            {
                nasdaqNombresMalo.Add(item.InnerText);
            }
            for (int d = 99; d < 225; d++)
            {
                nasdaqNombres.Add(nasdaqNombresMalo[d]);
            }
            nasdaqNombresMalo.Clear();
            //-----------------------------------------------------------------------------------------------------
            //ETFs
            if (etfPrecio.Any() == true)
            {
                etfPrecio.Clear();
                etfSimbolos.Clear();
            }
            HtmlAgilityPack.HtmlDocument docETF = web.Load("https://www.invertironline.com/mercado/cotizaciones/estados-unidos/etfs/todos");
            foreach (var item in docETF.DocumentNode.SelectNodes("//td[@class = 'right tar']"))
            {
                etfPrecio.Add(item.InnerText);
            }
            foreach (var item in docETF.DocumentNode.SelectNodes("//b"))
            {
                etfSimbolos.Add(item.InnerText);
            }
            //-------------------------------------------------------------------------------------------------------------------------------
            //Materias Primas
            if (matPrecio.Any() == true)
            {
                matPrecio.Clear();
                matPrecioMalo.Clear();
            }
            HtmlAgilityPack.HtmlDocument docMat = web.Load("https://www.estrategiasdeinversion.com/cotizaciones/materias-primas");
            foreach (var item in docMat.DocumentNode.SelectNodes("//td[@data-decimal = '3']"))
            {
                matPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < matPrecioMalo.Count; n = n + 2)
            {
                matPrecio.Add(matPrecioMalo[n]);
            }

            matNombres.Clear();
            foreach (var item in docMat.DocumentNode.SelectNodes("//a [@class = 'lnk']"))//desde 101 empiezan los nombres hasta 250
            {
                matNombresMalo.Add(item.InnerText);
            }
            for (int d = 100; d < 112; d++)
            {
                matNombres.Add(matNombresMalo[d]);
            }

            //-------------------------------------------------------------------------------------------------
            //Criptos
            if (criptoPrecio.Any() == true)
            {
                criptoPrecio.Clear();
                criptoPrecioMalo.Clear();
            }
            HtmlAgilityPack.HtmlDocument docCripto = web.Load("https://coincost.net/es/currencies");
            foreach (var item in docCripto.DocumentNode.SelectNodes("//td [@class = 'price'] //p"))
            {
                criptoPrecioMalo.Add(item.InnerText);
            }
            for (int n = 0; n < criptoPrecioMalo.Count; n = n + 2)
            {
                string usd = criptoPrecioMalo[n];
                string numero = usd.Substring(4);
                criptoPrecio.Add(numero);
            }

            criptoNombres.Clear();
            foreach (var item in docCripto.DocumentNode.SelectNodes("//td [@class = 'title'] //span"))
            {
                criptoNombresMalo.Add(item.InnerText);
            }
            for (int d = 1; d < criptoNombresMalo.Count; d = d + 2)
            {
                criptoNombres.Add(criptoNombresMalo[d]);
            }

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                nombres.Clear();
                simbolos.Clear();
                precio.Clear();
                for (int n = 0; n < dataGridView1.Rows.Count; n++) //ver porque guarda una linea en blanco mas
                {
                    nombres.Add(Convert.ToString(dataGridView1.Rows[n].Cells[0].Value));
                    simbolos.Add(Convert.ToString(dataGridView1.Rows[n].Cells[1].Value));
                    precio.Add(Convert.ToString(dataGridView1.Rows[n].Cells[2].Value));
                }
                while(dataGridView1.Rows.Count != 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
                }
            }
            linea = richTextBoxNotas.Text;
            this.Close();
        }

        private void buttonActualizar_Click_1(object sender, EventArgs e)
        {
            Scrapper();
            encontrado = false;
            for(int c = 0; c < dataGridView1.Rows.Count;c++)
            {
                if (encontrado == false)
                {
                    for (int n = 0; n < nyseNombres.Count; n++)
                    {
                        if (nyseNombres[n] == Convert.ToString(dataGridView1.Rows[c].Cells[0].Value))
                        {
                            dataGridView1.Rows[c].Cells[2].Value = nysePrecio[n];
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    for (int n = 0; n < nasdaqNombres.Count; n++)
                    {
                        if (nasdaqNombres[n] == Convert.ToString(dataGridView1.Rows[c].Cells[0].Value))
                        {
                            dataGridView1.Rows[c].Cells[2].Value = nasdaqPrecio[n];
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    for (int n = 0; n < matNombres.Count; n++)
                    {
                        if (matNombres[n] == Convert.ToString(dataGridView1.Rows[c].Cells[0].Value))
                        {
                            dataGridView1.Rows[c].Cells[2].Value = matPrecio[n];
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    for (int n = 0; n < criptoNombres.Count; n++)
                    {
                        if (criptoNombres[n] == Convert.ToString(dataGridView1.Rows[c].Cells[1].Value))
                        {
                            dataGridView1.Rows[c].Cells[2].Value = criptoPrecio[n];
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    for (int n = 0; n < etfSimbolos.Count; n++)
                    {
                        if (etfSimbolos[n] == Convert.ToString(dataGridView1.Rows[c].Cells[1].Value))
                        {
                            dataGridView1.Rows[c].Cells[2].Value = etfPrecio[n];
                            encontrado = true;
                            break;
                        }
                    }
                }
                encontrado = false;
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            eliminar.ShowDialog();

            if (eliminar.DialogResult == DialogResult.OK)
            {
                for (int n = 0; n < dataGridView1.Rows.Count; n++)
                {
                    if (Convert.ToString(dataGridView1.Rows[n].Cells[1].Value) == eliminar.textBoxSimbolo.Text)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[n]);
                        if (nombres.Count != 0)
                        {
                            nombres.RemoveAt(n);
                            simbolos.RemoveAt(n);
                            precio.RemoveAt(n);
                        }
                    }
                }
            }
            eliminar.textBoxSimbolo.Clear();
        }
    }
}
