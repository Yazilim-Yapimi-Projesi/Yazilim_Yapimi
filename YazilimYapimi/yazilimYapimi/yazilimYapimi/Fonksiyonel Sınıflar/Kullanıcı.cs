using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class Kullanıcı
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;

        private string Ad;
        private string Soyad;
        private string Tc;
        private string Tel;
        private string Adress;
        private string Email;
        private string Sifre;
        private string UserID="";
        private string Para;


        public Kullanıcı()
        {

        }

        public Kullanıcı(string tc)
        {
            // tc'si gönderilen kullanıcının bilgileri okunur.

            baglanti.Open();
            string sqlkodu = "select UserName,UserSurname,User_TC_Number,TelNumber,Address,Email,Password,UserID from Users where User_TC_Number =@tc";
            komut = new OleDbCommand(sqlkodu,baglanti);
            komut.Parameters.AddWithValue("@tc", tc);

            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Ad = oku[0].ToString();
                Soyad= oku[1].ToString();
                Tc = oku[2].ToString();
                Tel = oku[3].ToString();
                Adress = oku[4].ToString();
                Email = oku[5].ToString();
                Sifre = oku[6].ToString();
                UserID = oku[7].ToString();
            }

            komut = new OleDbCommand("select MoneyAmount from Moneys where [UserID]=@id and MoneyRequest=true", baglanti);
            komut.Parameters.AddWithValue("@id", this.UserID);

            oku = komut.ExecuteReader();
            while (oku.Read()) 
            {
                Para = oku[0].ToString();
            }

            baglanti.Close();
        }


 
        public void GirisYap(string tc, string sifre, string KullanıcıTipi, FormGiris girisFormu)
        {
            // Girilen bilgilere ve kullanıcı tipine göre form açılır.

            baglanti.Open();
            string sqlkodu = "select * from Users where User_TC_Number=@tc and Password=@sifre and UserTypeName=@usertypename";
            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@tc", tc);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@usertypename", KullanıcıTipi);

            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                if (oku[1].ToString() == "Admin")
                {
                    FormAdmin frmAdmin = new FormAdmin();
                    frmAdmin.MuhasebePara = ParaGetir();
                    frmAdmin.Show();
                }
                else
                {
                    FormKullanici formKullanici = new FormKullanici();
                    formKullanici.tc = Tc;
                    formKullanici.Show();

                }
                girisFormu.Hide();
            }
            else
            {
                MessageBox.Show("Bilgileriniz Doğru Değil !!! \nLütfen Kullanıcı Tipini, Tc Kimlik Numaranızı ve Şifrenizi Doğru Girdiğinize Emin Olunuz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #region Kullanıcı Bilgileri Çağırma Fonksiyonları
        public string AdGetir()
        {
            return this.Ad;
        }
        public string SoyadGetir()
        {
            return this.Soyad;
        }
        public string TcGetir()
        {
            return this.Tc;
        }
        public string TelnoGetir()
        {
            return this.Tel;
        }
        public string AdresGetir()
        {
            return this.Adress;
        }
        public string EmailGetir()
        {
            return this.Email;
        }
        public string SifreGetir()
        {
            return this.Sifre;
        }
        public string UserIDGetir()
        {
            return this.UserID;
        }
        public string ParaGetir()
        {
            return this.Para;
        }
        #endregion


        public void UyeOl(string ad, string soyad, string tc, string tel, string adres, string email, string sifre)
        {
            // Yeni kullanıcı kaydı

            baglanti.Open();
            string sqlkodu = "insert into Users([UserTypeName],[UserName],[UserSurname],[User_TC_Number],[TelNumber],[Address],[Email],[Password]) values" +
                             " (@Usertypename,@UserName,@UserSurname,@User_TC_Number,@TelNumber,@Address,@Email,@Password)";


                   komut = new OleDbCommand(sqlkodu, baglanti);
                   komut.Parameters.AddWithValue("@Usertypename", "Kullanıcı");
                   komut.Parameters.AddWithValue("@UserName", ad);
                   komut.Parameters.AddWithValue("@UserSurname", soyad);
                   komut.Parameters.AddWithValue("@User_TC_Number", Convert.ToInt32(tc));
                   komut.Parameters.AddWithValue("@TelNumber", Convert.ToInt32(tel));
                   komut.Parameters.AddWithValue("@Address", adres);
                   komut.Parameters.AddWithValue("@Email", email);
                   komut.Parameters.AddWithValue("@Password", Convert.ToInt32(sifre));
                    if ( komut.ExecuteNonQuery()>0)
                    {
                        MessageBox.Show("Uye Kaydı Başarılı");
                    }


            baglanti.Close();

        }


        public void UyelikBilgileriGuncelle(string ad, string soyad, string tc, string tel, string adres, string email, string sifre, string userID)
        {

            // Uyelik bilgilerini güncelleme
            baglanti.Open();
            string sqlkodu = "update Users set [UserName]=@username,[UserSurname]=@usersurname,[User_TC_Number]=@usertcnumber,[TelNumber]=@telnumber,[Address]=@address,[Email]=@email,[Password]=@password where UserID=@userid";
            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@username", ad);
            komut.Parameters.AddWithValue("@usersurname", soyad);
            komut.Parameters.AddWithValue("@usertcnumber", tc);
            komut.Parameters.AddWithValue("@telnumber", tel);
            komut.Parameters.AddWithValue("@address", adres);
            komut.Parameters.AddWithValue("@email", email);
            komut.Parameters.AddWithValue("@password", sifre);
            komut.Parameters.AddWithValue("@userid", userID);

            if (komut.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Bilgileriniz Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bilgiler Güncellenirken Hata Oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
    }
}




               
