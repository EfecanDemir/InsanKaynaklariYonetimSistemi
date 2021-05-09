using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class bagliListeIsDeneyimi
    {
        public Dugum Head;
        public int boyut = 0;
        public void dugumGiris(object deger)  //düğüm ilerleme elemanı ekleme
        {
            Dugum geciciHead = new Dugum() { Data = deger };
            if (Head == null)
            {
                Head = geciciHead;
            }
            else
            {
                geciciHead.Next = Head;
                Head = geciciHead;
            }
            boyut++;
        }
     
        public void konumSil(object konum) //oluşturulan elemanı silme
        {
            if (Head != null)
            {
                Dugum gecici = Head;

                Dugum konumDugum = new Dugum();
                konumDugum = Head;
                if (((isDeneyimi)gecici.Data).isAdi == ((isDeneyimi)konum).isAdi)
                {
                    Head = gecici.Next;
                }
                while (gecici != null)
                {
                    if (((isDeneyimi)gecici.Data).isAdi == ((isDeneyimi)konum).isAdi)
                    {
                        konumDugum.Next = gecici.Next;
                    }
                    else
                        konumDugum = gecici;
                    gecici = gecici.Next;
                }
                boyut--;
            }
        }
        public string displayElements()  //kişi yazdrıma işlemi
        {
            string gecici = "";
            Dugum a = Head;
            while (a != null)
            {
                gecici += "\n" + ((isDeneyimi)a.Data).isAdi.ToString() + "\n" + ((isDeneyimi)a.Data).isAdresi.ToString() + "\n" + ((isDeneyimi)a.Data).isPozisyon.ToString();
                a = a.Next;
            }
            return gecici;
        }
        
    }
}
