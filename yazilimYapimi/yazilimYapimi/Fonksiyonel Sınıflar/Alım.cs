using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class Alım
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;
       public Alım(string UserID, string ItemName, string OrderAmount, string MoneyAmount)
        {
            this.AlımYap( UserID, ItemName, OrderAmount, MoneyAmount);
        }


        public bool AlımYap(string UserID, string ItemName, string OrderAmount, string MoneyAmount)
        {
            Boolean AlımIslemıGerceklesebilir_mi = this.AlımGerceklesebilirmi(UserID, ItemName, OrderAmount, MoneyAmount);
            Boolean AlımIslemiYapıldı_mı = false;
            string AlıcıID = UserID;
            string IstenenUrun = ItemName;
            int IstenenMıktarbas = Convert.ToInt32(OrderAmount);

            int IstenenMıktar = Convert.ToInt32(OrderAmount);
            int Butce = Convert.ToInt32(MoneyAmount);
            int ToplamMaliyet = 0;
            double AlınanMalınBirimFiyatı = 0;



            baglanti.Open();
            // Alım islemi gerçekleşebilcekse
            if (AlımIslemıGerceklesebilir_mi)
            {
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    string Satilik_UrunID = oku[0].ToString();
                    string SaticiID = oku[1].ToString();
                    string Satilik_UrunAdı = oku[2].ToString();
                    int Satilik_UrunMiktari = Convert.ToInt32(oku[3]);
                    int Satilik_UrunBirimFiyatı = Convert.ToInt32(oku[4]);
                    Boolean Satilik_UrunOnayı = Convert.ToBoolean(oku[5]);
                    Boolean Urun_Satilik_mi = Convert.ToBoolean(oku[6]);



                    // Önce isterler Alım yapmaya uygun mu ona bakılır. Butce yetecek mi ve istenen miktar pazarda var mı onlar kontro edilir.
                    if (AlımIslemiYapıldı_mı == false && SaticiID != AlıcıID && Satilik_UrunAdı == IstenenUrun && Satilik_UrunOnayı && Urun_Satilik_mi
                        /* Alım işlemi henüzu ygun değilken; bizim haricimizdeki bir kullanıcıda istediğimiz urun varsa, miktarına bakılır.*/)
                    {




                        if (IstenenMıktar <= Satilik_UrunMiktari
                           /* Satılık urunun miktarı istediğimiz kadar veya daha fazlası ise maliyetine bakılır.*/)
                        {


                            if (IstenenMıktar * Satilik_UrunBirimFiyatı <= Butce
                               /*  Satıcıdadan alacağımız ürünün maliyeti Butcemize eşit veya küçük ise  */ )
                            {
                                ToplamMaliyet += (IstenenMıktar * Satilik_UrunBirimFiyatı);

                                // Satıcıya parasını gönder 
                                EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
                                IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Para");
                                ekle.Ekle(SaticiID, "", "", "", false, false, ToplamMaliyet.ToString(), true);

                                sqlkodu = "delete from UserItems where (ItemID=@itemid)";
                                komut = new OleDbCommand(sqlkodu, baglanti);

                                komut.Parameters.AddWithValue("@itemid", Satilik_UrunID);
                                komut.ExecuteNonQuery();

                                if (Satilik_UrunMiktari - IstenenMıktar > 0)
                                {
                                    sqlkodu = "insert into UserItems(UserID,ItemName,ItemKg,ItemAmount,ItemRequest,ItemForSale) values (@UserID,@ItemName,@ItemKg,@ItemAmount,@ItemRequest,@ItemForSale)";
                                    komut = new OleDbCommand(sqlkodu, baglanti);

                                    komut.Parameters.AddWithValue("@UserID", SaticiID);
                                    komut.Parameters.AddWithValue("@ItemName", Satilik_UrunAdı);
                                    komut.Parameters.AddWithValue("@ItemKg", Satilik_UrunMiktari - IstenenMıktar);
                                    komut.Parameters.AddWithValue("@ItemAmount", Satilik_UrunBirimFiyatı);
                                    komut.Parameters.AddWithValue("@ItemRequest", true);
                                    komut.Parameters.AddWithValue("@ItemForSale", true);
                                    komut.ExecuteNonQuery();
                                }



                                IstenenMıktar = 0;
                            }


                            else;  // Para yetmiyorsa geç


                        }


                        else if (IstenenMıktar > Satilik_UrunMiktari
                            /* Bu satılık ürünün miktarı istediğimiz kadar değilse, mevcut satıcıdan alınabilecek miktar için maliyete bakılır. */)
                        {

                            if (Satilik_UrunMiktari * Satilik_UrunBirimFiyatı <= Butce
                                /* ve Satıcıdaki tüm ürünün maliyeti Butcemize eşit veya küçük ise*/)
                            {
                                ToplamMaliyet += Satilik_UrunMiktari * Satilik_UrunBirimFiyatı;
                                IstenenMıktar -= Satilik_UrunMiktari;

                                // Satıcıya parasını gönder 
                                EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
                                IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Para");
                                ekle.Ekle(SaticiID, "", "", "", false, false, ToplamMaliyet.ToString(), true);


                                sqlkodu = "delete from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount) and (ItemRequest=@itemrequest) and (ItemForSale=@ıtemforsale)";
                                komut = new OleDbCommand(sqlkodu, baglanti);

                                komut.Parameters.AddWithValue("@userid", SaticiID);
                                komut.Parameters.AddWithValue("@itemname", Satilik_UrunAdı);
                                komut.Parameters.AddWithValue("@itemamount", Satilik_UrunBirimFiyatı);
                                komut.Parameters.AddWithValue("@itemrequest", true);
                                komut.Parameters.AddWithValue("@itemforsale", true);
                                komut.ExecuteNonQuery();
                            }


                            else; // Para yetmiyorsa geç


                        }




                        if (IstenenMıktar == 0 && ToplamMaliyet <= Butce)
                        {
                            AlımIslemiYapıldı_mı = true;
                            AlınanMalınBirimFiyatı = Math.Round(Convert.ToDouble(ToplamMaliyet) / Convert.ToDouble(IstenenMıktarbas), 2);

                            EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
                            IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Urun");
                            ekle.Ekle(AlıcıID, IstenenUrun, IstenenMıktarbas.ToString(), AlınanMalınBirimFiyatı.ToString(), false, false, "", false);
                            MessageBox.Show("" + IstenenUrun + " ürününden ortalama birim fiyatı " + AlınanMalınBirimFiyatı + " olmak üzere " + IstenenMıktarbas + "Kg Alım islemi gerçekleştirilmiştir!");




                            int ToplamPara = 0;
                            OleDbCommand getir = new OleDbCommand("select MoneyAmount from Moneys where MoneyRequest= true and UserID=@userid", baglanti);
                            getir.Parameters.AddWithValue("@userid", AlıcıID);
                            oku = getir.ExecuteReader();
                            while (oku.Read())
                            {
                                ToplamPara += Convert.ToInt32(oku[0]);
                            }

                            sqlkodu = "Delete from Moneys where MoneyRequest= true and UserID=@userid";
                            komut = new OleDbCommand(sqlkodu, baglanti);
                            komut.Parameters.AddWithValue("@userid", AlıcıID);
                            komut.ExecuteNonQuery();

                            sqlkodu = "insert into Moneys(UserID,MoneyAmount,MoneyRequest) values (@UserID,@MoneyAmount,@MoneyRequest)";
                            komut = new OleDbCommand(sqlkodu, baglanti);

                            komut.Parameters.AddWithValue("@UserID", AlıcıID);
                            komut.Parameters.AddWithValue("@MoneyAmount", (ToplamPara - ToplamMaliyet));
                            komut.Parameters.AddWithValue("@MoneyRequest", true);
                            komut.ExecuteNonQuery();




                        }

                    }

                }
            }
            baglanti.Close();

            return true;
        }



        private Boolean AlımGerceklesebilirmi(string UserID, string ItemName, string OrderAmount, string MoneyAmount)
        {
            Boolean AlımIslemıGerceklesebilir_mi = false;
            string AlıcıID = UserID;
            string IstenenUrun = ItemName;
            int IstenenMıktar = Convert.ToInt32(OrderAmount);
            int Butce = Convert.ToInt32(MoneyAmount);
            int ToplamMaliyet = 0;



            baglanti.Open();

            // En düşük birimfiyattan en yüksek olanına doğru satılık urunler listelenir
            string sqlkodu = "Select * from UserItems ORDER by ItemAmount";
            komut = new OleDbCommand(sqlkodu, baglanti);


            // Sıralanmış satılık urunler sırayla okunur-kontrol edilir-
            // Alım Yapilabilirlik kontrol edilir.
            oku = komut.ExecuteReader();
            while (oku.Read()) // Sırayla satılık urunler geezilir
            {
                string SaticiID = oku[1].ToString();
                string Satilik_UrunAdı = oku[2].ToString();
                int Satilik_UrunMiktari = Convert.ToInt32(oku[3]);
                int Satilik_UrunBirimFiyatı = Convert.ToInt32(oku[4]);
                Boolean Satilik_UrunOnayı = Convert.ToBoolean(oku[5]);
                Boolean Urun_Satilik_mi = Convert.ToBoolean(oku[6]);


                // Önce isterler Alım yapmaya uygun mu ona bakılır. Butce yetecek mi ve istenen miktar pazarda var mı onlar kontro edilir.
                if (AlımIslemıGerceklesebilir_mi == false && SaticiID != AlıcıID && Satilik_UrunAdı == IstenenUrun && Satilik_UrunOnayı && Urun_Satilik_mi
                    /* Alım işlemi henüzu ygun değilken; bizim haricimizdeki bir kullanıcıda istediğimiz urun varsa, miktarına bakılır.*/)
                {

                    if (IstenenMıktar <= Satilik_UrunMiktari
                       /* Satılık urunun miktarı istediğimiz kadar veya daha fazlası ise maliyetine bakılır.*/)
                    {


                        if (IstenenMıktar * Satilik_UrunBirimFiyatı <= Butce
                           /*  Satıcıdadan alacağımız ürünün maliyeti (miktarı çarpı birim fiyatı) Butcemize eşit veya küçük ise  */ )
                        {

                            ToplamMaliyet += IstenenMıktar * Satilik_UrunBirimFiyatı;
                            IstenenMıktar = 0;
                        }


                        else;  // Para yetmiyorsa geç


                    }


                    else if (IstenenMıktar > Satilik_UrunMiktari
                        /* Bu satılık ürünün miktarı istediğimiz kadar değilse, mevcut satıcıdan alınabilecek miktar için maliyete bakılır. */)
                    {

                        if (Satilik_UrunMiktari * Satilik_UrunBirimFiyatı <= Butce
                            /* ve Satıcıdaki tüm ürünün maliyeti Butcemize eşit veya küçük ise*/)
                        {
                            ToplamMaliyet += Satilik_UrunMiktari * Satilik_UrunBirimFiyatı;
                            IstenenMıktar -= Satilik_UrunMiktari; // Alınabilen alınır. istenen miktar aldığımız kadar düşürülür

                        }


                        else; // Para yetmiyorsa geç


                    }


                    if (IstenenMıktar == 0 && ToplamMaliyet <= Butce)
                    {
                        AlımIslemıGerceklesebilir_mi = true;

                    }


                }

            }
            baglanti.Close();

            if (!AlımIslemıGerceklesebilir_mi)
                MessageBox.Show("Sipariş Tamamlanamadı!");
            return AlımIslemıGerceklesebilir_mi;
        }



    }
}
