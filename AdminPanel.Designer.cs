namespace iLet4You
{
    partial class AdminPanel
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cmbobxUserRoles = new ComboBox();
            btnUserCreate = new Button();
            btnUserDelete = new Button();
            txtbxPassword = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtbxUsername = new TextBox();
            label1 = new Label();
            btnUserRefresh = new Button();
            dgvUsers = new DataGridView();
            usernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            richTextBox1 = new RichTextBox();
            label9 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            btnLandlordRefresh = new Button();
            dgvLandlords = new DataGridView();
            landlordIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            landlordBindingSource = new BindingSource(components);
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            dgvTenants = new DataGridView();
            tenantBindingSource = new BindingSource(components);
            TenantId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            HouseNo = new DataGridViewTextBoxColumn();
            AddressLine1 = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            PostCode = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            btnTenantRefresh = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLandlords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)landlordBindingSource).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenants).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tenantBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1138, 596);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cmbobxUserRoles);
            tabPage1.Controls.Add(btnUserCreate);
            tabPage1.Controls.Add(btnUserDelete);
            tabPage1.Controls.Add(txtbxPassword);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtbxUsername);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btnUserRefresh);
            tabPage1.Controls.Add(dgvUsers);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1130, 568);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Users";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbobxUserRoles
            // 
            cmbobxUserRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbobxUserRoles.FormattingEnabled = true;
            cmbobxUserRoles.Items.AddRange(new object[] { "agent", "admin" });
            cmbobxUserRoles.Location = new Point(702, 395);
            cmbobxUserRoles.Name = "cmbobxUserRoles";
            cmbobxUserRoles.Size = new Size(100, 23);
            cmbobxUserRoles.TabIndex = 11;
            // 
            // btnUserCreate
            // 
            btnUserCreate.Location = new Point(808, 395);
            btnUserCreate.Name = "btnUserCreate";
            btnUserCreate.Size = new Size(75, 23);
            btnUserCreate.TabIndex = 10;
            btnUserCreate.Text = "Create";
            btnUserCreate.UseVisualStyleBackColor = true;
            btnUserCreate.Click += btnUserCreate_Click;
            // 
            // btnUserDelete
            // 
            btnUserDelete.Location = new Point(808, 322);
            btnUserDelete.Name = "btnUserDelete";
            btnUserDelete.Size = new Size(75, 23);
            btnUserDelete.TabIndex = 9;
            btnUserDelete.Text = "Delete";
            btnUserDelete.UseVisualStyleBackColor = true;
            btnUserDelete.Click += btnUserDelete_Click;
            // 
            // txtbxPassword
            // 
            txtbxPassword.Location = new Point(596, 395);
            txtbxPassword.Name = "txtbxPassword";
            txtbxPassword.Size = new Size(100, 23);
            txtbxPassword.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(596, 377);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(702, 377);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Role";
            // 
            // txtbxUsername
            // 
            txtbxUsername.Location = new Point(490, 395);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(100, 23);
            txtbxUsername.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(490, 377);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // btnUserRefresh
            // 
            btnUserRefresh.Location = new Point(490, 322);
            btnUserRefresh.Name = "btnUserRefresh";
            btnUserRefresh.Size = new Size(75, 23);
            btnUserRefresh.TabIndex = 2;
            btnUserRefresh.Text = "Refresh List";
            btnUserRefresh.UseVisualStyleBackColor = true;
            btnUserRefresh.Click += btnUserRefresh_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { usernameDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn });
            dgvUsers.DataSource = userBindingSource;
            dgvUsers.Location = new Point(490, 68);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(393, 248);
            dgvUsers.TabIndex = 1;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(btnLandlordRefresh);
            tabPage2.Controls.Add(dgvLandlords);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1130, 568);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Landlords";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(474, 389);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(290, 173);
            richTextBox1.TabIndex = 27;
            richTextBox1.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(474, 371);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 26;
            label9.Text = "Notes";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(262, 437);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(262, 419);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 24;
            label8.Text = "Email";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(156, 437);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(156, 419);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 22;
            label7.Text = "Phone Number";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(368, 389);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(368, 437);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 20;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(887, 367);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 19;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(262, 389);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(262, 371);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 17;
            label4.Text = "Last Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 371);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 16;
            label5.Text = "Address";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(156, 389);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(156, 371);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 14;
            label6.Text = "First Name";
            // 
            // btnLandlordRefresh
            // 
            btnLandlordRefresh.Location = new Point(806, 367);
            btnLandlordRefresh.Name = "btnLandlordRefresh";
            btnLandlordRefresh.Size = new Size(75, 23);
            btnLandlordRefresh.TabIndex = 13;
            btnLandlordRefresh.Text = "Refresh List";
            btnLandlordRefresh.UseVisualStyleBackColor = true;
            btnLandlordRefresh.Click += btnLandlordRefresh_Click;
            // 
            // dgvLandlords
            // 
            dgvLandlords.AllowUserToAddRows = false;
            dgvLandlords.AllowUserToDeleteRows = false;
            dgvLandlords.AutoGenerateColumns = false;
            dgvLandlords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLandlords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLandlords.Columns.AddRange(new DataGridViewColumn[] { landlordIdDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, notesDataGridViewTextBoxColumn });
            dgvLandlords.DataSource = landlordBindingSource;
            dgvLandlords.Location = new Point(6, 6);
            dgvLandlords.MultiSelect = false;
            dgvLandlords.Name = "dgvLandlords";
            dgvLandlords.ReadOnly = true;
            dgvLandlords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLandlords.Size = new Size(1118, 351);
            dgvLandlords.TabIndex = 12;
            // 
            // landlordIdDataGridViewTextBoxColumn
            // 
            landlordIdDataGridViewTextBoxColumn.DataPropertyName = "LandlordId";
            landlordIdDataGridViewTextBoxColumn.HeaderText = "LandlordId";
            landlordIdDataGridViewTextBoxColumn.Name = "landlordIdDataGridViewTextBoxColumn";
            landlordIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // landlordBindingSource
            // 
            landlordBindingSource.DataSource = typeof(Landlord);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnTenantRefresh);
            tabPage3.Controls.Add(dgvTenants);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1130, 568);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tenants";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1130, 568);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Properties";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1130, 568);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Maintenances";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1130, 568);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "QuickLinks";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvTenants
            // 
            dgvTenants.AllowUserToAddRows = false;
            dgvTenants.AllowUserToDeleteRows = false;
            dgvTenants.AutoGenerateColumns = false;
            dgvTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenants.Columns.AddRange(new DataGridViewColumn[] { TenantId, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, HouseNo, AddressLine1, City, PostCode, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            dgvTenants.DataSource = tenantBindingSource;
            dgvTenants.Location = new Point(6, 6);
            dgvTenants.MultiSelect = false;
            dgvTenants.Name = "dgvTenants";
            dgvTenants.ReadOnly = true;
            dgvTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenants.Size = new Size(1118, 403);
            dgvTenants.TabIndex = 13;
            // 
            // tenantBindingSource
            // 
            tenantBindingSource.DataSource = typeof(Tenant);
            // 
            // TenantId
            // 
            TenantId.DataPropertyName = "TenantId";
            TenantId.HeaderText = "TenantId";
            TenantId.Name = "TenantId";
            TenantId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "FirstName";
            dataGridViewTextBoxColumn2.HeaderText = "FirstName";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "LastName";
            dataGridViewTextBoxColumn3.HeaderText = "LastName";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // HouseNo
            // 
            HouseNo.DataPropertyName = "HouseNo";
            HouseNo.HeaderText = "HouseNo";
            HouseNo.Name = "HouseNo";
            HouseNo.ReadOnly = true;
            // 
            // AddressLine1
            // 
            AddressLine1.DataPropertyName = "AddressLine1";
            AddressLine1.HeaderText = "AddressLine1";
            AddressLine1.Name = "AddressLine1";
            AddressLine1.ReadOnly = true;
            // 
            // City
            // 
            City.DataPropertyName = "City";
            City.HeaderText = "City";
            City.Name = "City";
            City.ReadOnly = true;
            // 
            // PostCode
            // 
            PostCode.DataPropertyName = "PostCode";
            PostCode.HeaderText = "PostCode";
            PostCode.Name = "PostCode";
            PostCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "PhoneNumber";
            dataGridViewTextBoxColumn5.HeaderText = "PhoneNumber";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Email";
            dataGridViewTextBoxColumn6.HeaderText = "Email";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Notes";
            dataGridViewTextBoxColumn7.HeaderText = "Notes";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // btnTenantRefresh
            // 
            btnTenantRefresh.Location = new Point(850, 428);
            btnTenantRefresh.Name = "btnTenantRefresh";
            btnTenantRefresh.Size = new Size(75, 23);
            btnTenantRefresh.TabIndex = 14;
            btnTenantRefresh.Text = "Refresh List";
            btnTenantRefresh.UseVisualStyleBackColor = true;
            btnTenantRefresh.Click += btnTenantRefresh_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 620);
            Controls.Add(tabControl1);
            Name = "AdminPanel";
            Text = "AdminPanel";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLandlords).EndInit();
            ((System.ComponentModel.ISupportInitialize)landlordBindingSource).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenants).EndInit();
            ((System.ComponentModel.ISupportInitialize)tenantBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private BindingSource userBindingSource;
        private Button btnUserRefresh;
        private BindingSource landlordBindingSource;
        private TextBox txtbxPassword;
        private Label label3;
        private Label label2;
        private TextBox txtbxUsername;
        private Label label1;
        private Button btnUserCreate;
        private Button btnUserDelete;
        private ComboBox cmbobxUserRoles;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private Label label6;
        private Button btnLandlordRefresh;
        private DataGridView dgvLandlords;
        private DataGridViewTextBoxColumn landlordIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
        private Label label9;
        private TextBox textBox5;
        private Label label8;
        private TextBox textBox4;
        private Label label7;
        private DataGridView dgvTenants;
        private DataGridViewTextBoxColumn TenantId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn HouseNo;
        private DataGridViewTextBoxColumn AddressLine1;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn PostCode;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private BindingSource tenantBindingSource;
        private Button btnTenantRefresh;
    }
}