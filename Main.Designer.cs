namespace iLet4You
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            txtbxSearch = new TextBox();
            tabControl1 = new TabControl();
            tabPage5 = new TabPage();
            labelTotalLandlords = new Label();
            labelTotalProperties = new Label();
            labelTotalTenants = new Label();
            tabPage1 = new TabPage();
            button3 = new Button();
            label4 = new Label();
            richTextBox4 = new RichTextBox();
            tabPage2 = new TabPage();
            button2 = new Button();
            label5 = new Label();
            richTextBox5 = new RichTextBox();
            tabPage3 = new TabPage();
            label1 = new Label();
            richTextBox3 = new RichTextBox();
            button1 = new Button();
            tabPage4 = new TabPage();
            radioBtnProperty = new RadioButton();
            radioBtnLandlord = new RadioButton();
            radioBtnTenant = new RadioButton();
            panel1 = new Panel();
            linkLabel6 = new LinkLabel();
            linkLabel5 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            btnAdmin = new Button();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            bindingSource1 = new BindingSource(components);
            tabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // txtbxSearch
            // 
            txtbxSearch.Location = new Point(241, 13);
            txtbxSearch.Margin = new Padding(3, 2, 3, 2);
            txtbxSearch.Name = "txtbxSearch";
            txtbxSearch.Size = new Size(621, 23);
            txtbxSearch.TabIndex = 0;
            txtbxSearch.TextChanged += txtbxSearch_TextChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(241, 57);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1249, 525);
            tabControl1.TabIndex = 1;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(labelTotalLandlords);
            tabPage5.Controls.Add(labelTotalProperties);
            tabPage5.Controls.Add(labelTotalTenants);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1241, 497);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Home";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // labelTotalLandlords
            // 
            labelTotalLandlords.AutoSize = true;
            labelTotalLandlords.Font = new Font("Segoe UI", 16F);
            labelTotalLandlords.Location = new Point(22, 151);
            labelTotalLandlords.Name = "labelTotalLandlords";
            labelTotalLandlords.Size = new Size(164, 30);
            labelTotalLandlords.TabIndex = 2;
            labelTotalLandlords.Text = "Total Landlords:";
            // 
            // labelTotalProperties
            // 
            labelTotalProperties.AutoSize = true;
            labelTotalProperties.Font = new Font("Segoe UI", 16F);
            labelTotalProperties.Location = new Point(22, 99);
            labelTotalProperties.Name = "labelTotalProperties";
            labelTotalProperties.Size = new Size(175, 30);
            labelTotalProperties.TabIndex = 1;
            labelTotalProperties.Text = "Total Properties: ";
            // 
            // labelTotalTenants
            // 
            labelTotalTenants.AutoSize = true;
            labelTotalTenants.Font = new Font("Segoe UI", 16F);
            labelTotalTenants.Location = new Point(22, 41);
            labelTotalTenants.Name = "labelTotalTenants";
            labelTotalTenants.Size = new Size(149, 30);
            labelTotalTenants.TabIndex = 0;
            labelTotalTenants.Text = "Total Tenants: ";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(richTextBox4);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1241, 497);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Property Details";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1108, 438);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 9;
            button3.Text = "save";
            button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(876, 19);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 8;
            label4.Text = "Property";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(876, 37);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(307, 395);
            richTextBox4.TabIndex = 7;
            richTextBox4.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(richTextBox5);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1241, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Landlord";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1108, 446);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "save";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(876, 17);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 7;
            label5.Text = "Landlord";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(876, 35);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(307, 395);
            richTextBox5.TabIndex = 6;
            richTextBox5.Text = "";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Controls.Add(button1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(1241, 497);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tenant";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(876, 19);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 7;
            label1.Text = "Tenant notes:";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(876, 37);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(307, 395);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(1108, 455);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "save";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1241, 497);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Notes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // radioBtnProperty
            // 
            radioBtnProperty.AutoSize = true;
            radioBtnProperty.Checked = true;
            radioBtnProperty.Location = new Point(868, 17);
            radioBtnProperty.Name = "radioBtnProperty";
            radioBtnProperty.Size = new Size(70, 19);
            radioBtnProperty.TabIndex = 2;
            radioBtnProperty.TabStop = true;
            radioBtnProperty.Text = "Property";
            radioBtnProperty.UseVisualStyleBackColor = true;
            // 
            // radioBtnLandlord
            // 
            radioBtnLandlord.AutoSize = true;
            radioBtnLandlord.Location = new Point(944, 17);
            radioBtnLandlord.Name = "radioBtnLandlord";
            radioBtnLandlord.Size = new Size(72, 19);
            radioBtnLandlord.TabIndex = 3;
            radioBtnLandlord.Text = "Landlord";
            radioBtnLandlord.UseVisualStyleBackColor = true;
            // 
            // radioBtnTenant
            // 
            radioBtnTenant.AutoSize = true;
            radioBtnTenant.Location = new Point(1022, 17);
            radioBtnTenant.Name = "radioBtnTenant";
            radioBtnTenant.Size = new Size(61, 19);
            radioBtnTenant.TabIndex = 4;
            radioBtnTenant.Text = "Tenant";
            radioBtnTenant.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(linkLabel6);
            panel1.Controls.Add(linkLabel5);
            panel1.Controls.Add(linkLabel4);
            panel1.Controls.Add(linkLabel3);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Location = new Point(12, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 497);
            panel1.TabIndex = 5;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Location = new Point(74, 214);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(60, 15);
            linkLabel6.TabIndex = 5;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "linkLabel6";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(74, 182);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(60, 15);
            linkLabel5.TabIndex = 4;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "linkLabel5";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(74, 151);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(60, 15);
            linkLabel4.TabIndex = 3;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "linkLabel4";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(74, 114);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(60, 15);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "linkLabel3";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(74, 65);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(60, 15);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "linkLabel2";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(74, 19);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(60, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel1";
            // 
            // btnAdmin
            // 
            btnAdmin.Enabled = false;
            btnAdmin.Location = new Point(1520, 12);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(132, 23);
            btnAdmin.TabIndex = 6;
            btnAdmin.Text = "Admin Controls";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Visible = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(241, 597);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.iLet4You;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1904, 1041);
            Controls.Add(pictureBox1);
            Controls.Add(btnLogout);
            Controls.Add(btnAdmin);
            Controls.Add(panel1);
            Controls.Add(radioBtnTenant);
            Controls.Add(radioBtnLandlord);
            Controls.Add(radioBtnProperty);
            Controls.Add(tabControl1);
            Controls.Add(txtbxSearch);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "iLet4You";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbxSearch;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button button3;
        private Label label4;
        private RichTextBox richTextBox4;
        private Button button2;
        private Label label5;
        private RichTextBox richTextBox5;
        private Label label1;
        private RichTextBox richTextBox3;
        private Button button1;
        private RadioButton radioBtnProperty;
        private RadioButton radioBtnLandlord;
        private RadioButton radioBtnTenant;
        private Panel panel1;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private TabPage tabPage4;
        private Button btnAdmin;
        private Button btnLogout;
        private TabPage tabPage5;
        private Label labelTotalLandlords;
        private Label labelTotalProperties;
        private Label labelTotalTenants;
        private PictureBox pictureBox1;
        private BindingSource bindingSource1;
    }
}