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
    public partial class ÜyeOl : Form
    {
        public ÜyeOl()
        {
            InitializeComponent();
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            if (txtÜyeOlSifre.Text == txtÜyeOlSifreTekrar.Text)
            {
                Kullanıcı kullanıcı = new Kullanıcı();
                kullanıcı.UyeOl(txtÜyeOlAd.Text, txtÜyeOlSoyad.Text, txtÜyeOlTC.Text, txtÜyeOlTel.Text, txtÜyeOlAdres.Text, txtÜyeOlEmail.Text, txtÜyeOlSifre.Text);
                KutularıTemizle();
            }
            else
            {
                MessageBox.Show("Lütfen Şifre ve Şifre Tekrar Alanının Aynı Olduğundan Emin Olun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }


        private void KutularıTemizle()
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

        private void ÜyeOl_Load(object sender, EventArgs e)
        {

        }
    }
}
