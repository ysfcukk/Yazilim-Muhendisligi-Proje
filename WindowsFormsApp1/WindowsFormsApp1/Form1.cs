using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AlisverisEkrani : Form
    {
        public AlisverisEkrani()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-5KDA4RG\\SQLEXPRESS;Initial Catalog=SelfServisKasa;Integrated Security=True");
            urun urun1 = new urun();
            urun1.BaslikYap();
            flowLayoutPanel1.Controls.Add(urun1);
            label4.Text = Settings1.Default.toplamTutar.ToString("0.00");
            if (Settings1.Default.musteri != "") label5.Text += " Sayın " + Settings1.Default.musteri;
        }
        bool isClicked = false;
        private void button_Click(object sender, EventArgs e)
        {
            if (!isClicked) isClicked = true;
            Button button = (Button)sender;

            if (adet)
            {
                if (textBox1.Text.Length == 2)
                {
                    MessageBox.Show("99'dan fazla ürün almak için lütfen kasa yetkilisiyle görüşün");
                }
                else
                {
                    textBox1.Text += button.Text;
                }
            }
            else
            {
                if (textBox2.Text.Length <= 10)
                {
                    textBox2.Text += button.Text;
                }
            }
        }
        SqlConnection con;
        private urun UrunGetir(string barkodGirdisi)
        {
            con.Open();
            string comn = "select * from Urunler where UrunID = " + barkodGirdisi;
            SqlCommand command = new SqlCommand(comn, con);
            SqlDataReader reader = command.ExecuteReader();

            urun urun = null;

            if (reader.Read())
            {
                urun = new urun();

                urun.ProductName = reader["UrunAdi"].ToString();
                urun.UnitPrice = reader["BirimFiyat"].ToString();

                reader.Close();

                comn = "select m.marka_adi from marka m join Urunler u ON m.marka_ID = u.urun_marka_id where u.UrunID = " + barkodGirdisi;
                command = new SqlCommand(comn, con);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    urun.Brand = reader["marka_adi"].ToString();
                }
            }
            con.Close();
            reader.Close();
            return urun;
        }

        bool agirlikOnay = true;

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen barkod giriniz ya da ürününüzü barkod okuyucuya okutunuz.");
            }
            else
            {
                string barkod = textBox2.Text;
                urun urun = UrunGetir(barkod);

                if (urun == null)
                {
                    MessageBox.Show("Urun Bulunamadi");
                }
                else
                {
                    agirlikOnay = false;

                    double birimFiyat = Convert.ToDouble(urun.UnitPrice);
                    int adet = Convert.ToInt16(textBox1.Text);
                    double toplamUrunFiyat = birimFiyat * adet;
                    urun.TotalPrice = toplamUrunFiyat.ToString();
                    urun.Piece = textBox1.Text;
                    flowLayoutPanel1.Controls.Add(urun);

                    Settings1.Default.toplamTutar += toplamUrunFiyat;
                    label4.Text = Settings1.Default.toplamTutar.ToString("0.00");

                    pictureBox1.Image = Properties.Resources.dots;
                    timer1.Interval = 3000;
                    timer1.Start();
                }

                isClicked = false;
                textBox1.Text = "1";
                textBox2.Text = "";

            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (adet)
            {
                if (textBox1.Text != "")
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (adet) textBox1.Text = "";
            else textBox2.Text = "";
        }

        private void FisOlustur()
        {
            string fis = "";
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is urun urun)
                {
                    if (urun.Brand != null)
                    {
                        string fatura = urun.Brand + " " + urun.ProductName + " x" + urun.Piece + " " + urun.TotalPrice;
                        Settings1.Default.fatura += fatura + "\n";
                    }
                }
            }
        }

        bool adet = true;

        private void button14_Click(object sender, EventArgs e)
        {
            if (Settings1.Default.toplamTutar > 0.0001)
            {
                if (agirlikOnay)
                {
                    FisOlustur();
                    Form3 form3 = new Form3();
                    form3.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Agirlik Onaylanmadi. Lutfen Urunleri Kontrol Ediniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Urun Ekleyiniz");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Settings1.Default.isClick)
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is urun urun)
                    {
                        if (urun.BackColor == Color.LightSteelBlue)
                        {
                            Settings1.Default.toplamTutar -= Convert.ToDouble(urun.TotalPrice);
                            label4.Text = Settings1.Default.toplamTutar.ToString("0.00");
                            flowLayoutPanel1.Controls.Remove(urun);
                            break;
                        }
                    }
                }
                Settings1.Default.isClick = false;
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            adet = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            adet = false;
        }

        private void AlisverisEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings1.Default.musteri = "";
            Settings1.Default.isClick = false;
            Settings1.Default.toplamTutar = 0.0;
            Settings1.Default.fatura = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Alışverişi İptal Etmek İstediğinize Emin Misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            pictureBox1.Image = Properties.Resources.tick;
            timer1.Stop();
            agirlikOnay = true;
        }
    }
}
