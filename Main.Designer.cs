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
            radioBtnProperty = new RadioButton();
            radioBtnLandlord = new RadioButton();
            radioBtnTenant = new RadioButton();
            panel1 = new Panel();
            btnAdmin = new Button();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            bindingSource1 = new BindingSource(components);
            panelSearchResults = new Panel();
            tabPage3 = new TabPage();
            txtbxTenantEmail = new TextBox();
            label1 = new Label();
            txtbxTenantPhone = new TextBox();
            txtbxTenantLName = new TextBox();
            txtbxTenantFName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label15 = new Label();
            label16 = new Label();
            richtxtbxTenant = new RichTextBox();
            button1 = new Button();
            tabPage2 = new TabPage();
            txtbxLandlordEmail = new TextBox();
            txtbxLandlordPhone = new TextBox();
            txtbxLandlordAddress = new TextBox();
            txtbxLandlordLName = new TextBox();
            txtbxLandlordFName = new TextBox();
            richtxtbxLandlord = new RichTextBox();
            label22 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            button2 = new Button();
            tabPage1 = new TabPage();
            cmbobxEPC = new ComboBox();
            dateEICR = new DateTimePicker();
            dateEPC = new DateTimePicker();
            dateGas = new DateTimePicker();
            numRent = new NumericUpDown();
            txtbxPostcode = new TextBox();
            txtbxCity = new TextBox();
            txtbxAddress = new TextBox();
            txtbxHNo = new TextBox();
            richtxtbxProperty = new RichTextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            label13 = new Label();
            button3 = new Button();
            tabPage5 = new TabPage();
            labelTotalLandlords = new Label();
            labelTotalProperties = new Label();
            labelTotalTenants = new Label();
            tabControl1 = new TabControl();
            btnQuickLinks = new Button();
            label23 = new Label();
            label14 = new Label();
            lblPropertyLandord = new Label();
            lblPropertyTenant = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            tabPage3.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRent).BeginInit();
            tabPage5.SuspendLayout();
            tabControl1.SuspendLayout();
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
            panel1.Location = new Point(12, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 497);
            panel1.TabIndex = 5;
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
            btnLogout.Location = new Point(1658, 12);
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
            // panelSearchResults
            // 
            panelSearchResults.AutoSize = true;
            panelSearchResults.Location = new Point(241, 33);
            panelSearchResults.MaximumSize = new Size(621, 150);
            panelSearchResults.Name = "panelSearchResults";
            panelSearchResults.Size = new Size(621, 19);
            panelSearchResults.TabIndex = 6;
            panelSearchResults.Visible = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(txtbxTenantEmail);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(txtbxTenantPhone);
            tabPage3.Controls.Add(txtbxTenantLName);
            tabPage3.Controls.Add(txtbxTenantFName);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(richtxtbxTenant);
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
            // txtbxTenantEmail
            // 
            txtbxTenantEmail.Location = new Point(112, 107);
            txtbxTenantEmail.Name = "txtbxTenantEmail";
            txtbxTenantEmail.Size = new Size(120, 23);
            txtbxTenantEmail.TabIndex = 116;
            // 
            // label1
            // 
            label1.Location = new Point(6, 112);
            label1.Name = "label1";
            label1.Size = new Size(100, 18);
            label1.TabIndex = 115;
            label1.Text = "Email:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // txtbxTenantPhone
            // 
            txtbxTenantPhone.Location = new Point(112, 78);
            txtbxTenantPhone.Name = "txtbxTenantPhone";
            txtbxTenantPhone.Size = new Size(120, 23);
            txtbxTenantPhone.TabIndex = 114;
            // 
            // txtbxTenantLName
            // 
            txtbxTenantLName.Location = new Point(112, 49);
            txtbxTenantLName.Name = "txtbxTenantLName";
            txtbxTenantLName.Size = new Size(120, 23);
            txtbxTenantLName.TabIndex = 112;
            // 
            // txtbxTenantFName
            // 
            txtbxTenantFName.Location = new Point(112, 20);
            txtbxTenantFName.Name = "txtbxTenantFName";
            txtbxTenantFName.Size = new Size(120, 23);
            txtbxTenantFName.TabIndex = 111;
            // 
            // label4
            // 
            label4.Location = new Point(6, 25);
            label4.Name = "label4";
            label4.Size = new Size(100, 18);
            label4.TabIndex = 110;
            label4.Text = "First Name:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.Location = new Point(6, 54);
            label5.Name = "label5";
            label5.Size = new Size(100, 18);
            label5.TabIndex = 109;
            label5.Text = "Last Name:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // label15
            // 
            label15.Location = new Point(6, 83);
            label15.Name = "label15";
            label15.Size = new Size(100, 18);
            label15.TabIndex = 107;
            label15.Text = "Phone Number:";
            label15.TextAlign = ContentAlignment.TopRight;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(238, 2);
            label16.Name = "label16";
            label16.Size = new Size(38, 15);
            label16.TabIndex = 106;
            label16.Text = "Notes";
            // 
            // richtxtbxTenant
            // 
            richtxtbxTenant.Location = new Point(238, 20);
            richtxtbxTenant.Name = "richtxtbxTenant";
            richtxtbxTenant.Size = new Size(307, 395);
            richtxtbxTenant.TabIndex = 105;
            richtxtbxTenant.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(470, 421);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 104;
            button1.Text = "save";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtbxLandlordEmail);
            tabPage2.Controls.Add(txtbxLandlordPhone);
            tabPage2.Controls.Add(txtbxLandlordAddress);
            tabPage2.Controls.Add(txtbxLandlordLName);
            tabPage2.Controls.Add(txtbxLandlordFName);
            tabPage2.Controls.Add(richtxtbxLandlord);
            tabPage2.Controls.Add(label22);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(label18);
            tabPage2.Controls.Add(label19);
            tabPage2.Controls.Add(label20);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1241, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Landlord";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtbxLandlordEmail
            // 
            txtbxLandlordEmail.Location = new Point(112, 136);
            txtbxLandlordEmail.Name = "txtbxLandlordEmail";
            txtbxLandlordEmail.Size = new Size(120, 23);
            txtbxLandlordEmail.TabIndex = 103;
            // 
            // txtbxLandlordPhone
            // 
            txtbxLandlordPhone.Location = new Point(112, 107);
            txtbxLandlordPhone.Name = "txtbxLandlordPhone";
            txtbxLandlordPhone.Size = new Size(120, 23);
            txtbxLandlordPhone.TabIndex = 96;
            // 
            // txtbxLandlordAddress
            // 
            txtbxLandlordAddress.Location = new Point(112, 78);
            txtbxLandlordAddress.Name = "txtbxLandlordAddress";
            txtbxLandlordAddress.Size = new Size(120, 23);
            txtbxLandlordAddress.TabIndex = 95;
            // 
            // txtbxLandlordLName
            // 
            txtbxLandlordLName.Location = new Point(112, 49);
            txtbxLandlordLName.Name = "txtbxLandlordLName";
            txtbxLandlordLName.Size = new Size(120, 23);
            txtbxLandlordLName.TabIndex = 94;
            // 
            // txtbxLandlordFName
            // 
            txtbxLandlordFName.Location = new Point(112, 20);
            txtbxLandlordFName.Name = "txtbxLandlordFName";
            txtbxLandlordFName.Size = new Size(120, 23);
            txtbxLandlordFName.TabIndex = 93;
            // 
            // richtxtbxLandlord
            // 
            richtxtbxLandlord.Location = new Point(238, 20);
            richtxtbxLandlord.Name = "richtxtbxLandlord";
            richtxtbxLandlord.Size = new Size(307, 395);
            richtxtbxLandlord.TabIndex = 82;
            richtxtbxLandlord.Text = "";
            // 
            // label22
            // 
            label22.Location = new Point(6, 141);
            label22.Name = "label22";
            label22.Size = new Size(100, 18);
            label22.TabIndex = 102;
            label22.Text = "Email:";
            label22.TextAlign = ContentAlignment.TopRight;
            // 
            // label17
            // 
            label17.Location = new Point(6, 25);
            label17.Name = "label17";
            label17.Size = new Size(100, 18);
            label17.TabIndex = 87;
            label17.Text = "First Name:";
            label17.TextAlign = ContentAlignment.TopRight;
            // 
            // label18
            // 
            label18.Location = new Point(6, 54);
            label18.Name = "label18";
            label18.Size = new Size(100, 18);
            label18.TabIndex = 86;
            label18.Text = "Last Name:";
            label18.TextAlign = ContentAlignment.TopRight;
            // 
            // label19
            // 
            label19.Location = new Point(6, 83);
            label19.Name = "label19";
            label19.Size = new Size(100, 18);
            label19.TabIndex = 85;
            label19.Text = "Address:";
            label19.TextAlign = ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.Location = new Point(6, 112);
            label20.Name = "label20";
            label20.Size = new Size(100, 18);
            label20.TabIndex = 84;
            label20.Text = "Phone Number:";
            label20.TextAlign = ContentAlignment.TopRight;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(238, 2);
            label21.Name = "label21";
            label21.Size = new Size(38, 15);
            label21.TabIndex = 83;
            label21.Text = "Notes";
            // 
            // button2
            // 
            button2.Location = new Point(470, 421);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 81;
            button2.Text = "save";
            button2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblPropertyTenant);
            tabPage1.Controls.Add(lblPropertyLandord);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(cmbobxEPC);
            tabPage1.Controls.Add(dateEICR);
            tabPage1.Controls.Add(dateEPC);
            tabPage1.Controls.Add(dateGas);
            tabPage1.Controls.Add(numRent);
            tabPage1.Controls.Add(txtbxPostcode);
            tabPage1.Controls.Add(txtbxCity);
            tabPage1.Controls.Add(txtbxAddress);
            tabPage1.Controls.Add(txtbxHNo);
            tabPage1.Controls.Add(richtxtbxProperty);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(button3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1241, 497);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Property Details";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbobxEPC
            // 
            cmbobxEPC.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbobxEPC.FormattingEnabled = true;
            cmbobxEPC.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G" });
            cmbobxEPC.Location = new Point(113, 327);
            cmbobxEPC.Name = "cmbobxEPC";
            cmbobxEPC.Size = new Size(120, 23);
            cmbobxEPC.TabIndex = 80;
            // 
            // dateEICR
            // 
            dateEICR.Location = new Point(113, 298);
            dateEICR.Name = "dateEICR";
            dateEICR.Size = new Size(120, 23);
            dateEICR.TabIndex = 79;
            // 
            // dateEPC
            // 
            dateEPC.Location = new Point(113, 269);
            dateEPC.Name = "dateEPC";
            dateEPC.Size = new Size(120, 23);
            dateEPC.TabIndex = 78;
            // 
            // dateGas
            // 
            dateGas.Location = new Point(113, 240);
            dateGas.Name = "dateGas";
            dateGas.Size = new Size(120, 23);
            dateGas.TabIndex = 77;
            // 
            // numRent
            // 
            numRent.DecimalPlaces = 2;
            numRent.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numRent.Location = new Point(113, 182);
            numRent.Maximum = new decimal(new int[] { -1486618625, 232830643, 0, 0 });
            numRent.Name = "numRent";
            numRent.Size = new Size(120, 23);
            numRent.TabIndex = 76;
            // 
            // txtbxPostcode
            // 
            txtbxPostcode.Location = new Point(113, 124);
            txtbxPostcode.Name = "txtbxPostcode";
            txtbxPostcode.Size = new Size(120, 23);
            txtbxPostcode.TabIndex = 75;
            // 
            // txtbxCity
            // 
            txtbxCity.Location = new Point(113, 95);
            txtbxCity.Name = "txtbxCity";
            txtbxCity.Size = new Size(120, 23);
            txtbxCity.TabIndex = 74;
            // 
            // txtbxAddress
            // 
            txtbxAddress.Location = new Point(113, 66);
            txtbxAddress.Name = "txtbxAddress";
            txtbxAddress.Size = new Size(120, 23);
            txtbxAddress.TabIndex = 73;
            // 
            // txtbxHNo
            // 
            txtbxHNo.Location = new Point(113, 37);
            txtbxHNo.Name = "txtbxHNo";
            txtbxHNo.Size = new Size(120, 23);
            txtbxHNo.TabIndex = 72;
            // 
            // richtxtbxProperty
            // 
            richtxtbxProperty.Location = new Point(239, 37);
            richtxtbxProperty.Name = "richtxtbxProperty";
            richtxtbxProperty.Size = new Size(307, 395);
            richtxtbxProperty.TabIndex = 61;
            richtxtbxProperty.Text = "";
            // 
            // label12
            // 
            label12.Location = new Point(7, 332);
            label12.Name = "label12";
            label12.Size = new Size(100, 18);
            label12.TabIndex = 71;
            label12.Text = "ECP Rating:";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // label11
            // 
            label11.Location = new Point(7, 304);
            label11.Name = "label11";
            label11.Size = new Size(100, 18);
            label11.TabIndex = 70;
            label11.Text = "EICR Expiry:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.Location = new Point(7, 274);
            label10.Name = "label10";
            label10.Size = new Size(100, 18);
            label10.TabIndex = 69;
            label10.Text = "EPC Expiry:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.Location = new Point(7, 245);
            label9.Name = "label9";
            label9.Size = new Size(100, 18);
            label9.TabIndex = 68;
            label9.Text = "Gas Cert. Expiry:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Location = new Point(7, 187);
            label2.Name = "label2";
            label2.Size = new Size(100, 18);
            label2.TabIndex = 67;
            label2.Text = "Rent:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.Location = new Point(7, 42);
            label3.Name = "label3";
            label3.Size = new Size(100, 18);
            label3.TabIndex = 66;
            label3.Text = "House Number:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.Location = new Point(7, 71);
            label6.Name = "label6";
            label6.Size = new Size(100, 18);
            label6.TabIndex = 65;
            label6.Text = "Address:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.Location = new Point(7, 100);
            label8.Name = "label8";
            label8.Size = new Size(100, 18);
            label8.TabIndex = 64;
            label8.Text = "City:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.Location = new Point(7, 129);
            label7.Name = "label7";
            label7.Size = new Size(100, 18);
            label7.TabIndex = 63;
            label7.Text = "Postcode:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(239, 19);
            label13.Name = "label13";
            label13.Size = new Size(38, 15);
            label13.TabIndex = 62;
            label13.Text = "Notes";
            // 
            // button3
            // 
            button3.Location = new Point(471, 438);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 9;
            button3.Text = "save";
            button3.UseVisualStyleBackColor = true;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(241, 57);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1249, 525);
            tabControl1.TabIndex = 1;
            // 
            // btnQuickLinks
            // 
            btnQuickLinks.Location = new Point(12, 584);
            btnQuickLinks.Name = "btnQuickLinks";
            btnQuickLinks.Size = new Size(223, 23);
            btnQuickLinks.TabIndex = 9;
            btnQuickLinks.Text = "Edit Quick Links";
            btnQuickLinks.UseVisualStyleBackColor = true;
            btnQuickLinks.Click += btnQuickLinks_Click;
            // 
            // label23
            // 
            label23.Location = new Point(7, 371);
            label23.Name = "label23";
            label23.Size = new Size(100, 18);
            label23.TabIndex = 82;
            label23.Text = "Landlord:";
            label23.TextAlign = ContentAlignment.TopRight;
            // 
            // label14
            // 
            label14.Location = new Point(7, 389);
            label14.Name = "label14";
            label14.Size = new Size(100, 18);
            label14.TabIndex = 83;
            label14.Text = "Tenant:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPropertyLandord
            // 
            lblPropertyLandord.Location = new Point(113, 371);
            lblPropertyLandord.Name = "lblPropertyLandord";
            lblPropertyLandord.Size = new Size(120, 18);
            lblPropertyLandord.TabIndex = 84;
            // 
            // lblPropertyTenant
            // 
            lblPropertyTenant.Location = new Point(113, 389);
            lblPropertyTenant.Name = "lblPropertyTenant";
            lblPropertyTenant.Size = new Size(120, 18);
            lblPropertyTenant.TabIndex = 85;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnQuickLinks);
            Controls.Add(panelSearchResults);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRent).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbxSearch;
        private RadioButton radioBtnProperty;
        private RadioButton radioBtnLandlord;
        private RadioButton radioBtnTenant;
        private Panel panel1;
        private Button btnAdmin;
        private Button btnLogout;
        private PictureBox pictureBox1;
        private BindingSource bindingSource1;
        private Panel panelSearchResults;
        private TabPage tabPage3;
        private TextBox txtbxTenantEmail;
        private Label label1;
        private TextBox txtbxTenantPhone;
        private TextBox txtbxTenantLName;
        private TextBox txtbxTenantFName;
        private Label label4;
        private Label label5;
        private Label label15;
        private Label label16;
        private RichTextBox richtxtbxTenant;
        private Button button1;
        private TabPage tabPage2;
        private TextBox txtbxLandlordEmail;
        private TextBox txtbxLandlordPhone;
        private TextBox txtbxLandlordAddress;
        private TextBox txtbxLandlordLName;
        private TextBox txtbxLandlordFName;
        private RichTextBox richtxtbxLandlord;
        private Label label22;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Button button2;
        private TabPage tabPage1;
        private ComboBox cmbobxEPC;
        private DateTimePicker dateEICR;
        private DateTimePicker dateEPC;
        private DateTimePicker dateGas;
        private NumericUpDown numRent;
        private TextBox txtbxPostcode;
        private TextBox txtbxCity;
        private TextBox txtbxAddress;
        private TextBox txtbxHNo;
        private RichTextBox richtxtbxProperty;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label13;
        private Button button3;
        private TabPage tabPage5;
        private Label labelTotalLandlords;
        private Label labelTotalProperties;
        private Label labelTotalTenants;
        private TabControl tabControl1;
        private Button btnQuickLinks;
        private Label lblPropertyTenant;
        private Label lblPropertyLandord;
        private Label label14;
        private Label label23;
    }
}