using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class kisiAgaci
    {
        private ikiliAramaAgacDugum kok;
        public string dugumler;
        public int minimumDeneyim;
        public kisiAgaci()
        {

        }
        public kisiAgaci(ikiliAramaAgacDugum kok)
        {
            this.kok = kok;
        }
        public string dugumYazdir()
        {
            return dugumler;
        }
        private void dugumBulma(ikiliAramaAgacDugum dugum)
        {
            dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
        }
        private void preOrderInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            dugumBulma(dugum);
            preOrderInt(dugum.sol);
            preOrderInt(dugum.sag);
        }
        private void inOrderInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            inOrderInt(dugum.sol);
            dugumBulma(dugum);
            inOrderInt(dugum.sag);
        }
        private void postOrderInt(ikiliAramaAgacDugum dugum)
        {
            if(dugum==null)
            {
                return;
            }
            postOrderInt(dugum.sol);
            postOrderInt(dugum.sag);
            dugumBulma(dugum);
        }
        public void preOrder()
        {
            dugumler = "";
            preOrderInt(kok);
        }
        
        public void inOrder()
        {
            dugumler = "";
            inOrderInt(kok);
        }
        public void postOrder()
        {
            dugumler = "";
            postOrderInt(kok);
        }
        private ikiliAramaAgacDugum araDugumSilme(ikiliAramaAgacDugum silinenDugum)//successor lar binary treelerden node silme işleminde kullanılırlar. ara kısımlardan node silinecekse yerine silinecek olan node'un successor değeri konulur.
        {
            ikiliAramaAgacDugum araDugumParent = silinenDugum;
            ikiliAramaAgacDugum araDugum = silinenDugum;
            ikiliAramaAgacDugum simdiki = silinenDugum.sag;

            while(simdiki!=null)
            {
                araDugumParent = araDugum;
                araDugum = simdiki;
                simdiki = simdiki.sol;
            }
            if(araDugum==silinenDugum.sag)
            {
                araDugumParent.sol = araDugum.sag;
                araDugum.sag = silinenDugum.sag;
            }
            return araDugum;
        }
        public ikiliAramaAgacDugum ara(string anahtarKelime)
        {
            return araInt(kok, anahtarKelime);
        }
        public void ekle(kisi x)
        {
            Boolean parentSol = true;
            ikiliAramaAgacDugum geciciParent = new ikiliAramaAgacDugum();
            ikiliAramaAgacDugum geciciArama = kok;
            while(geciciArama!=null)
            {
                geciciParent = geciciArama;
                if (x.ad == ((kisi)geciciArama.veri).ad)
                {
                    return;
                }
                else if (x.ad[0] < ((kisi)geciciArama.veri).ad[0])
                    geciciArama = geciciArama.sol;
                else if (x.ad[0] == ((kisi)geciciArama.veri).ad[0])
                {
                    int i = 1;
                    while (x.ad[i] != null)
                    {
                        if (x.ad[i] == ((kisi)geciciArama.veri).ad[i])
                        {
                            i++;
                            continue;
                        }
                        else if (x.ad[i] < ((kisi)geciciArama.veri).ad[i])
                        {
                            geciciArama = geciciArama.sol;
                            break;
                        }
                        else
                        {
                            parentSol = false;
                            geciciArama = geciciArama.sag;
                            break;
                        }
                    }
                }
                else
                    geciciArama = geciciArama.sag;
            }
            ikiliAramaAgacDugum eklenecek = new ikiliAramaAgacDugum(x);
            if (kok == null)
            {
                kok = eklenecek;
            }
            else if (x.ad[0] < ((kisi)geciciParent.veri).ad[0])
                geciciParent.sol = eklenecek;
            else if (x.ad[0] == ((kisi)geciciParent.veri).ad[0] && parentSol)
                geciciParent.sol = eklenecek;
            else
                geciciParent.sag = eklenecek;
        }
        
        private ikiliAramaAgacDugum araInt(ikiliAramaAgacDugum dugum,string anahtarKelime)
        {
            if (dugum == null)
                return null;
            else if (((kisi)dugum.veri).ad == anahtarKelime)
                return dugum;
            else if (((kisi)dugum.veri).ad[0] > anahtarKelime[0])
                return (araInt(dugum.sol, anahtarKelime));
            else
                return (araInt(dugum.sag, anahtarKelime));
        }
        public bool sil(string deger)
        {
            if(kok==null)
            {
                return false;
            }
            else
            {
                ikiliAramaAgacDugum simdiki = kok;
                ikiliAramaAgacDugum ebeveyn = kok;
                bool parentSol = true;
                while(((kisi)simdiki.veri).ad!=deger)
                {
                    ebeveyn = simdiki;
                    if(deger[0]<((kisi)simdiki.veri).ad[0])
                    {
                        parentSol = true;
                        simdiki = simdiki.sol;
                    }
                    else if(deger[0]==((kisi)simdiki.veri).ad[0])
                    {
                        int i = 1;
                        while(deger[i]!=null)
                        {
                            if(deger[i]==((kisi)simdiki.veri).ad[0])
                            {
                                i++;
                                continue;
                            }
                            else if(deger[i]<((kisi)simdiki.veri).ad[0])
                            {
                                simdiki = simdiki.sol;
                                break;
                            }
                            else
                            {
                                parentSol = false;
                                simdiki = simdiki.sag;
                                break;
                            }
                        }
                    }
                    else
                    {
                        parentSol = false;
                        simdiki = simdiki.sag;
                    }
                    if(simdiki==null)
                    {
                        return false;
                    }
                }
                ((kisi)simdiki.veri).egitimBilgisi = null;
                if(simdiki.sol==null&&simdiki.sag==null)
                {
                    if (simdiki == kok)
                        kok = null;
                    else if (parentSol)
                        ebeveyn.sol = null;
                    else
                        ebeveyn.sag = null;
                }
                else if(simdiki.sag==null)
                {
                    if (simdiki == kok)
                    {
                        kok = simdiki.sol;
                    }
                    else if (parentSol)
                        ebeveyn.sol = simdiki.sol;
                    else
                        ebeveyn.sag = simdiki.sol; 
                }
                else if(simdiki.sol==null)
                {
                    if (simdiki == kok)
                        kok = simdiki.sag;
                    else if (parentSol)
                        ebeveyn.sol = simdiki.sag;
                    else
                        ebeveyn.sag = simdiki.sag;
                }
                else
                {
                    ikiliAramaAgacDugum araDugum = araDugumSilme(simdiki);
                    if (simdiki == kok)
                        kok = araDugum;
                    else if (parentSol)
                        ebeveyn.sol = araDugum;
                    else
                        ebeveyn.sag = araDugum;
                    araDugum.sol = simdiki.sol;
                }
                return true;
            }
        }

        private void dilKontrol(ikiliAramaAgacDugum dugum)
        {
            if (((kisi)dugum.veri).yDil1 == "İngilizce")
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            else if (((kisi)dugum.veri).yDil2 == "İngilizce")
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            else if (((kisi)dugum.veri).yDil3 == "İngilizce")
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
        }
        public void dilKontrolAra()
        {
            dugumler = "";
            dilKontrolAraInt(kok);
        }
        private void dilKontrolAraInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            dilKontrol(dugum);
            dilKontrolAraInt(dugum.sol);
            dilKontrolAraInt(dugum.sag);
        }



        public void lisansAra()
        {
            dugumler = "";
            lisansAraKontrolInt(kok);
        }
        private void lisansAraKontrol(ikiliAramaAgacDugum dugum)
        {
            if (((kisi)dugum.veri).okulTuru=="Lisans")
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }
            else if (((kisi)dugum.veri).okulTuru == "Yüksek Lisans")
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }
            else if (((kisi)dugum.veri).okulTuru == "Doktora")
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }
        }
        private void lisansAraKontrolInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            lisansAraKontrol(dugum);
            lisansAraKontrolInt(dugum.sol);
            lisansAraKontrolInt(dugum.sag);
        }



        private void birdenFazlaDilKontrol(ikiliAramaAgacDugum dugum)
        {
            if (((kisi)dugum.veri).yDil1 != "" && (((kisi)dugum.veri).yDil2 != "" || ((kisi)dugum.veri).yDil3 != ""))
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
        }
        public void birdenFazlaDilAra()
        {
            dugumler = "";
            birdenFazlaDilAraInt(kok);
        }
        private void birdenFazlaDilAraInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            birdenFazlaDilKontrol(dugum);
            birdenFazlaDilAraInt(dugum.sol);
            birdenFazlaDilAraInt(dugum.sag);
        }



        public void minimumDeneyimBul()
        {
            dugumler = "";
            minimumDeneyimBulInt(kok);
        }
        public string y;
        private void minimumDeneyimKontrol(ikiliAramaAgacDugum dugum)
        {
            Form1 f1 = new Form1();
            int a= int.Parse(((kisi)dugum.veri).isSuresi);

            if (a <= int.Parse(y))
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }
            
        }
        private void minimumDeneyimBulInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            minimumDeneyimKontrol(dugum);
            minimumDeneyimBulInt(dugum.sol);
            minimumDeneyimBulInt(dugum.sag);
        }
        public string z;
        public void yasAra()
        {
            dugumler = "";
            yasAraInt(kok);
        }
        private void yasAraInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            yasKontrol(dugum);
            yasAraInt(dugum.sol);
            yasAraInt(dugum.sag);
        }
        private void yasKontrol(ikiliAramaAgacDugum dugum)
        {
            int yas = 2020 -int.Parse(((kisi)dugum.veri).dTarihi);
            if(yas<=int.Parse(z))
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }

        }

        private void deneyimsizAraInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            deneyimsizAraKontrol(dugum);
            deneyimsizAraInt(dugum.sol);
            deneyimsizAraInt(dugum.sag);
        }
        public void deneyimsizAra()
        {
            dugumler = "";
            deneyimsizAraInt(kok);
        }
        private void deneyimsizAraKontrol(ikiliAramaAgacDugum dugum)
        {
            if (((kisi)dugum.veri).isSuresi == "0" )
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
        }
        public void ehliyetAra()
        {
            dugumler = "";
            ehliyetAraInt(kok);
        }
        private void ehliyetAraInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return;
            ehliyetAraKontrol(dugum);
            ehliyetAraInt(dugum.sol);
            ehliyetAraInt(dugum.sag);
        }
        public string x;
        private void ehliyetAraKontrol(ikiliAramaAgacDugum dugum)
        {
            
            if(((kisi)dugum.veri).ehliyet==x)
            {
                dugumler += ((kisi)dugum.veri).ad + Environment.NewLine;
            }
        }

       
        private int derinlikBulInt(ikiliAramaAgacDugum dugum)
        {
            if (dugum == null)
                return 0;
            else
            {
                int solYukseklik = 0, sagYukseklik = 0;
                solYukseklik = derinlikBulInt(dugum.sol); //Düğümün solu oldukça sola git
                sagYukseklik = derinlikBulInt(dugum.sag); //Düğümün sağı oldukça sağa git
                if (solYukseklik > sagYukseklik)
                    return solYukseklik + 1;
                else
                    return sagYukseklik + 1;
            }
        }

        public int derinlikBul()
        {
            return derinlikBulInt(kok);
        }


        public int elemanSayisi()
        {
            return elemanSayisiInt(kok);
        }
        private int elemanSayisiInt(ikiliAramaAgacDugum dugum)
        {
            int eS = 0;
            if (dugum != null)
            {
                eS = 1;
                eS += elemanSayisiInt(dugum.sol);
                eS += elemanSayisiInt(dugum.sag);
            }
            return eS;
        }
    }
}
