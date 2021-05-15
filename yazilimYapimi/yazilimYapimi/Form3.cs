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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti; 
        OleDbCommand islem;
        OleDbDataReader oku;
        DataTable tablo = new DataTable();
        DataSet ds=new DataSet();
        
        int toplam = 0;
        bool deger;
        int paraAlacakKisiID = 0;
        int paraVerecekKisiID = 0;
        int aktarılacakParaMiktarı = 0;
        private void PazarListele()
        {
            
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            tablo = new DataTable();
            islem = new OleDbCommand("select ItemName,ItemKg,ItemAmount from UserItems where (UserID <> @userid) and (ItemName=@itemname) and (ItemRequest=true) and (ItemForSale=true) order by ItemAmount", baglanti);
            islem.Parameters.AddWithValue("@userid",UserIdLabel.Text);
            islem.Parameters.AddWithValue("@itemname",urunTipiBuy.SelectedItem);
            OleDbDataAdapter adp = new OleDbDataAdapter(islem);
            adp.Fill(tablo);
            pazarDGV.DataSource = tablo;
            this.pazarDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //dataGridView'ın boyutlarına göre tabloların boyutlarını ayarlama
            baglanti.Close();
        }
        
        private void listele()
        {             
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            tablo = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter("select ItemName,ItemKg,ItemAmount from UserItems where ItemRequest=true and ItemForSale=false", baglanti);
            adp.Fill(tablo);
            denemeDGV.DataSource = tablo;
            this.denemeDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //dataGridView'ın boyutlarına göre tabloların boyutlarını ayarlama
            baglanti.Close();
        }
        private void ürünlistele()
        {

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            tablo = new DataTable();
            islem = new OleDbCommand("select ItemName,ItemKg,ItemAmount from UserItems where (UserID=@userid) and (ItemRequest=true) and (ItemForSale=false)", baglanti);
            islem.Parameters.AddWithValue("@userid", UserIdLabel.Text);
            OleDbDataAdapter adp = new OleDbDataAdapter(islem);
            adp.Fill(tablo);
            profilDGV.DataSource = tablo;
            ürünlerimDGV.DataSource = tablo;           
            this.profilDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //dataGridView'ın boyutlarına göre tabloların boyutlarını ayarlama
            this.ürünlerimDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            baglanti.Close();

        }
        private void pazardakiUrünlerimiListele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            tablo = new DataTable();
            islem = new OleDbCommand("select ItemName,ItemKg,ItemAmount from UserItems where (UserID=@userid) and (ItemRequest=true) and (ItemForSale=true)", baglanti);
            //3 sorgu aynı anda oluyormu

            islem.Parameters.AddWithValue("@userid", UserIdLabel.Text);
            OleDbDataAdapter adp = new OleDbDataAdapter(islem);
            adp.Fill(tablo);
            denemeDGV.DataSource = tablo;
            this.denemeDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            baglanti.Close();
        }
        private void ProfilBilgileri()
        {
            Form1 f1 = new Form1();
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select UserName,UserSurname,User_TC_Number,TelNumber,Address,Email,Password,UserID from Users where User_TC_Number =@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", tcProfil.Text);
            // 123 yerine giriş ekranındaki kullanıcı adını yazılacak

            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                adProfil.Text = oku[0].ToString();
                soyadProfil.Text = oku[1].ToString();
                tcProfil.Text = oku[2].ToString();
                telefonProfil.Text = oku[3].ToString();
                adresProfil.Text = oku[4].ToString();
                emailProfil.Text = oku[5].ToString();
                sifreProfil.Text = oku[6].ToString();
                UserIdLabel.Text = oku[7].ToString();
            }
            baglanti.Close();

        }
        private void Para()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select MoneyAmount from Moneys where UserID=@id",baglanti);
            komut.Parameters.AddWithValue("@id", UserIdLabel.Text);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                paraLabel.Text = oku[0].ToString();
            }
            baglanti.Close();
        }
        private void alimYapButon_Click(object sender, EventArgs e)
        {
            AlımPanel.Visible = true;
            ürünPanel.Visible = false;
            profilimPanel.Visible = false;
            ParaYatirPanel.Visible = false;
        }
        private void ÜrünSatButon_Click(object sender, EventArgs e)
        {
            ürünPanel.Visible = true;
            AlımPanel.Visible = false;
            ParaYatirPanel.Visible = false;
            profilimPanel.Visible = false;
        }
        private void ParaYatirButon_Click(object sender, EventArgs e)
        {
            ParaYatirPanel.Visible = true;
            AlımPanel.Visible = false;
            ürünPanel.Visible = false;
            profilimPanel.Visible = false;
        }

        private void ProfilimButon_Click(object sender, EventArgs e)
        {
            profilimPanel.Visible = true;
            ParaYatirPanel.Visible = false;
            AlımPanel.Visible = false;
            ürünPanel.Visible = false;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ProfilBilgileri();
            Para();           
            ürünlistele();
            pazardakiUrünlerimiListele();
            PazarListele();
            
        }
        void tekrarkontrol() 
        {
            baglanti.Open();
            string sqlkodu = "select * from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount) and (ItemRequest=@itemrequest) and (ItemForSale=@itemforsale)";
            islem = new OleDbCommand(sqlkodu,baglanti);

            islem.Parameters.AddWithValue("@userid",UserIdLabel.Text);
            islem.Parameters.AddWithValue("@itemname", UrunTipiSell.SelectedItem);
            islem.Parameters.AddWithValue("@itemamount", FiyatSell.Text);
            islem.Parameters.AddWithValue("@itemrequest", true);
            oku = islem.ExecuteReader();
            
            if (oku.Read())
            {
                toplam =Convert.ToInt32(oku[3]);
                sqlkodu = "delete from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount)";
                islem = new OleDbCommand(sqlkodu, baglanti);
                islem.Parameters.AddWithValue("@userid", UserIdLabel.Text);
                islem.Parameters.AddWithValue("@itemname", UrunTipiSell.SelectedItem);
                islem.Parameters.AddWithValue("@itemamount", FiyatSell.Text);
                islem.ExecuteNonQuery();
            }
            baglanti.Close();
        }
        private void satisEmriOlusturBTN_Click(object sender, EventArgs e)
        {
           
            tekrarkontrol();
            baglanti.Open();
            string sqlkodu = "insert into UserItems(UserID,ItemName,ItemKg,ItemAmount,ItemRequest,ItemForSale) values (@UserID,@ItemName,@ItemKg,@ItemAmount,@ItemRequest,@ItemForSale)";
            islem = new OleDbCommand(sqlkodu, baglanti);

            islem.Parameters.AddWithValue("@UserID", UserIdLabel.Text);
            islem.Parameters.AddWithValue("@ItemName", UrunTipiSell.SelectedItem);
            islem.Parameters.AddWithValue("@ItemKg", Convert.ToInt32(UrunMiktariSell.Text) + toplam);
            islem.Parameters.AddWithValue("@ItemName", FiyatSell.Text);
            islem.Parameters.AddWithValue("@ItemRequest", false);
            islem.Parameters.AddWithValue("@ItemForSale", true);

            if (islem.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Ürün Talebiniz Oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürün Talebi Oluşturulurken Hata Oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
            tablo.Clear();
            listele();
            ürünlistele();
            pazardakiUrünlerimiListele();
        }
        private void profilGuncelleBTN_Click(object sender, EventArgs e)
        {
            
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Bilgileri Güncelleme İşlemi Yaptırmak Üzeresiniz \n Devam Etmek İstiyormusunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                baglanti.Open();
                string sqlkodu = "update Users set [UserName]=@username,[UserSurname]=@usersurname,[User_TC_Number]=@usertcnumber,[TelNumber]=@telnumber,[Address]=@address,[Email]=@email,[Password]=@password where UserID=@userid";
                islem = new OleDbCommand(sqlkodu, baglanti);

                islem.Parameters.AddWithValue("@username", adProfil.Text);
                islem.Parameters.AddWithValue("@usersurname", soyadProfil.Text);
                islem.Parameters.AddWithValue("@usertcnumber", tcProfil.Text);
                islem.Parameters.AddWithValue("@telnumber", telefonProfil.Text);
                islem.Parameters.AddWithValue("@address", adresProfil.Text);
                islem.Parameters.AddWithValue("@email", emailProfil.Text);
                islem.Parameters.AddWithValue("@password", sifreProfil.Text);
                islem.Parameters.AddWithValue("@userid", UserIdLabel.Text);

                if (islem.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Bilgileriniz Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bilgiler Güncellenirken Hata Oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            else
            {
                baglanti.Close();
            }
        }

        private void ürünlerimDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seç = ürünlerimDGV.CurrentRow.Index;

            UrunTipiSell.SelectedItem = ürünlerimDGV.Rows[seç].Cells[0].Value.ToString();
            UrunMiktariSell.Text = ürünlerimDGV.Rows[seç].Cells[1].Value.ToString();
            FiyatSell.Text = ürünlerimDGV.Rows[seç].Cells[2].Value.ToString();
            
            ürünlistele();
        }

        private void urunTipiBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            PazarListele();
        }

        private void pazarDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seç = pazarDGV.CurrentRow.Index;

            urunTipiBuy.SelectedItem = pazarDGV.Rows[seç].Cells[0].Value.ToString();
            urunMiktariBuy.Text = pazarDGV.Rows[seç].Cells[1].Value.ToString();
            fiyatBuy.Text = pazarDGV.Rows[seç].Cells[2].Value.ToString();

            PazarListele();
        }

        private void alisEmriOlusturBTN_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sqlkodu = "select * from UserItems where (ItemName=@itemname) and (ItemKg=@itemkg) and (ItemRequest=@itemrequest) and (ItemForSale=@itemforsale)";
            islem = new OleDbCommand(sqlkodu, baglanti);
            aktarılacakParaMiktarı = Convert.ToInt32(fiyatBuy.Text);
            islem.Parameters.AddWithValue("@itemname", urunTipiBuy.SelectedItem);
            islem.Parameters.AddWithValue("@itemkg", urunMiktariBuy.Text);
            islem.Parameters.AddWithValue("@itemrequest", true);
            islem.Parameters.AddWithValue("@itemforsale", true);
            oku = islem.ExecuteReader();

            if (oku.Read())
            {
                paraAlacakKisiID = Convert.ToInt16(oku[1]);
                if (Convert.ToInt32(oku[4]) > Convert.ToInt32(paraLabel.Text))
                {
                    MessageBox.Show("Yeterli Bütçeniz Yoktur", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sqlkodu = "update UserItems set [UserID]=@userid,[ItemRequest]=@itemrequest,[ItemForSale]=@itemforsale where UserItems=@useritems";
                    islem = new OleDbCommand(sqlkodu, baglanti);

                    paraVerecekKisiID = Convert.ToInt32(UserIdLabel.Text);
                    islem.Parameters.AddWithValue("@userid", UserIdLabel.Text);
                    islem.Parameters.AddWithValue("@itemrequest", false);
                    islem.Parameters.AddWithValue("@itemforsale", false);
                    islem.Parameters.AddWithValue("@useritems", oku[0]);
                    islem.ExecuteNonQuery();
                }

            }
            baglanti.Close();
            tablo.Clear();
            paraEkleme();
            paraCikarma();
            listele();
            ürünlistele();
            pazardakiUrünlerimiListele();
            PazarListele();
            
        }
        private void paraEkleme()
        {
            baglanti.Open();
            string sqlkodu = "select * from Moneys where UserID=@userid";
            islem = new OleDbCommand(sqlkodu, baglanti);

            islem.Parameters.AddWithValue("@userid", paraAlacakKisiID); 
            oku = islem.ExecuteReader();

            if (oku.Read())
            {
                paraAlacakKisiID = Convert.ToInt16(oku[1]);
                sqlkodu = "update Moneys set [MoneyAmount]=@moneyamount where UserID=@userid";
                islem = new OleDbCommand(sqlkodu, baglanti);

                islem.Parameters.AddWithValue("@moneyamount", Convert.ToInt32(oku[2])+aktarılacakParaMiktarı);
                islem.Parameters.AddWithValue("@userid", paraAlacakKisiID);
                islem.ExecuteNonQuery(); 
            }
            baglanti.Close();
        }
        private void paraCikarma()
        {
            baglanti.Open();
            string sqlkodu = "select * from Moneys where UserID=@userid";
            islem = new OleDbCommand(sqlkodu, baglanti);

            islem.Parameters.AddWithValue("@userid", paraVerecekKisiID);
            oku = islem.ExecuteReader();
            if (oku.Read())
            {
                paraAlacakKisiID = Convert.ToInt16(oku[1]);
                sqlkodu = "update Moneys set [MoneyAmount]=@moneyamount where UserID=@userid";
                islem = new OleDbCommand(sqlkodu, baglanti);

                islem.Parameters.AddWithValue("@moneyamount", Convert.ToInt32(oku[2]) - aktarılacakParaMiktarı);
                islem.Parameters.AddWithValue("@userid", paraVerecekKisiID);
                islem.ExecuteNonQuery();
            }
            baglanti.Close();
        }
        
    }
}
