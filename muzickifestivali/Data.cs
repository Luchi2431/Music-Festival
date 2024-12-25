using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickifestivali 
{
    [Serializable]

    internal class Data 
    {
        public int godina;
        public string naziv;
        public string slika;
        public string datoteka;
        public DateTime datum;

        public Data(int godina,string naziv,string slika, string datoteka, DateTime datum)
        {
            this.godina = godina;
            this.naziv = naziv;     
            this.slika = slika;
            this.datoteka = datoteka;
            this.datum = datum;
        }

        public int Godina
        {
            get { return godina; }
            set 
            {
                godina = value;
            }

        }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string Slika
        {
            get { return slika; }
            set { slika = value; }
        }

        public string Datoteka
        {
            get { return datoteka; }
            set { datoteka = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public bool IsSelected { get; set; }
        
    }

    
}
