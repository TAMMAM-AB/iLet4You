namespace iLet4You
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Login l = new Login();
            if (l.ShowDialog() == DialogResult.OK) // if login is successful
            {
                Application.Run(new Main()); // start main form
            }
        }
    }
}