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
            Global.Server.Login(txtbxUser.Text.Trim(), txtbxPass.Text.Trim());
            // wait for response - FIX THIS BY DOING ASYNC STUFF INSTEAD isntead of silly while loop
            while (!Global.Server.receivedResponce)
            {
                if (Global.Server.receivedResponce) break;
                Thread.Sleep(100);
            }
            Global.Server.receivedResponce = false;

            if (Global.Server.IsLoggedIn)
            {
                this.DialogResult = DialogResult.OK; // signal success
                this.Close(); // close login form (Program.cs will now run Main form)
            }
        }
    }
}
