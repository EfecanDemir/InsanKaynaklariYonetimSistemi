using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class bagliListeEgitim
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
                if (((egitim)gecici.Data).okulAdi == ((egitim)konum).okulAdi)
                {
                    Head = gecici.Next;
                }
                while(gecici!=null)
                {
                    if (((egitim)gecici.Data).okulAdi == ((egitim)konum).okulAdi)
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
        public string displayElements() //kişi yazdrıma işlemi
        {
            string gecici = "";
            Dugum a = Head;
            while(a!=null)
            {
                gecici += "\n" + ((egitim)a.Data).okulAdi.ToString() + "\n" + ((egitim)a.Data).bolum.ToString() + "\n" + ((egitim)a.Data).baslangicTarihi.ToString() + "\n" + ((egitim)a.Data).bitisTarihi.ToString() + "\n" + ((egitim)a.Data).notOrt.ToString();
                a = a.Next;
            }
            return gecici;
        }
    }
}
