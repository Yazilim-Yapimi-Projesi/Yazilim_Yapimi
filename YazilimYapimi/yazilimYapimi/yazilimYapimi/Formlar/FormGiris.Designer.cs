
namespace yazilimYapimi
{
    partial class FormGiris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkUyeKaydı = new System.Windows.Forms.LinkLabel();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.txtSifreLogin = new System.Windows.Forms.TextBox();
            this.txtTCLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnKullanıcı = new System.Windows.Forms.RadioButton();
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.pnlRenk = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlRenk.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkUyeKaydı
            // 
            this.linkUyeKaydı.BackColor = System.Drawing.Color.Transparent;
            this.linkUyeKaydı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkUyeKaydı.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkUyeKaydı.Location = new System.Drawing.Point(119, 368);
            this.linkUyeKaydı.Name = "linkUyeKaydı";
            this.linkUyeKaydı.Size = new System.Drawing.Size(268, 32);
            this.linkUyeKaydı.TabIndex = 5;
            this.linkUyeKaydı.TabStop = true;
            this.linkUyeKaydı.Text = "Üye Olmak için Tıklayınız";
            this.linkUyeKaydı.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUyeKaydı_LinkClicked);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGirisYap.ForeColor = System.Drawing.Color.White;
            this.btnGirisYap.Location = new System.Drawing.Point(92, 310);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(330, 37);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // txtSifreLogin
            // 
            this.txtSifreLogin.Location = new System.Drawing.Point(92, 158);
            this.txtSifreLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifreLogin.Multiline = true;
            this.txtSifreLogin.Name = "txtSifreLogin";
            this.txtSifreLogin.Size = new System.Drawing.Size(330, 25);
            this.txtSifreLogin.TabIndex = 3;
            // 
            // txtTCLogin
            // 
            this.txtTCLogin.Location = new System.Drawing.Point(92, 233);
            this.txtTCLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTCLogin.Multiline = true;
            this.txtTCLogin.Name = "txtTCLogin";
            this.txtTCLogin.Size = new System.Drawing.Size(330, 25);
            this.txtTCLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(87, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(87, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tc Kimlik No :";
            // 
            // rbtnKullanıcı
            // 
            this.rbtnKullanıcı.AutoSize = true;
            this.rbtnKullanıcı.BackColor = System.Drawing.Color.Transparent;
            this.rbtnKullanıcı.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnKullanıcı.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnKullanıcı.Location = new System.Drawing.Point(143, 268);
            this.rbtnKullanıcı.Name = "rbtnKullanıcı";
            this.rbtnKullanıcı.Size = new System.Drawing.Size(108, 24);
            this.rbtnKullanıcı.TabIndex = 1;
            this.rbtnKullanıcı.TabStop = true;
            this.rbtnKullanıcı.Text = "Kullanıcı ";
            this.rbtnKullanıcı.UseVisualStyleBackColor = false;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnAdmin.Location = new System.Drawing.Point(269, 268);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(88, 24);
            this.rbtnAdmin.TabIndex = 2;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Admin ";
            this.rbtnAdmin.UseVisualStyleBackColor = false;
            // 
            // pnlRenk
            // 
            this.pnlRenk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlRenk.Controls.Add(this.label3);
            this.pnlRenk.Location = new System.Drawing.Point(0, 0);
            this.pnlRenk.Name = "pnlRenk";
            this.pnlRenk.Size = new System.Drawing.Size(506, 50);
            this.pnlRenk.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Borsa Alım Satım Sistemleri";
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(508, 427);
            this.Controls.Add(this.pnlRenk);
            this.Controls.Add(this.linkUyeKaydı);
            this.Controls.Add(this.rbtnAdmin);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.rbtnKullanıcı);
            this.Controls.Add(this.txtSifreLogin);
            this.Controls.Add(this.txtTCLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormGiris_Load);
            this.pnlRenk.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkUyeKaydı;
        private System.Windows.Forms.RadioButton rbtnKullanıcı;
        private System.Windows.Forms.RadioButton rbtnAdmin;
        public System.Windows.Forms.TextBox txtTCLogin;
        public System.Windows.Forms.TextBox txtSifreLogin;
        private System.Windows.Forms.Panel pnlRenk;
        private System.Windows.Forms.Label label3;
    }
}

