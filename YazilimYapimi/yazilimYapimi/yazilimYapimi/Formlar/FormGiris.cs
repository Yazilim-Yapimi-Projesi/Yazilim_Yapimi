using System;
using System.Windows.Forms;

namespace yazilimYapimi
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }



        private void linkUyeKaydı_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Uye olma işlemi
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
                // Kullancı tipine göre giriş yapma işlemi
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

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
