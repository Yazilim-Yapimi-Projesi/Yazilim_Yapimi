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
    public partial class Form2 : Form
    {
        string UserID;
        string MoneyID;
        string ItemID;
        string ItemName;
        string ItemAmount;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Paraİsteklistele();
            UrunistekListele();
        }

        #region Listelemeler
        private void Paraİsteklistele()
        {
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("ParaOnayListesi");
            ParaOnayDGV.DataSource = liste.Listele(UserID,false,false);

        }
        private void UrunistekListele()
        {
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("UrunOnayListesi");
            UrunOnayDGV.DataSource = liste.Listele(this.UserID, false, false);

        }
        #endregion

        #region Dgv tıklama
        private void ParaOnayDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserID = ParaOnayDGV.CurrentRow.Cells[0].Value.ToString();
            MoneyID = ParaOnayDGV.CurrentRow.Cells[1].Value.ToString();
            label_isimPara.Text = ParaOnayDGV.CurrentRow.Cells[1].Value.ToString();
        }
        private void UrunOnayDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserID = UrunOnayDGV.CurrentRow.Cells[0].Value.ToString();
            ItemID = UrunOnayDGV.CurrentRow.Cells[1].Value.ToString();
            ItemName = UrunOnayDGV.CurrentRow.Cells[2].Value.ToString();
            ItemAmount = UrunOnayDGV.CurrentRow.Cells[4].Value.ToString();
            MessageBox.Show("userıd "+UserID+" ıtemıd "+ItemID+" ıtemname "+ItemName+" ıtemamount "+ ItemAmount+"");
        }

        #endregion

        #region Panel gösterme
        private void btnUrunTalep_Click(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            UrunistekListele();

        }
        private void btnParaTalep_Click(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            Paraİsteklistele();
        }
        #endregion

        #region Onaylama
        private void btn_UrunOnay_Click(object sender, EventArgs e)
        {
            OnayFabrikası onayFabrikası = new OnayFabrikası();
            IOnay onay = onayFabrikası.OnaylamaNesnesiOlustur("UrunOnay");
            onay.Onayla(UserID, ItemName ,ItemAmount ,ItemID, MoneyID);

            UrunistekListele();
        }
        private void btn_ParaOnay_Click(object sender, EventArgs e)
        {
            OnayFabrikası onayFabrikası = new OnayFabrikası();
            IOnay onay = onayFabrikası.OnaylamaNesnesiOlustur("ParaOnay");
            onay.Onayla(UserID, ItemName, ItemAmount, ItemID, MoneyID);
            Paraİsteklistele();
        }


        #endregion

    }
}
