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
            if (txtbxPass.PasswordChar == '*') txtbxPass.PasswordChar = '\0';
            else txtbxPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.wsServer.Login(txtbxUser.Text.Trim(), txtbxPass.Text.Trim());
            // wait for response
            while (!Global.wsServer.receivedResponce)
            {
                if (Global.wsServer.receivedResponce) break;
                Thread.Sleep(100);
            }
            Global.wsServer.receivedResponce = false;

            if (Global.wsServer.loggedIn)
            {
                this.DialogResult = DialogResult.OK; // signal success
                this.Close(); // close login form (Program.cs will now run Main form)
            }
        }
    }
}
