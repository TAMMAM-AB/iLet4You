namespace iLet4You
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // server response
        private static TaskCompletionSource<bool> loginResult = new();
        public static void ResultReceived(bool success)
        {
            if (!loginResult.Task.IsCompleted)
            {
                loginResult.SetResult(success);
            }
        }
        private async Task<bool> AwaitResponse()
        {
            Task delayTask = Task.Delay(5000); // timeout after 5 seconds
            Task completedTask = await Task.WhenAny(loginResult.Task, delayTask);

            return completedTask == loginResult.Task && loginResult.Task.Result;
        }

        // win forms
        private void btnPass_Click(object sender, EventArgs e)
        {
            if (txtbxPass.PasswordChar == '*') { txtbxPass.PasswordChar = '\0'; btnPass.Text = "🔓"; }
            else { txtbxPass.PasswordChar = '*'; btnPass.Text = "🔒"; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void txtbxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnLogin.Enabled) LogIn();
        }

        private async void LogIn()
        {
            if (String.IsNullOrWhiteSpace(txtbxUser.Text))
                return;

            btnLogin.Enabled = false; // Disable button
            Cursor = Cursors.WaitCursor;

            loginResult = new();

            Global.Server.Login(txtbxUser.Text.Trim(), txtbxPass.Text.Trim());

            bool success = await AwaitResponse(); // wait for response

            btnLogin.Enabled = true;
            Cursor = Cursors.Default;

            if (success)
            {
                if (Global.Server.IsLoggedIn)
                {
                    this.DialogResult = DialogResult.OK; // signal success
                    this.Close(); // close Login form (Main form will open)
                }
            }
            else
            {
                Thread.Sleep(1000); // avoid spam
            }
        }
    }
}
