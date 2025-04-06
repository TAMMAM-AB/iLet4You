namespace iLet4You
{
    partial class QuickLinksManager
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
            btnQuickLinkRefresh = new Button();
            dgvQuickLinks = new DataGridView();
            quickLinkIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uRLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quickLinkBindingSource = new BindingSource(components);
            label1 = new Label();
            txtbxName = new TextBox();
            txtbxURL = new TextBox();
            label2 = new Label();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvQuickLinks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quickLinkBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnQuickLinkRefresh
            // 
            btnQuickLinkRefresh.Location = new Point(554, 434);
            btnQuickLinkRefresh.Name = "btnQuickLinkRefresh";
            btnQuickLinkRefresh.Size = new Size(100, 23);
            btnQuickLinkRefresh.TabIndex = 16;
            btnQuickLinkRefresh.Text = "Refresh List";
            btnQuickLinkRefresh.UseVisualStyleBackColor = true;
            btnQuickLinkRefresh.Click += btnQuickLinkRefresh_Click;
            // 
            // dgvQuickLinks
            // 
            dgvQuickLinks.AllowUserToAddRows = false;
            dgvQuickLinks.AllowUserToDeleteRows = false;
            dgvQuickLinks.AutoGenerateColumns = false;
            dgvQuickLinks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuickLinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuickLinks.Columns.AddRange(new DataGridViewColumn[] { quickLinkIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, uRLDataGridViewTextBoxColumn });
            dgvQuickLinks.DataSource = quickLinkBindingSource;
            dgvQuickLinks.Location = new Point(12, 10);
            dgvQuickLinks.MultiSelect = false;
            dgvQuickLinks.Name = "dgvQuickLinks";
            dgvQuickLinks.ReadOnly = true;
            dgvQuickLinks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuickLinks.Size = new Size(642, 371);
            dgvQuickLinks.TabIndex = 15;
            // 
            // quickLinkIdDataGridViewTextBoxColumn
            // 
            quickLinkIdDataGridViewTextBoxColumn.DataPropertyName = "QuickLinkId";
            quickLinkIdDataGridViewTextBoxColumn.HeaderText = "ID";
            quickLinkIdDataGridViewTextBoxColumn.Name = "quickLinkIdDataGridViewTextBoxColumn";
            quickLinkIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            uRLDataGridViewTextBoxColumn.HeaderText = "URL";
            uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            uRLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quickLinkBindingSource
            // 
            quickLinkBindingSource.DataSource = typeof(QuickLink);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 387);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 17;
            label1.Text = "Name:";
            // 
            // txtbxName
            // 
            txtbxName.Location = new Point(12, 405);
            txtbxName.Name = "txtbxName";
            txtbxName.Size = new Size(218, 23);
            txtbxName.TabIndex = 18;
            // 
            // txtbxURL
            // 
            txtbxURL.Location = new Point(236, 405);
            txtbxURL.Name = "txtbxURL";
            txtbxURL.Size = new Size(418, 23);
            txtbxURL.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 387);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 19;
            label2.Text = "URL / filepath:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(342, 434);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 23);
            btnUpdate.TabIndex = 45;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(236, 434);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 23);
            btnCreate.TabIndex = 44;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(448, 434);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 23);
            btnDelete.TabIndex = 43;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // QuickLinksManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 498);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(btnDelete);
            Controls.Add(txtbxURL);
            Controls.Add(label2);
            Controls.Add(txtbxName);
            Controls.Add(label1);
            Controls.Add(btnQuickLinkRefresh);
            Controls.Add(dgvQuickLinks);
            Name = "QuickLinksManager";
            Text = "QuickLinksManager";
            ((System.ComponentModel.ISupportInitialize)dgvQuickLinks).EndInit();
            ((System.ComponentModel.ISupportInitialize)quickLinkBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnQuickLinkRefresh;
        private DataGridView dgvQuickLinks;
        private DataGridViewTextBoxColumn quickLinkIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private BindingSource quickLinkBindingSource;
        private Label label1;
        private TextBox txtbxName;
        private TextBox txtbxURL;
        private Label label2;
        private Button btnUpdate;
        private Button btnCreate;
        private Button btnDelete;
    }
}