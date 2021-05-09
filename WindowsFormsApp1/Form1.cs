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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        kisi k = new kisi();
        kisiAgaci k1 = new kisiAgaci();
        egitim e1 = new egitim();
        bagliListeEgitim egitimList = new bagliListeEgitim();
        bagliListeIsDeneyimi deneyimList = new bagliListeIsDeneyimi();
        isDeneyimi is1 = new isDeneyimi();
        ikiliAramaAgacDugum d1 = new ikiliAramaAgacDugum();
        DataTable dt = new DataTable();
        private void btn_kapa_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_sekme_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            btngeri_isbasvuru.Visible = true;
            bunifubutonsirket.Visible = false;
            bunifubutonis.Visible = false;
            panel4.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            StreamReader elemanOku;
            elemanOku = File.OpenText(@"kisi.txt");
            string elemanYaz;
            while ((elemanYaz = elemanOku.ReadLine()) != null)
            {
                k = new kisi();
                e1 = new egitim();
                k.ad = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.dTarihi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.telefon = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.email = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.yDil1 = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.yDil2 = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.yDil3 = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.ehliyet = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.adres = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.okulTuru = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                e1.okulAdi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                e1.bolum = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                e1.baslangicTarihi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                e1.bitisTarihi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                e1.notOrt = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.isSuresi = elemanYaz;



                egitimList.dugumGiris(e1);
                k.egitimBilgisi = egitimList;

                elemanYaz = elemanOku.ReadLine();
                is1.isAdi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                is1.isAdresi = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                is1.isPozisyon = elemanYaz;
                elemanYaz = elemanOku.ReadLine();
                k.isSuresi = elemanYaz;

                deneyimList.dugumGiris(is1);
                k.deneyimBilgisi = deneyimList;

                k1.ekle(k);
                egitimList = new bagliListeEgitim();
                deneyimList = new bagliListeIsDeneyimi();
            }
            elemanOku.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "")
                MessageBox.Show("Kişi bilgilerini kontrol ediniz");
            else
            {
                string file = @"kisi.txt";
                k = new kisi();
                k.ad = txtAd.Text;
                k.telefon = txtTelefon.Text;
                k.email = txtEposta.Text;
                k.yDil1 = txtyDil1.Text;
                k.yDil2 = txtyDil2.Text;
                k.yDil3 = txtyDil3.Text;
                k.dTarihi = datePickerDTarihi.Text;
                k.ehliyet = cmbEhliyet.Text;
                k.adres = txtAdres.Text;
                k.okulTuru = cmbOkulTuru.Text;
                k.isSuresi = txtSure.Text;
                k.egitimBilgisi = egitimList;
                k.deneyimBilgisi = deneyimList;
                k1.ekle(k);
                StreamWriter sw = File.AppendText(file);
                sw.WriteLine(k.ad + "\n" + k.dTarihi + "\n" + k.telefon + "\n" + k.email + "\n" + txtyDil1.Text + "\n" + txtyDil2.Text + "\n" + txtyDil3.Text + "\n" + cmbEhliyet.Text + "\n" + k.adres + "\n" + k.okulTuru + k.egitimBilgisi.displayElements() + "\n" + k.deneyimBilgisi.displayElements() + "\n" + k.isSuresi);
                sw.Close();
                MessageBox.Show("Kişi eklendi.");
                txtIsyeriAdi.Text = txtPozisyon.Text = txtIsyeriAdres.Text = "";
                txtOkulAdi.Text = txtBolum.Text = txtBaslangicTarihi.Text = txtBitisTarihi.Text = txtNotOrt.Text = "";
                txtAd.Text = datePickerDTarihi.Text = txtTelefon.Text = txtEposta.Text = txtyDil1.Text = txtyDil2.Text = txtyDil3.Text = cmbEhliyet.Text = txtAdres.Text = txtSure.Text = cmbOkulTuru.Text = "";
                egitimList = new bagliListeEgitim();
                deneyimList = new bagliListeIsDeneyimi();
            }
        }

        private void btnOkulEkle_Click(object sender, EventArgs e)
        {
            if (txtOkulAdi.Text == "")
            {
                MessageBox.Show("Eğitim bilgilerini kontrol ediniz!");
            }
            else
            {
                k.okulTuru = cmbOkulTuru.Text;
                e1.okulAdi = txtOkulAdi.Text;
                e1.bolum = txtBolum.Text;
                e1.baslangicTarihi = txtBaslangicTarihi.Text;
                e1.bitisTarihi = txtBitisTarihi.Text;
                e1.notOrt = txtNotOrt.Text;
                egitimList.dugumGiris(e1);
                MessageBox.Show("Eğitim bilgileriniz başarıyla eklendi.");
                e1 = new egitim();
            }
        }

        private void btnIsEkle_Click(object sender, EventArgs e)
        {
            if (txtIsyeriAdi.Text == "")
            {
                MessageBox.Show("İş yeri bilgilerini kontrol ediniz!");
            }
            else
            {
                is1.isAdi = txtIsyeriAdi.Text;
                is1.isPozisyon = txtPozisyon.Text;
                is1.isAdresi = txtIsyeriAdres.Text;
                deneyimList.dugumGiris(is1);
                MessageBox.Show("İş bilgileriniz başarıyla eklendi.");

                is1 = new isDeneyimi();
            }
        }


        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            k1.preOrder();
            txtPreOrderListe.Text = k1.dugumYazdir();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
                MessageBox.Show("Arama yapmak için isim giriniz.");
            else
            {
                listBoxIs.Items.Clear();
                listBoxEgitim.Items.Clear();
                d1 = k1.ara(txtAra.Text);
                if (d1 == null)
                {
                    txtAra.Text = "";
                    MessageBox.Show("Kişi bilgileri bulunamadı.");
                }
                else
                {
                    k = ((kisi)d1.veri);
                    txtGunAd.Text = ((kisi)d1.veri).ad;
                    txtGunTelefon.Text = ((kisi)d1.veri).telefon;
                    txtGunEposta.Text = ((kisi)d1.veri).email;
                    pickerGunDogumTarihi.Text = k.dTarihi;

                    txtGunyDil1.Text = ((kisi)d1.veri).yDil1;
                    txtGunyDil2.Text = ((kisi)d1.veri).yDil2;
                    txtGunyDil3.Text = ((kisi)d1.veri).yDil3;
                    cmbGunEhliyet.Text = ((kisi)d1.veri).ehliyet;
                    txtGunAdres.Text = ((kisi)d1.veri).adres;
                    Dugum e2 = new Dugum();
                    e2 = ((kisi)d1.veri).egitimBilgisi.Head;
                    while (e2 != null)
                    {
                        listBoxEgitim.Items.Add(((egitim)e2.Data).okulAdi.ToString());
                        e2 = e2.Next;
                    }
                    Dugum e3 = new Dugum();
                    e3 = ((kisi)d1.veri).deneyimBilgisi.Head;
                    while (e3 != null)
                    {
                        listBoxIs.Items.Add(((isDeneyimi)e3.Data).isAdi.ToString());
                        e3 = e3.Next;
                    }
                    txtGunOkulAdi.Text = txtGunBolum.Text = txtGunBasTarih.Text = txtGunBitTarih.Text = txtGunNotOrtalamasi.Text = txtGunIsyeriAdi.Text = txtGunIsyeriAdres.Text = txtGunPozisyon.Text = "";
                }
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
                MessageBox.Show("Silinecek kişinin adını giriniz.");
            else
            {
                bool sil = k1.sil(k.ad);
                if (sil)
                {
                    MessageBox.Show("Kişi silme işlemi gerçekleştirildi.");
                    txtGunOkulAdi.Text = txtGunBolum.Text = pickerGunDogumTarihi.Text=txtGunBasTarih.Text = "";
                    txtGunBitTarih.Text = txtGunIsyeriAdi.Text = txtGunIsyeriAdres.Text = txtGunPozisyon.Text = "";
                    txtGunNotOrtalamasi.Text = txtAra.Text = txtGunAd.Text = txtGunAdres.Text = txtGunTelefon.Text = txtGunEposta.Text = "";
                    txtGunyDil1.Text = txtGunyDil2.Text = txtGunyDil3.Text = cmbGunEhliyet.Text = "";
                    listBoxEgitim.Items.Clear();
                    listBoxIs.Items.Clear();

                }
                else
                    MessageBox.Show("Aranan kişi sistemde bulunamadı.");

            }
        }

        private void btnEgitimBilGoster_Click(object sender, EventArgs e)
        {
            if (listBoxEgitim.SelectedItem == null)
                MessageBox.Show("Eğitim bilgisi seçilmedi.");
            else
            {
                Dugum e1 = new Dugum();
                e1 = ((kisi)d1.veri).egitimBilgisi.Head;

                while (((egitim)e1.Data).okulAdi != listBoxEgitim.SelectedItem.ToString())
                    e1 = e1.Next;
                txtGunOkulAdi.Text = ((egitim)e1.Data).okulAdi;
                txtGunBolum.Text = ((egitim)e1.Data).bolum;
                txtGunBasTarih.Text = ((egitim)e1.Data).baslangicTarihi.ToString();
                txtGunBitTarih.Text = ((egitim)e1.Data).bitisTarihi.ToString();
                txtGunNotOrtalamasi.Text = ((egitim)e1.Data).notOrt.ToString();
            }
        }

        private void btnGunEgitimEkle_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "" || k1.ara(txtAra.Text) == null)
                MessageBox.Show("Bilgisi güncellenecek olan kişinin araması yapılmalı.");
            else
            {
                if (txtGunOkulAdi.Text == "")
                    MessageBox.Show("Eğitim bilgisi giriniz.");
                else
                {
                    e1.okulAdi = txtGunOkulAdi.Text;
                    e1.bolum = txtGunBolum.Text;
                    e1.baslangicTarihi = txtGunBasTarih.Text;
                    e1.bitisTarihi = txtGunBitTarih.Text;
                    e1.notOrt = txtGunNotOrtalamasi.Text;

                    ((kisi)d1.veri).egitimBilgisi.dugumGiris(e1);
                    MessageBox.Show("Eğitim bilgileri eklendi.");
                    txtGunOkulAdi.Text = txtGunBolum.Text = txtGunBasTarih.Text = txtGunBitTarih.Text = txtGunNotOrtalamasi.Text = "";
                    e1 = new egitim();
                }

            }
        }

        private void btnGunEgitimIleri_Click(object sender, EventArgs e)
        {
            if (listBoxEgitim.SelectedItem == null)
                MessageBox.Show("Güncellenecek eğitim bilgisi seçilmedi.");
            else
            {
                Dugum egitimBilgisi = new Dugum();
                egitimBilgisi = ((kisi)d1.veri).egitimBilgisi.Head;

                while (true)
                {
                    if (((egitim)egitimBilgisi.Data).okulAdi == listBoxEgitim.SelectedItem.ToString())
                    {
                        ((egitim)egitimBilgisi.Data).okulAdi = txtGunOkulAdi.Text;
                        ((egitim)egitimBilgisi.Data).bolum = txtGunBolum.Text;
                        ((egitim)egitimBilgisi.Data).baslangicTarihi = txtGunBasTarih.Text;
                        ((egitim)egitimBilgisi.Data).bitisTarihi = txtGunBitTarih.Text;
                        ((egitim)egitimBilgisi.Data).notOrt = txtGunNotOrtalamasi.Text;
                        MessageBox.Show("Eğitim bilgisi güncellendi.");
                        break;
                    }
                    else
                        egitimBilgisi = egitimBilgisi.Next;
                }
            }
        }


        Dugum isDeneyimi = new Dugum();
        private void btnIsBilGoster_Click(object sender, EventArgs e)
        {
            try

            {
                if (listBoxIs.SelectedIndex == null)
                    MessageBox.Show("Lütfen listboxtan seçim yapınız!!!");
                else
                {
                    try
                    {
                        isDeneyimi = ((kisi)d1.veri).deneyimBilgisi.Head;
                    }
                    catch(Exception hata)
                    {
                        
                    }

                    //Listbox'da seçilmiş olan iş bilgisi iş adına göre bulundu
                    while (((isDeneyimi)isDeneyimi.Data).isAdi != listBoxIs.SelectedItem.ToString())
                        isDeneyimi = isDeneyimi.Next;

                    //bulunan iş bilgileri listelendi
                    txtGunIsyeriAdi.Text = ((isDeneyimi)isDeneyimi.Data).isAdi;
                    txtGunIsyeriAdres.Text = ((isDeneyimi)isDeneyimi.Data).isAdresi;
                    txtGunPozisyon.Text = ((isDeneyimi)isDeneyimi.Data).isPozisyon;

                }
            }
            catch(Exception hata)
            {

            }
        }

        private void btnGunIsBilEkle_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "" || k1.ara(txtAra.Text) == null)
                MessageBox.Show("Bilgisi eklenecek olan kişinin araması yapılmalı.");
            else
            {
                if (txtGunIsyeriAdi.Text == "")
                    MessageBox.Show("İşyeri bilgisi giriniz.");
                else
                {
                    is1.isAdi = txtGunIsyeriAdi.Text;
                    is1.isAdresi = txtGunIsyeriAdres.Text;
                    is1.isPozisyon =txtGunPozisyon.Text;
                
                    

                    ((kisi)d1.veri).deneyimBilgisi.dugumGiris(is1);
                    MessageBox.Show("İşyeri bilgileri eklendi.");
                    txtGunIsyeriAdi.Text = txtGunIsyeriAdres.Text = txtGunPozisyon.Text = "";
                    is1 = new isDeneyimi();
                }

            }
        }

        private void btnGunIsBilgisi_Click(object sender, EventArgs e)
        {
            if (listBoxIs.SelectedItem == null)
                MessageBox.Show("Güncellenecek işyeri bilgisi seçilmedi.");
            else
            {
                Dugum is5 = new Dugum();
                is5 = ((kisi)d1.veri).deneyimBilgisi.Head;

                while (true)
                {
                    if (((isDeneyimi)is5.Data).isAdi == listBoxIs.SelectedItem.ToString())
                    {
                        ((isDeneyimi)is5.Data).isAdi = txtGunIsyeriAdi.Text;
                        ((isDeneyimi)is5.Data).isAdresi = txtGunIsyeriAdres.Text;
                        ((isDeneyimi)is5.Data).isPozisyon = txtGunPozisyon.Text;
                        MessageBox.Show("İşyeri bilgisi güncellendi.");
                        break;
                    }
                    else
                        is5 = is5.Next;
                }
            }
        }

        private void btnInOrder_Click(object sender, EventArgs e)
        {
            k1.inOrder();
            txtInOrderListe.Text = k1.dugumYazdir();
        }

        private void btnPostOrder_Click(object sender, EventArgs e)
        {
            k1.postOrder();
            txtPostOrderListe.Text = k1.dugumYazdir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGunAd.Text == "")
                MessageBox.Show("Önce güncellenecek kişiyi bulun.");
            else
            {
                //Güncel kişi bilgileri(Guncelleme işlemindeki textboxlardan) kişi ağacından bulunan kişinin bilgilerine gönderildi
                k.ad = txtGunAd.Text;
                k.telefon = txtGunTelefon.Text;
                k.email = txtGunEposta.Text;
                k.ehliyet = cmbGunEhliyet.Text;
                k.yDil1 = txtGunyDil1.Text;
                k.yDil2 = txtGunyDil2.Text;
                k.yDil3 = txtGunyDil3.Text;
                k.dTarihi = pickerGunDogumTarihi.Text;
                k.adres = txtGunAdres.Text;

                MessageBox.Show("Güncelleme işlemi başarılı.");

                //Güncelleme işlemi tamamlandıktan sonra yeni güncelleme işlemine hazırlamak için textboxlar ve listboxlar temizlendi
                txtGunOkulAdi.Text = txtGunBolum.Text = txtGunBasTarih.Text =cmbGunEhliyet.Text=pickerGunDogumTarihi.Text= txtGunBitTarih.Text =cmbEhliyet.Text= txtGunIsyeriAdi.Text = txtGunIsyeriAdres.Text = txtGunPozisyon.Text = txtGunNotOrtalamasi.Text = txtAra.Text = txtGunAd.Text = txtGunAdres.Text = txtGunTelefon.Text = txtGunEposta.Text = txtGunyDil1.Text = txtGunyDil2.Text = txtGunyDil3.Text = "";
              

                listBoxEgitim.Items.Clear();
                listBoxIs.Items.Clear();
                k = new kisi(); // yeni güncelleme işlemi için kişi bilgisi new'lendi
            }

        }

        private void btnBasvuruYap_Click(object sender, EventArgs e)
        {
            if(listBoxIlanlar.SelectedIndex==null)
            {
                MessageBox.Show("İlan seçiniz.");
            }
            else
            {
                d1 = k1.ara(txtBasvuruAdSoyad.Text);
                if(d1==null)
                {
                    MessageBox.Show("Başvuru yapacak kişinin kayıt bilgileri bulunamadı.");
                }
                else
                {
                    string file = @"basvurular.txt";
                    StreamWriter sw = File.AppendText(file);
                    sw.WriteLine(txtBasvuruAdSoyad.Text + "/" + txtIlanAdi.Text + "/" + ((kisi)d1.veri).telefon + "/" + ((kisi)d1.veri).email + "/" + k.dTarihi + "/" + ((kisi)d1.veri).yDil1 + "/" + ((kisi)d1.veri).yDil2 + "/" + ((kisi)d1.veri).yDil3 + "/" + ((kisi)d1.veri).ehliyet + "/" + ((kisi)d1.veri).adres);
                    sw.Close();
                    MessageBox.Show("Başvurunuz tamamlandı.");
                }
            }
        }

        private void listBoxIlanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxIlanlar.SelectedIndex>=0)
            {
                txtIlanAdi.Text = listBoxIlanlar.SelectedItem.ToString();
            }
        }

        private void btnBasvurGoster_Click(object sender, EventArgs e)
        {
            listBoxBasvuru.Items.Clear();
            StreamReader oku;
            oku = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "\\basvurular.txt");
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                listBoxBasvuru.Items.Add(yazi.ToString());
            }
            oku.Close();

        }
        private void btnTextKaydet_Click(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            d1 = k1.ara(txtKaydet.Text);
            if (d1 == null)
            {
                MessageBox.Show("Kişi bilgileri bulunamadı.");
            }
            else
            {
                
                k = ((kisi)d1.veri);
                txtGunAd.Text = ((kisi)d1.veri).ad;
                txtGunTelefon.Text = ((kisi)d1.veri).telefon;
                txtGunEposta.Text = ((kisi)d1.veri).email;
                pickerGunDogumTarihi.Text = k.dTarihi;

                txtGunyDil2.Text = ((kisi)d1.veri).yDil1;
                txtGunyDil1.Text = ((kisi)d1.veri).yDil2;
                txtGunyDil3.Text = ((kisi)d1.veri).yDil3;

                cmbGunEhliyet.Text = ((kisi)d1.veri).ehliyet;
                txtGunAdres.Text = ((kisi)d1.veri).adres;
                bagliListeEgitim e2 = new bagliListeEgitim();
                k.egitimBilgisi.displayElements();
                k.deneyimBilgisi.displayElements();

                saveFileDialog1.Filter = "TXT Dosyalar|*.txt";
                saveFileDialog1.Title = "Kaydetmek için seçin";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = File.AppendText(saveFileDialog1.FileName);
                    sw.WriteLine("Adı:" + (k.ad + "\n" + "Doğum Tarihi:" + k.dTarihi + "\n" + "Telefon No:" + k.telefon + "\n" + "E-mail:" + k.email + "\n" + "Yabancı Dil:" + k.yDil1 + "\n" + "2.Yabancı Dil:" + k.yDil2 + "\n" + "3.Yabancı Dil:" + k.yDil3 + "\n" + "Ehliyet:" + k.ehliyet + "\n" + "Adres:" + k.adres + "\n" + "\n" + "Eğitim Bilgisi"+ "\n"+ k.okulTuru+ k.egitimBilgisi.displayElements() + "\n" + "\n" + "Deneyim Bilgisi \n" + k.deneyimBilgisi.displayElements()+ "\n" +k.isSuresi));

                    sw.Close();
                    txtGunAd.Text = txtGunTelefon.Text = txtGunEposta.Text = pickerGunDogumTarihi.Text = txtGunyDil2.Text = txtGunyDil1.Text = txtGunyDil3.Text = cmbGunEhliyet.Text = txtGunAdres.Text = "";

                }
                else
                {
                    MessageBox.Show("Lütfen Dosya Yolunu Seçin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
                    
        private void btnIngilizceBilenler_Click(object sender, EventArgs e)
        {
            txtListe.Text = "";
            k1.dilKontrolAra();
            txtListe.Text = k1.dugumYazdir();
        }

        private void btnBirdenfazladil_Click(object sender, EventArgs e)
        {
            txtListe.Text = "";
            k1.birdenFazlaDilAra();
            txtListe.Text = k1.dugumYazdir();
        }

        private void btnDerinlikBul_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Derinlik : " + k1.derinlikBul().ToString());
        }

        private void btnElemanSayisiBul_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eleman Sayısı : " + k1.elemanSayisi().ToString());
        }

        private void btnMinimumdeneyim_Click(object sender, EventArgs e)
        {
            if (txtMinimumDeneyim.Text =="")
            {
                MessageBox.Show("Deneyim giriniz!!!");
            }
            else
            {
                k1.y = txtMinimumDeneyim.Text;
                txtListe.Text = "";
                k1.minimumDeneyimBul();
                txtListe.Text = k1.dugumYazdir();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnLisansagöre_Click(object sender, EventArgs e)
        {
            txtListe.Text = "";
            k1.lisansAra();
            txtListe.Text = k1.dugumYazdir();
        }

        private void btnDeneyimsiz_Click(object sender, EventArgs e)
        {
            txtListe.Text = "";
            k1.deneyimsizAra();
            txtListe.Text = k1.dugumYazdir();
        }

        private void btnehliyetsirala_Click(object sender, EventArgs e)
        {
            if (cmbEhliyet2.Text == "")
            {
                MessageBox.Show("Ehliyet seçiniz!!");
            }
            else
            {
                k1.x = cmbEhliyet2.Text;
                txtListe.Text = "";
                k1.ehliyetAra();
                txtListe.Text = k1.dugumYazdir();
            }
        }

        private void btnAdsirala_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Arama yapmak için isim giriniz.");
            else
            {
                listBox1.Items.Clear();
                d1 = k1.ara(textBox1.Text);
                if (d1 == null)
                {
                    textBox1.Text = "";
                    MessageBox.Show("Kişi bilgileri bulunamadı.");
                }
                else
                {
                    k = ((kisi)d1.veri);
                    txtGunAd.Text = ((kisi)d1.veri).ad;
                    listBox1.Items.Add(txtGunAd.Text);
                    txtGunTelefon.Text = ((kisi)d1.veri).telefon;
                    listBox1.Items.Add(txtGunTelefon.Text);
                    txtGunEposta.Text = ((kisi)d1.veri).email;
                    listBox1.Items.Add(txtGunEposta.Text);
                    pickerGunDogumTarihi.Text = k.dTarihi;
                    listBox1.Items.Add(pickerGunDogumTarihi.Text);
                    txtGunyDil1.Text = ((kisi)d1.veri).yDil1;
                    listBox1.Items.Add(txtGunyDil1.Text);
                    txtGunyDil2.Text = ((kisi)d1.veri).yDil2;
                    listBox1.Items.Add(txtGunyDil2.Text);
                    txtGunyDil3.Text = ((kisi)d1.veri).yDil3;
                    listBox1.Items.Add(txtGunyDil3.Text);
                    cmbGunEhliyet.Text = ((kisi)d1.veri).ehliyet;
                    listBox1.Items.Add(cmbGunEhliyet.Text);
                    txtGunAdres.Text = ((kisi)d1.veri).adres;
                    listBox1.Items.Add(txtGunAdres.Text);
                    
                    pickerGunDogumTarihi.Text=txtGunyDil3.Text = txtGunyDil2.Text = txtGunyDil1.Text=cmbGunEhliyet.Text=txtGunEposta.Text=txtGunTelefon.Text =txtGunAdres.Text=txtGunAd.Text=txtGunOkulAdi.Text = txtGunBolum.Text = txtGunBasTarih.Text = txtGunBitTarih.Text = txtGunNotOrtalamasi.Text = txtGunIsyeriAdi.Text = txtGunIsyeriAdres.Text = txtGunPozisyon.Text = "";
                }
            }
        }

        private void btnYas_Click(object sender, EventArgs e)
        {
            if (txtYasaGore.Text == "")
            {
                MessageBox.Show("Yaş değerini giriniz.");
            }
            else
            {
                k1.z = txtYasaGore.Text;
                txtListe.Text = "";
                k1.yasAra();
                txtListe.Text = k1.dugumYazdir();
            }
        }

        private void btngeri_isbasvuru_Click(object sender, EventArgs e)
        {
            bunifubutonis.Visible = true;
            bunifubutonsirket.Visible = true;
            btngeri_isbasvuru.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;

        }

        private void bunifubutonsirket_Click(object sender, EventArgs e)
        {
            btngeri_isbasvuru.Visible = true;
            bunifubutonis.Visible = false;
            bunifubutonsirket.Visible = false;
            panel2.Visible = true;
        }
    }
}
