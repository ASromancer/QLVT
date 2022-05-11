
namespace QLVT
{
    partial class frmTaoTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTaoTK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPassConfirm = new System.Windows.Forms.TextBox();
            this.btnChonMaNV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.radioCHINHANH = new System.Windows.Forms.RadioButton();
            this.radioUSER = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "TẠO TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Xác nhận mật khẩu";
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Location = new System.Drawing.Point(162, 379);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(136, 41);
            this.btnTaoTK.TabIndex = 2;
            this.btnTaoTK.Text = "Xác nhận";
            this.btnTaoTK.UseVisualStyleBackColor = true;
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(234, 114);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(239, 28);
            this.txtMaNV.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(234, 172);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(239, 28);
            this.txtPass.TabIndex = 4;
            // 
            // txtPassConfirm
            // 
            this.txtPassConfirm.Location = new System.Drawing.Point(234, 239);
            this.txtPassConfirm.Name = "txtPassConfirm";
            this.txtPassConfirm.PasswordChar = '*';
            this.txtPassConfirm.Size = new System.Drawing.Size(239, 28);
            this.txtPassConfirm.TabIndex = 4;
            // 
            // btnChonMaNV
            // 
            this.btnChonMaNV.Location = new System.Drawing.Point(504, 109);
            this.btnChonMaNV.Name = "btnChonMaNV";
            this.btnChonMaNV.Size = new System.Drawing.Size(151, 37);
            this.btnChonMaNV.TabIndex = 3;
            this.btnChonMaNV.Text = "Chọn mã NV";
            this.btnChonMaNV.UseVisualStyleBackColor = true;
            this.btnChonMaNV.Click += new System.EventHandler(this.btnChonMaNV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vai trò";
            // 
            // radioCHINHANH
            // 
            this.radioCHINHANH.AutoSize = true;
            this.radioCHINHANH.Checked = true;
            this.radioCHINHANH.Location = new System.Drawing.Point(234, 307);
            this.radioCHINHANH.Name = "radioCHINHANH";
            this.radioCHINHANH.Size = new System.Drawing.Size(128, 25);
            this.radioCHINHANH.TabIndex = 6;
            this.radioCHINHANH.TabStop = true;
            this.radioCHINHANH.Text = "CHINHANH";
            this.radioCHINHANH.UseVisualStyleBackColor = true;
            // 
            // radioUSER
            // 
            this.radioUSER.AutoSize = true;
            this.radioUSER.Location = new System.Drawing.Point(404, 307);
            this.radioUSER.Name = "radioUSER";
            this.radioUSER.Size = new System.Drawing.Size(79, 25);
            this.radioUSER.TabIndex = 6;
            this.radioUSER.TabStop = true;
            this.radioUSER.Text = "USER";
            this.radioUSER.UseVisualStyleBackColor = true;
            // 
            // frmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 477);
            this.Controls.Add(this.radioUSER);
            this.Controls.Add(this.radioCHINHANH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassConfirm);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.btnChonMaNV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "frmTaoTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTaoTK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPassConfirm;
        private System.Windows.Forms.Button btnChonMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioCHINHANH;
        private System.Windows.Forms.RadioButton radioUSER;
    }
}