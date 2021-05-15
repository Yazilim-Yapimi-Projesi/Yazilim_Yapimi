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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader oku;
        private void Temizle()
        {
            txtTCLogin.Clear();
            txtSifreLogin.Clear();
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtTCLogin.Text==""||txtSifreLogin.Text=="")
            {
                MessageBox.Show("Lütfen İstenilen Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
                baglanti.Open();

                komut = new OleDbCommand();
                komut.CommandText = "select * from Users where User_TC_Number=@tc and Password=@sifre and UserTypeName=@usertypename";
                komut.Connection = baglanti;
                int userid=0;

                komut.Parameters.AddWithValue("@tc", txtTCLogin.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifreLogin.Text);

                if (rbtnAdmin.Checked == true)
                {
                    komut.Parameters.AddWithValue("@usertypename", "Admin");
                }
                else
                {
                    komut.Parameters.AddWithValue("@usertypename", "Kullanıcı");
                }

                
                oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    if (oku[1].ToString()=="Admin")
                    {
                        Form3 f3 = new Form3();
                        f3.tcProfil.Text = txtTCLogin.Text;
                        Form2 f2 = new Form2();
                        this.Hide();
                        f2.Show();
                    }
                    else
                    {
                        userid = Convert.ToInt32(oku[0]);
                        Form3 f3 = new Form3();
                        f3.tcProfil.Text = txtTCLogin.Text;
                        this.Hide();
                        f3.Show();
                    }  
                }
                else
                {
                    Temizle();
                    MessageBox.Show("Bilgileriniz Doğru Değil !!! \nLütfen Kullanıcı Tipini, Tc Kimlik Numaranızı ve Şifrenizi Doğru Girdiğinize Emin Olunuz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //komut = new OleDbCommand();
                //komut.CommandText = "select UserTypeName from UserTypes";
                //komut.Connection = baglanti;


            }
            
        }

        private void linkUyeKaydı_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ÜyeOl üye = new ÜyeOl();
            üye.Show();
        }
    }
}
