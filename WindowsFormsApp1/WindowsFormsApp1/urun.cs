using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class urun : UserControl
    {
        public urun()
        {
            InitializeComponent();
        }

        private string _brand;
        private string _productName;
        private string _piece;
        private string _unitPrice;
        private string _totalPrice;

        //[Category("Custom Props")]
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; Marka.Text = value; }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; Ad.Text = value; }
        }
        public string Piece
        {
            get { return _piece; }
            set { _piece = value; Adet.Text = value; }
        }
        public string UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; Bf.Text = value; }
        }
        public string TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; Tf.Text = value; }
        }

        public void BaslikYap()
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ((Label)ctrl).BackColor = Color.Silver;
                    ((Label)ctrl).Click -= urun_Click;
                }
            }
            this.Click -= urun_Click;
        }

        private void urun_Click(object sender, EventArgs e)
        {
            if(this.BackColor==Color.LightSteelBlue)
            {
                this.BackColor = SystemColors.ControlLight;
                Settings1.Default.isClick = false;
            }
            else
            {
                if (Settings1.Default.isClick)
                {
                    MessageBox.Show("1 adet ürün seçebilirsiniz");
                }
                else
                {
                    this.BackColor = Color.LightSteelBlue;
                    Settings1.Default.isClick = true;
                }
            }
                
        }
    }
}
