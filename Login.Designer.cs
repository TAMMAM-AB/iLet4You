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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            txtbxUser = new TextBox();
            label2 = new Label();
            txtbxPass = new TextBox();
            btnLogin = new Button();
            btnPass = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(498, 168);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbxUser
            // 
            txtbxUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbxUser.Location = new Point(498, 192);
            txtbxUser.Name = "txtbxUser";
            txtbxUser.Size = new Size(125, 27);
            txtbxUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(498, 221);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtbxPass
            // 
            txtbxPass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbxPass.Location = new Point(498, 244);
            txtbxPass.Name = "txtbxPass";
            txtbxPass.PasswordChar = '*';
            txtbxPass.Size = new Size(125, 27);
            txtbxPass.TabIndex = 3;
            txtbxPass.KeyDown += txtbxPass_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(498, 289);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(125, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnPass
            // 
            btnPass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPass.FlatStyle = FlatStyle.Flat;
            btnPass.Font = new Font("Segoe UI", 8F);
            btnPass.Location = new Point(629, 242);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(40, 29);
            btnPass.TabIndex = 4;
            btnPass.Text = "🔒";
            btnPass.UseVisualStyleBackColor = true;
            btnPass.Click += btnPass_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 452);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.iLet4You;
            pictureBox1.Location = new Point(46, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 136);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(486, 93);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 7;
            label3.Text = "iLet4You Login";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(btnPass);
            Controls.Add(btnLogin);
            Controls.Add(txtbxPass);
            Controls.Add(label2);
            Controls.Add(txtbxUser);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "iLet4You - Login";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}
