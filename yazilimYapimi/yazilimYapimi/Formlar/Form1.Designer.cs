
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkUyeKaydı = new System.Windows.Forms.LinkLabel();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.txtSifreLogin = new System.Windows.Forms.TextBox();
            this.txtTCLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnKullanıcı = new System.Windows.Forms.RadioButton();
            this.rbtnAdmin = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkUyeKaydı);
            this.groupBox1.Controls.Add(this.btnGirisYap);
            this.groupBox1.Controls.Add(this.txtSifreLogin);
            this.groupBox1.Controls.Add(this.txtTCLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(191, 201);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(371, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // linkUyeKaydı
            // 
            this.linkUyeKaydı.AutoSize = true;
            this.linkUyeKaydı.Location = new System.Drawing.Point(35, 188);
            this.linkUyeKaydı.Name = "linkUyeKaydı";
            this.linkUyeKaydı.Size = new System.Drawing.Size(164, 17);
            this.linkUyeKaydı.TabIndex = 5;
            this.linkUyeKaydı.TabStop = true;
            this.linkUyeKaydı.Text = "Üye Olmak için Tıklayınız";
            this.linkUyeKaydı.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUyeKaydı_LinkClicked);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisYap.Location = new System.Drawing.Point(60, 239);
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
            this.txtSifreLogin.Location = new System.Drawing.Point(12, 134);
            this.txtSifreLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifreLogin.Multiline = true;
            this.txtSifreLogin.Name = "txtSifreLogin";
            this.txtSifreLogin.Size = new System.Drawing.Size(329, 37);
            this.txtSifreLogin.TabIndex = 3;
            // 
            // txtTCLogin
            // 
            this.txtTCLogin.Location = new System.Drawing.Point(12, 48);
            this.txtTCLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTCLogin.Multiline = true;
            this.txtTCLogin.Name = "txtTCLogin";
            this.txtTCLogin.Size = new System.Drawing.Size(329, 37);
            this.txtTCLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // rbtnKullanıcı
            // 
            this.rbtnKullanıcı.AutoSize = true;
            this.rbtnKullanıcı.Location = new System.Drawing.Point(396, 58);
            this.rbtnKullanıcı.Name = "rbtnKullanıcı";
            this.rbtnKullanıcı.Size = new System.Drawing.Size(117, 21);
            this.rbtnKullanıcı.TabIndex = 1;
            this.rbtnKullanıcı.TabStop = true;
            this.rbtnKullanıcı.Text = "Kullanıcı Girisi";
            this.rbtnKullanıcı.UseVisualStyleBackColor = true;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.Location = new System.Drawing.Point(396, 115);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(104, 21);
            this.rbtnAdmin.TabIndex = 2;
            this.rbtnAdmin.TabStop = true;
            this.rbtnAdmin.Text = "Admin Girisi";
            this.rbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 508);
            this.Controls.Add(this.rbtnAdmin);
            this.Controls.Add(this.rbtnKullanıcı);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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

