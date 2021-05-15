
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
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.rbtnKullanıcı = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // linkUyeKaydı
            // 
            this.linkUyeKaydı.AutoSize = true;
            this.linkUyeKaydı.BackColor = System.Drawing.Color.Transparent;
            this.linkUyeKaydı.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUyeKaydı.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkUyeKaydı.Location = new System.Drawing.Point(10, 229);
            this.linkUyeKaydı.Name = "linkUyeKaydı";
            this.linkUyeKaydı.Size = new System.Drawing.Size(241, 26);
            this.linkUyeKaydı.TabIndex = 2;
            this.linkUyeKaydı.TabStop = true;
            this.linkUyeKaydı.Text = "Üye Olmak İçin Tıklayınız.";
            this.linkUyeKaydı.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUyeKaydı_LinkClicked);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.btnGirisYap.Location = new System.Drawing.Point(17, 280);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(225, 54);
            this.btnGirisYap.TabIndex = 4;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // txtSifreLogin
            // 
            this.txtSifreLogin.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifreLogin.Location = new System.Drawing.Point(16, 168);
            this.txtSifreLogin.Multiline = true;
            this.txtSifreLogin.Name = "txtSifreLogin";
            this.txtSifreLogin.Size = new System.Drawing.Size(235, 27);
            this.txtSifreLogin.TabIndex = 3;
            // 
            // txtTCLogin
            // 
            this.txtTCLogin.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCLogin.Location = new System.Drawing.Point(15, 64);
            this.txtTCLogin.Multiline = true;
            this.txtTCLogin.Name = "txtTCLogin";
            this.txtTCLogin.Size = new System.Drawing.Size(235, 27);
            this.txtTCLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 128);
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
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tc Kimlik No :";
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAdmin.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnAdmin.Location = new System.Drawing.Point(276, 64);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(210, 26);
            this.rbtnAdmin.TabIndex = 5;
            this.rbtnAdmin.Text = "Admin Olarak Giriş Yap";
            this.rbtnAdmin.UseVisualStyleBackColor = false;
            // 
            // rbtnKullanıcı
            // 
            this.rbtnKullanıcı.AutoSize = true;
            this.rbtnKullanıcı.BackColor = System.Drawing.Color.Transparent;
            this.rbtnKullanıcı.Checked = true;
            this.rbtnKullanıcı.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold);
            this.rbtnKullanıcı.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rbtnKullanıcı.Location = new System.Drawing.Point(276, 20);
            this.rbtnKullanıcı.Name = "rbtnKullanıcı";
            this.rbtnKullanıcı.Size = new System.Drawing.Size(223, 26);
            this.rbtnKullanıcı.TabIndex = 6;
            this.rbtnKullanıcı.TabStop = true;
            this.rbtnKullanıcı.Text = "Kullanıcı Olarak Giriş Yap";
            this.rbtnKullanıcı.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::yazilimYapimi.Properties.Resources.borsa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 370);
            this.Controls.Add(this.rbtnKullanıcı);
            this.Controls.Add(this.rbtnAdmin);
            this.Controls.Add(this.linkUyeKaydı);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSifreLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTCLogin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoşgeldiniz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.TextBox txtSifreLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkUyeKaydı;
        public System.Windows.Forms.TextBox txtTCLogin;
        private System.Windows.Forms.RadioButton rbtnAdmin;
        private System.Windows.Forms.RadioButton rbtnKullanıcı;
    }
}

