
namespace yazilimYapimi
{
    partial class FormAdmin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnUrunTalep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParaTalep = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnParaOnay = new System.Windows.Forms.Button();
            this.ParaOnayDGV = new System.Windows.Forms.DataGridView();
            this.panelUrun = new System.Windows.Forms.Panel();
            this.btn_UrunOnay = new System.Windows.Forms.Button();
            this.UrunOnayDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaOnayDGV)).BeginInit();
            this.panelUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunOnayDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnUrunTalep);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnParaTalep);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 727);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::yazilimYapimi.Properties.Resources.trading;
            this.pictureBox3.Location = new System.Drawing.Point(20, 549);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(84, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::yazilimYapimi.Properties.Resources.cash;
            this.pictureBox2.Location = new System.Drawing.Point(21, 442);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btnUrunTalep
            // 
            this.btnUrunTalep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUrunTalep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUrunTalep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunTalep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrunTalep.ForeColor = System.Drawing.Color.White;
            this.btnUrunTalep.Location = new System.Drawing.Point(97, 549);
            this.btnUrunTalep.Margin = new System.Windows.Forms.Padding(4);
            this.btnUrunTalep.Name = "btnUrunTalep";
            this.btnUrunTalep.Size = new System.Drawing.Size(252, 64);
            this.btnUrunTalep.TabIndex = 3;
            this.btnUrunTalep.Text = "Ürün Talepleri";
            this.btnUrunTalep.UseVisualStyleBackColor = false;
            this.btnUrunTalep.Click += new System.EventHandler(this.btnUrunTalep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "İşlemler";
            // 
            // btnParaTalep
            // 
            this.btnParaTalep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnParaTalep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnParaTalep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParaTalep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParaTalep.ForeColor = System.Drawing.Color.White;
            this.btnParaTalep.Location = new System.Drawing.Point(99, 442);
            this.btnParaTalep.Margin = new System.Windows.Forms.Padding(4);
            this.btnParaTalep.Name = "btnParaTalep";
            this.btnParaTalep.Size = new System.Drawing.Size(252, 64);
            this.btnParaTalep.TabIndex = 1;
            this.btnParaTalep.Text = "Para Talepleri";
            this.btnParaTalep.UseVisualStyleBackColor = false;
            this.btnParaTalep.Click += new System.EventHandler(this.btnParaTalep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::yazilimYapimi.Properties.Resources._20_256x256;
            this.pictureBox1.Location = new System.Drawing.Point(97, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(351, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1195, 37);
            this.panel2.TabIndex = 2;
            // 
            // btnParaOnay
            // 
            this.btnParaOnay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnParaOnay.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnParaOnay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParaOnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParaOnay.ForeColor = System.Drawing.Color.White;
            this.btnParaOnay.Location = new System.Drawing.Point(380, 506);
            this.btnParaOnay.Margin = new System.Windows.Forms.Padding(4);
            this.btnParaOnay.Name = "btnParaOnay";
            this.btnParaOnay.Size = new System.Drawing.Size(312, 78);
            this.btnParaOnay.TabIndex = 6;
            this.btnParaOnay.Text = "Onay Ver";
            this.btnParaOnay.UseVisualStyleBackColor = false;
            this.btnParaOnay.Click += new System.EventHandler(this.btnParaOnay_Click);
            // 
            // ParaOnayDGV
            // 
            this.ParaOnayDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ParaOnayDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParaOnayDGV.Location = new System.Drawing.Point(361, 43);
            this.ParaOnayDGV.Margin = new System.Windows.Forms.Padding(4);
            this.ParaOnayDGV.Name = "ParaOnayDGV";
            this.ParaOnayDGV.RowHeadersWidth = 51;
            this.ParaOnayDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParaOnayDGV.Size = new System.Drawing.Size(1051, 417);
            this.ParaOnayDGV.TabIndex = 24;
            this.ParaOnayDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParaOnayDGV_CellContentClick);
            // 
            // panelUrun
            // 
            this.panelUrun.Controls.Add(this.btn_UrunOnay);
            this.panelUrun.Controls.Add(this.UrunOnayDGV);
            this.panelUrun.Location = new System.Drawing.Point(351, 27);
            this.panelUrun.Name = "panelUrun";
            this.panelUrun.Size = new System.Drawing.Size(1195, 700);
            this.panelUrun.TabIndex = 28;
            // 
            // btn_UrunOnay
            // 
            this.btn_UrunOnay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_UrunOnay.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_UrunOnay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UrunOnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UrunOnay.ForeColor = System.Drawing.Color.White;
            this.btn_UrunOnay.Location = new System.Drawing.Point(67, 459);
            this.btn_UrunOnay.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UrunOnay.Name = "btn_UrunOnay";
            this.btn_UrunOnay.Size = new System.Drawing.Size(312, 78);
            this.btn_UrunOnay.TabIndex = 27;
            this.btn_UrunOnay.Text = "Onay Ver";
            this.btn_UrunOnay.UseVisualStyleBackColor = false;
            this.btn_UrunOnay.Click += new System.EventHandler(this.btn_UrunOnay_Click);
            // 
            // UrunOnayDGV
            // 
            this.UrunOnayDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UrunOnayDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UrunOnayDGV.Location = new System.Drawing.Point(15, 10);
            this.UrunOnayDGV.Margin = new System.Windows.Forms.Padding(4);
            this.UrunOnayDGV.Name = "UrunOnayDGV";
            this.UrunOnayDGV.RowHeadersWidth = 51;
            this.UrunOnayDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UrunOnayDGV.Size = new System.Drawing.Size(1066, 424);
            this.UrunOnayDGV.TabIndex = 25;
            this.UrunOnayDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrunOnayDGV_CellContentClick);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 727);
            this.Controls.Add(this.panelUrun);
            this.Controls.Add(this.ParaOnayDGV);
            this.Controls.Add(this.btnParaOnay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Kontrol Ekranı";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParaOnayDGV)).EndInit();
            this.panelUrun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UrunOnayDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnParaTalep;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnUrunTalep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnParaOnay;
        public System.Windows.Forms.DataGridView ParaOnayDGV;
        private System.Windows.Forms.Panel panelUrun;
        public System.Windows.Forms.DataGridView UrunOnayDGV;
        private System.Windows.Forms.Button btn_UrunOnay;
    }
}