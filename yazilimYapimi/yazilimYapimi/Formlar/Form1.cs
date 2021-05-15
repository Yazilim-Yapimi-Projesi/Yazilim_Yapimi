using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazilimYapimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void linkUyeKaydı_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ÜyeOl üye = new ÜyeOl();
            üye.Show();
        }
        private void Temizle()
        {
            txtTCLogin.Clear();
            txtSifreLogin.Clear();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {

            Kullanıcı kullanıcı = new Kullanıcı(txtTCLogin.Text);

            if (txtTCLogin.Text == "" || txtSifreLogin.Text == "" ||(rbtnAdmin.Checked == false && rbtnKullanıcı.Checked == false) )
            {
                MessageBox.Show("Lütfen İstenilen Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (rbtnAdmin.Checked == true)
                {
                    kullanıcı.GirisYap(txtTCLogin.Text, txtSifreLogin.Text, "Admin", this);
                }
                else if (rbtnKullanıcı.Checked == true)
                {
                    kullanıcı.GirisYap(txtTCLogin.Text, txtSifreLogin.Text, "Kullanıcı", this);
                }

            }
            Temizle();
        }

       
    }
}
