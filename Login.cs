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
            else { txtbxPass.PasswordChar = '*';  btnPass.Text = "🔒"; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.Server.Login(txtbxUser.Text.Trim(), txtbxPass.Text.Trim());
            // need to loop due to waiting for server response (could add loading icon?)

            int count = 0;

            while (!Global.Server.receivedResponce)
            {
                count++;
                if (Global.Server.receivedResponce) break;
                if (count == 100) { MessageBox.Show("Failed to connect to the server!"); break; }
                Thread.Sleep(100);
            }

            // set it back to false so it can be repeated for if password is wrong
            Global.Server.receivedResponce = false;

            if (Global.Server.IsLoggedIn)
            {
                this.DialogResult = DialogResult.OK; // signal success
                this.Close(); // close login form (Program.cs will now run Main form)
            }
        }
    }
}
