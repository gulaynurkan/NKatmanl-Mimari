using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberi
{
    public partial class AnaForm : Form
    {
        BusinessLogicLayer.BLL bll;
        Guid ID;
        public AnaForm()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void ListeGoster()
        {
            dgw_telefonrehberi.DataSource = bll.KayitListeleView();
            dgw_telefonrehberi.Columns["ID"].Visible = false;


            List<Rehber> rehberlistesi = bll.KayitListele();
            if (rehberlistesi != null && rehberlistesi.Count > 0)
            {
                lst_telefonrehberi.DataSource = rehberlistesi;
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeGoster();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
           int donenveri=bll.KayitEkle(txt_ad.Text, txt_soyad.Text, txt_telefon1.Text, txt_telefon2.Text, txt_telefon3.Text, txt_email.Text, txt_web.Text, txt_adres.Text, txt_aciklama.Text);

            if (donenveri > 0)
            {
                MessageBox.Show("Yeni Kayıt eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
            else
                MessageBox.Show("Kayıt eklenemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
          int donendeger=bll.KayitDuzenle(ID,txt_ad.Text, txt_soyad.Text, txt_telefon1.Text, txt_telefon2.Text, txt_telefon3.Text, txt_email.Text, txt_web.Text, txt_adres.Text, txt_aciklama.Text);

            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
            else
                MessageBox.Show("Kayıt değiştirilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgw_telefonrehberi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = (Guid)dgw_telefonrehberi.CurrentRow.Cells[0].Value;
            txt_ad.Text = dgw_telefonrehberi.CurrentRow.Cells[1].Value.ToString();
            txt_soyad.Text = dgw_telefonrehberi.CurrentRow.Cells[2].Value.ToString();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            ID = ((Rehber)lst_telefonrehberi.SelectedItem).ID;
         //   BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int donendeger = bll.KayitSil(ID);
            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
        }
    }
}
