namespace iLet4You
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Settings.Load();
            Login l = new Login();
            if (l.ShowDialog() == DialogResult.OK) // if login is successful
            {
                Application.Run(new Main()); // start main form
            }
        }
    }
}