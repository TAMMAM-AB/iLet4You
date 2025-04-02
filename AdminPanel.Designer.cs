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
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            landlordBindingSource = new BindingSource(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)landlordBindingSource).BeginInit();
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
            btnUserDelete.Location = new Point(652, 322);
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
            dgvUsers.Size = new Size(237, 248);
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1130, 568);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Landlords";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
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
            // landlordBindingSource
            // 
            landlordBindingSource.DataSource = typeof(Landlord);
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
            ((System.ComponentModel.ISupportInitialize)landlordBindingSource).EndInit();
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
    }
}