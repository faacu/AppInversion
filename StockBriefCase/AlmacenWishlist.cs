using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBriefCase
{
    [Serializable]class AlmacenWishlist
    {
        List<string> nyseNombres = new List<string>();//Nyse
        List<string> nysePrecio = new List<string>();
        List<string> nasdaqNombres = new List<string>();//Nasdaq
        List<string> nasdaqPrecio = new List<string>();
        List<string> matNombres = new List<string>();//Materias Primas
        List<string> matPrecio = new List<string>();
        List<string> etfSimbolos = new List<string>();//ETFs
        List<string> etfPrecio = new List<string>();
        List<string> criptoNombres = new List<string>();//Criptos
        List<string> criptoPrecio = new List<string>();
        List<string> nombres = new List<string>();
        List<string> simbolos = new List<string>();
        List<string> precio = new List<string>();
        string linea;

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
    }
}
