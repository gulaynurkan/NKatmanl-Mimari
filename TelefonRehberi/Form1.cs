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
    public partial class Form1 : Form
    {
        BusinessLogicLayer.BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void btn_Sistem_Giris_Click(object sender, EventArgs e)
        {
           int gelendeger=bll.SistemKontrol(txt_kullaniciad.Text, txt_KullanıcıSifre.Text);
            if (gelendeger > 0)
            {
                AnaForm af = new AnaForm();
                af.Show();
            }
           
            else
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girişi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
