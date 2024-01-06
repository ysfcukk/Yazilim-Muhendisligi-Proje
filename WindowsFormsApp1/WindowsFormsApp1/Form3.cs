using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sayac = 0;
            timer1.Start();
            timer1.Interval = 4000;
            label5.Text = "Toplam " + Settings1.Default.toplamTutar.ToString("0.00") + " ₺";
        }
        int sayac = 0;
        DialogResult dr;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac == 0)
            {
                label5.Visible = false;
                label1.Visible = false;
                label2.Visible = true;
                pictureBox1.Image = Properties.Resources.dots;
            }
            else if (sayac == 1)
            {
                label2.Visible = false;
                label3.Visible = true;
                pictureBox1.Image = Properties.Resources.tick;
            }
            else if (sayac == 2)
            {
                label3.Visible = false;
                pictureBox1.Image = null;
                timer1.Stop();
                string fis = Settings1.Default.fatura + "\nToplam Tutar : " + Settings1.Default.toplamTutar.ToString();
                dr = MessageBox.Show(fis + "\n\nFişi Yazdırmak İstiyor Musunuz?", "Fiş", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    label4.Visible = true;
                    pictureBox1.Image = Properties.Resources.receipt;
                }
                else
                {
                    label4.Visible = false;
                    label6.Visible = true;
                    pictureBox1.Image = Properties.Resources.shop;
                }
                timer1.Start();
            }
            else if (sayac == 3)
            {
                if (dr == DialogResult.Yes)
                {
                    label4.Visible = false;
                    label6.Visible = true;
                    pictureBox1.Image = Properties.Resources.shop;
                }
                else
                {
                    label6.Visible = false;
                    label7.Visible = true;
                    pictureBox1.Image = Properties.Resources.hand;
                }
            }
            else if(dr == DialogResult.Yes && sayac == 4)
            {
                label6.Visible = false;
                label7.Visible = true;
                pictureBox1.Image = Properties.Resources.hand;
            }
            else
            {
                Settings1.Default.musteri = "";
                Settings1.Default.isClick = false;
                Settings1.Default.toplamTutar = 0.0;
                Settings1.Default.fatura = "";
                this.Close();
            }
            sayac++;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
