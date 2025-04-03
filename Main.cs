namespace iLet4You
{
    public partial class Main : Form
    {
        public Main()
        {
            string username = Global.User?.Username;
            string role = Global.User?.Role;

            InitializeComponent();

            this.Text = $"iLet4You | {username} | {role}";

            // show and enable admin controls button is user is admin
            btnAdmin.Enabled = (role == "admin");
            btnAdmin.Visible = (role == "admin");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            AdminPanel a = new AdminPanel();
            a.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
