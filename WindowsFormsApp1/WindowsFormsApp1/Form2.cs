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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        SqlConnection con;

        private string MusteriBul(string num)
        {
            con.Open();
            string comn = "select * from musteri where musteri_tel_no = '" + num + "'";
            SqlCommand command = new SqlCommand(comn, con);
            SqlDataReader reader = command.ExecuteReader();
            
            bool result = reader.Read();
            string musteri = null;
            if (result) musteri = reader["musteri_adi"].ToString();
            
            con.Close();
            reader.Close();
            return musteri;
        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            
            string number = textBox1.Text;
            number = number.Substring(1, number.Length-1);

            if (number.Length != 10)
            {
                MessageBox.Show("Eksik Numara Girisi");
            }
            else
            {
                string musteri = MusteriBul(number);
                if (musteri != null)
                {
                    Settings1.Default.musteri = musteri;
                    AlisverisEkrani form = new AlisverisEkrani();
                    textBox1.Text = "0";
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Musteri Bulunamadı");
                }
            }


        }

        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 10)
            {
                Button button = (Button)sender;
                textBox1.Text += button.Text;
            }

        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            AlisverisEkrani form = new AlisverisEkrani();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            string connection = "Data Source=" + Settings1.Default.server_name + ";Initial Catalog=SelfServisKasa;Integrated Security=True";
            con = new SqlConnection(connection);
            Settings1.Default.musteri = "";
            Settings1.Default.isClick = false;
            Settings1.Default.toplamTutar = 0.0;
            Settings1.Default.fatura = "";
        }
    }
}
