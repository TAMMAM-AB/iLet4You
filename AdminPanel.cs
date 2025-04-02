namespace iLet4You
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
            RefreshUsers();
        }

        private async void RefreshUsers()
        {
            Global.Server.RequestUsers();
            await Global.Server.AwaitResponse();
            dgvUsers.DataSource = Global.Users?.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }
    }
}
