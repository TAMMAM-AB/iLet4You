namespace iLet4You
{
    public partial class AdminPanel : Form
    {
        public static AdminPanel? Instance { get; private set; }
        // server response
        private static TaskCompletionSource<bool> result = new();
        public static void ResultReceived(bool success)
        {
            if (!result.Task.IsCompleted)
            {
                result.SetResult(success);
            }
        }
        private async Task<bool> AwaitResponse()
        {
            Task delayTask = Task.Delay(5000); // timeout after 5 seconds
            Task completedTask = await Task.WhenAny(result.Task, delayTask);

            return completedTask == result.Task && result.Task.Result;
        }

        public AdminPanel()
        {
            InitializeComponent();

            cmbobxUserRoles.SelectedIndex = 0;

            RefreshUsers();
            RefreshData();
        }

        // users
        private async void RefreshUsers()
        {
            Global.Server.RequestUsers();
            bool success = await AwaitResponse(); // wait for response
            dgvUsers.DataSource = Global.Users?.GetAll();
        }

        private async void DeleteUser(string username)
        {
            Global.Server.RequestDeleteUser(username);
            bool success = await AwaitResponse();
        }

        private async void CreateUser(string username, string password, string role)
        {
            Global.Server.RequestCreateUser(username, password, role);
            bool success = await AwaitResponse();
        }

        private async void UpdatePassword(string username, string password)
        {
            Global.Server.RequestUpdatePassword(username, password);
            bool success = await AwaitResponse();
        }

        // landlords
        private async void DeleteLandlord()
        {
            // CONTINUE
            bool success = await AwaitResponse();
        }


        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string username = dgvUsers.SelectedRows[0].Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString().Trim();
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the account '{username}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteUser(username);
                }
            }
        }

        private void btnUserCreate_Click(object sender, EventArgs e)
        {
            CreateUser(txtbxUsername.Text.Trim(), txtbxPassword.Text, cmbobxUserRoles.Text);
            txtbxUsername.Text = "";
            txtbxPassword.Text = "";
        }
        private void btnUserUpdatePass_Click(object sender, EventArgs e)
        {
            string username = dgvUsers.SelectedRows[0].Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString().Trim();
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update password for the account '{username}'?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdatePassword(username, txtbxPassword.Text);
            }
            txtbxPassword.Text = "";
        }

        // data
        private async void RefreshData()
        {
            Global.Server.RequestData();
            bool success = await AwaitResponse(); // wait for response
            dgvLandlords.DataSource = Global.Landlords?.GetAll();
            dgvTenants.DataSource = Global.Tenants?.GetAll();
            dgvProperties.DataSource = Global.Properties?.GetAll();
            dgvMaintenances.DataSource = Global.Maintenances?.GetAll();
            dgvQuickLinks.DataSource = Global.QuickLinks?.GetAll();
        }

        private void btnLandlordRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnTenantRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnPropertyRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnQuickLinkRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnMaintenanceRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
