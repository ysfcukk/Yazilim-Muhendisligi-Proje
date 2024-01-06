namespace WindowsFormsApp1
{
    partial class urun
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ad = new System.Windows.Forms.Label();
            this.Bf = new System.Windows.Forms.Label();
            this.Tf = new System.Windows.Forms.Label();
            this.Adet = new System.Windows.Forms.Label();
            this.Marka = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ad
            // 
            this.Ad.BackColor = System.Drawing.SystemColors.Control;
            this.Ad.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Ad.Location = new System.Drawing.Point(88, 4);
            this.Ad.Name = "Ad";
            this.Ad.Size = new System.Drawing.Size(223, 23);
            this.Ad.TabIndex = 0;
            this.Ad.Text = "Urun Adi";
            this.Ad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ad.Click += new System.EventHandler(this.urun_Click);
            // 
            // Bf
            // 
            this.Bf.BackColor = System.Drawing.SystemColors.Control;
            this.Bf.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bf.Location = new System.Drawing.Point(383, 4);
            this.Bf.Name = "Bf";
            this.Bf.Size = new System.Drawing.Size(60, 23);
            this.Bf.TabIndex = 1;
            this.Bf.Text = "birim f.";
            this.Bf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Bf.Click += new System.EventHandler(this.urun_Click);
            // 
            // Tf
            // 
            this.Tf.BackColor = System.Drawing.SystemColors.Control;
            this.Tf.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tf.Location = new System.Drawing.Point(449, 4);
            this.Tf.Name = "Tf";
            this.Tf.Size = new System.Drawing.Size(60, 23);
            this.Tf.TabIndex = 2;
            this.Tf.Text = "toplam f.";
            this.Tf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tf.Click += new System.EventHandler(this.urun_Click);
            // 
            // Adet
            // 
            this.Adet.BackColor = System.Drawing.SystemColors.Control;
            this.Adet.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Adet.Location = new System.Drawing.Point(317, 4);
            this.Adet.Name = "Adet";
            this.Adet.Size = new System.Drawing.Size(60, 23);
            this.Adet.TabIndex = 3;
            this.Adet.Text = "adet";
            this.Adet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Adet.Click += new System.EventHandler(this.urun_Click);
            // 
            // Marka
            // 
            this.Marka.BackColor = System.Drawing.SystemColors.Control;
            this.Marka.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Marka.Location = new System.Drawing.Point(3, 4);
            this.Marka.Name = "Marka";
            this.Marka.Size = new System.Drawing.Size(79, 23);
            this.Marka.TabIndex = 4;
            this.Marka.Text = "Marka";
            this.Marka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Marka.Click += new System.EventHandler(this.urun_Click);
            // 
            // urun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.Marka);
            this.Controls.Add(this.Adet);
            this.Controls.Add(this.Tf);
            this.Controls.Add(this.Bf);
            this.Controls.Add(this.Ad);
            this.Name = "urun";
            this.Size = new System.Drawing.Size(512, 30);
            this.Click += new System.EventHandler(this.urun_Click);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label Ad;
        private System.Windows.Forms.Label Bf;
        private System.Windows.Forms.Label Tf;
        private System.Windows.Forms.Label Adet;
        private System.Windows.Forms.Label Marka;
    }
}
