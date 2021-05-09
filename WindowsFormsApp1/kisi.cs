using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class kisi
    {
        public kisi()
        {
            this.egitimBilgisi = new bagliListeEgitim();
            this.deneyimBilgisi = new bagliListeIsDeneyimi();
        }
        public string ad { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string dTarihi { get; set; }
        public string yDil1 { get; set; }
        public string yDil2 { get; set; }
        public string yDil3{ get; set; }
        public string ehliyet { get; set; }
        public string adres { get; set; }
        public string okulTuru { get; set; }
        public string isSuresi { get; set; }

        public bagliListeEgitim egitimBilgisi;
        public bagliListeIsDeneyimi deneyimBilgisi;
    }
    }
