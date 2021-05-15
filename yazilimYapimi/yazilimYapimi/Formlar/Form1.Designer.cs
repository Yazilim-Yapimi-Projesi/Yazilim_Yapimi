
namespace yazilimYapimi
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // linkUyeKaydı
            // 
            this.linkUyeKaydı.AutoSize = true;
            this.linkUyeKaydı.BackColor = System.Drawing.Color.Transparent;
            this.linkUyeKaydı.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Bold);
            this.linkUyeKaydı.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkUyeKaydı.Location = new System.Drawing.Point(46, 255);
            this.linkUyeKaydı.Name = "linkUyeKaydı";
            this.linkUyeKaydı.Size = new System.Drawing.Size(235, 26);
            this.linkUyeKaydı.TabIndex = 5;
            this.linkUyeKaydı.TabStop = true;
            this.linkUyeKaydı.Text = "Üye Olmak için Tıklayınız";
            this.linkUyeKaydı.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUyeKaydı_LinkClicked);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.btnGirisYap.Location = new System.Drawing.Point(40, 302);
            this.btnGirisYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(241, 48);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // txtSifreLogin
            // 
            this.txtSifreLogin.Location = new System.Drawing.Point(17, 179);
            this.txtSifreLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifreLogin.Multiline = true;
            this.txtSifreLogin.Name = "txtSifreLogin";
            this.txtSifreLogin.Size = new System.Drawing.Size(264, 29);
            this.txtSifreLogin.TabIndex = 3;
            // 
            // txtTCLogin
            // 
            this.txtTCLogin.Location = new System.Drawing.Point(17, 58);
            this.txtTCLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTCLogin.Multiline = true;
            this.txtTCLogin.Name = "txtTCLogin";
            this.txtTCLogin.Size = new System.Drawing.Size(264, 31);
            this.txtTCLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tc Kimlik No :";
            // 
            // rbtnKullanıcı
            // 
            this.rbtnKullanıcı.AutoSize = true;
            this.rbtnKullanıcı.BackColor = System.Drawing.Color.Transparent;
            this.rbtnKullanıcı.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnKullanıcı.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnKullanıcı.Location = new System.Drawing.Point(335, 12);
            this.rbtnKullanıcı.Name = "rbtnKullanıcı";
            this.rbtnKullanıcı.Size = new System.Drawing.Size(223, 26);
            this.rbtnKullanıcı.TabIndex = 1;
            this.rbtnKullanıcı.TabStop = true;
            this.rbtnKullanıcı.Text = "Kullanıcı Olarak Giriş Yap";
            this.rbtnKullanıcı.UseVisualStyleBackColor = false;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAdmin.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnAdmin.Location = new System.Drawing.Point(335, 63);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(210, 26);
            this.rbtnAdmin.TabIndex = 2;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Admin Olarak Giriş Yap";
            this.rbtnAdmin.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::yazilimYapimi.Properties.Resources.borsa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 363);
            this.Controls.Add(this.linkUyeKaydı);
            this.Controls.Add(this.rbtnAdmin);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.rbtnKullanıcı);
            this.Controls.Add(this.txtSifreLogin);
            this.Controls.Add(this.txtTCLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoşgeldiniz";
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
    }
}

