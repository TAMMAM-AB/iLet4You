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
            RefreshUsers();
        }

        // Users
        public async void RefreshUsers()
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

        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DeleteUser(dgvUsers.SelectedRows[0].Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString().Trim());
            }
        }

        private void btnUserCreate_Click(object sender, EventArgs e)
        {
            CreateUser(txtbxUsername.Text.Trim(), txtbxPassword.Text, cmbobxUserRoles.Text);
        }




        //Landlords
    }
}
