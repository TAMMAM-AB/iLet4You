namespace iLet4You
{
    partial class Login
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
            label1 = new Label();
            txtbxUser = new TextBox();
            label2 = new Label();
            txtbxPass = new TextBox();
            btnLogin = new Button();
            btnPass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(278, 104);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbxUser
            // 
            txtbxUser.Location = new Point(278, 122);
            txtbxUser.Margin = new Padding(3, 2, 3, 2);
            txtbxUser.Name = "txtbxUser";
            txtbxUser.Size = new Size(110, 23);
            txtbxUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(278, 144);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbxPass
            // 
            txtbxPass.Location = new Point(278, 161);
            txtbxPass.Margin = new Padding(3, 2, 3, 2);
            txtbxPass.Name = "txtbxPass";
            txtbxPass.PasswordChar = '*';
            txtbxPass.Size = new Size(110, 23);
            txtbxPass.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(278, 195);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(109, 22);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnPass
            // 
            btnPass.FlatStyle = FlatStyle.Flat;
            btnPass.Font = new Font("Segoe UI", 8F);
            btnPass.Location = new Point(393, 160);
            btnPass.Margin = new Padding(3, 2, 3, 2);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(35, 22);
            btnPass.TabIndex = 5;
            btnPass.Text = "🔒";
            btnPass.UseVisualStyleBackColor = true;
            btnPass.Click += btnPass_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnPass);
            Controls.Add(btnLogin);
            Controls.Add(txtbxPass);
            Controls.Add(label2);
            Controls.Add(txtbxUser);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtbxUser;
        private Label label2;
        private TextBox txtbxPass;
        private Button btnLogin;
        private Button btnPass;
    }
}
