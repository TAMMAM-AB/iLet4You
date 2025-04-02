namespace iLet4You
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

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

            btnLogin.Enabled = false; // disable button to prevent multiple clicks
            Cursor = Cursors.WaitCursor; // show loading cursor

            Global.Server.Login(txtbxUser.Text.Trim(), txtbxPass.Text.Trim());
            await Global.Server.AwaitResponse();

            btnLogin.Enabled = true; // re enable button
            Cursor = Cursors.Default; // restore cursor

            if (Global.Server.IsLoggedIn)
            {
                this.DialogResult = DialogResult.OK; // signal success
                this.Close(); // close Login form (Main form will open)
            }

            // server responded, but login failed (wrong password, etc.)
            // MessageBox.Show("Incorrect username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
