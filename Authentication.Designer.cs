namespace assignment_4_c_
{
    partial class Authentication
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClear = new Button();
            btnLogin = new Button();
            lblPassword = new Label();
            lblUserName = new Label();
            txtpass = new TextBox();
            txtusername = new TextBox();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(387, 259);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 27);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(263, 259);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(90, 27);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(258, 179);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password: ";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(239, 121);
            lblUserName.Margin = new Padding(2, 0, 2, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(89, 20);
            lblUserName.TabIndex = 8;
            lblUserName.Text = "User Name: ";
            // 
            // txtpass
            // 
            txtpass.Location = new Point(332, 174);
            txtpass.Margin = new Padding(2);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(150, 27);
            txtpass.TabIndex = 7;
            // 
            // txtusername
            // 
            txtusername.Location = new Point(332, 114);
            txtusername.Margin = new Padding(2);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(150, 27);
            txtusername.TabIndex = 6;
            // 
            // Authentication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(txtpass);
            Controls.Add(txtusername);
            Name = "Authentication";
            Text = "Authentication";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private Button btnLogin;
        private Label lblPassword;
        private Label lblUserName;
        private TextBox txtpass;
        private TextBox txtusername;
    }
}
