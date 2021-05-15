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
    public partial class ÜyeOl : Form
    {
        public ÜyeOl()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader oku;
        
        private void Temizle()
        {
            txtÜyeOlAd.Clear();
            txtÜyeOlSoyad.Clear();
            txtÜyeOlTC.Clear();
            txtÜyeOlTel.Clear();
            txtÜyeOlAdres.Clear();
            txtÜyeOlEmail.Clear();
            txtÜyeOlSifre.Clear();
            txtÜyeOlSifreTekrar.Clear();
        }
        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            if (txtÜyeOlSifre.Text==txtÜyeOlSifreTekrar.Text)
            {
                    baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
                    baglanti.Open();
                    string sqlkodu = "insert into Users([UserTypeName],[UserName],[UserSurname],[User_TC_Number],[TelNumber],[Address],[Email],[Password]) values (@usertypename,@UserName,@UserSurname,@User_TC_Number,@TelNumber,@Address,@Email,@Password)";
                    komut = new OleDbCommand(sqlkodu, baglanti);

                    komut.Parameters.AddWithValue("@usertypename", "Kullanıcı");
                    komut.Parameters.AddWithValue("@UserName", txtÜyeOlAd.Text);
                    komut.Parameters.AddWithValue("@UserSurname", txtÜyeOlSoyad.Text);
                    komut.Parameters.AddWithValue("@User_TC_Number", Convert.ToInt32(txtÜyeOlTC.Text));
                    komut.Parameters.AddWithValue("@TelNumber", Convert.ToInt32(txtÜyeOlTel.Text));
                    komut.Parameters.AddWithValue("@Address", txtÜyeOlAdres.Text);
                    komut.Parameters.AddWithValue("@Email", txtÜyeOlEmail.Text);
                    komut.Parameters.AddWithValue("@Password", txtÜyeOlSifre.Text);
                    oku = komut.ExecuteReader();

                sqlkodu = "insert into UserTypes(UserTypeName)Values(@usertype)";
                komut = new OleDbCommand(sqlkodu, baglanti);
                komut.Parameters.AddWithValue("@usertype", "Kullanıcı");
                
                baglanti.Close();
                    Temizle();

            }
            else
            {
                MessageBox.Show("Lütfen Şifre ve Şifre Tekrar Alanının Aynı Olduğundan Emin Olun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        
    }
}
