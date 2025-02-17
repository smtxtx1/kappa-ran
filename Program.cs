using LOGIN;
namespace Kappa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)  // Show the login form and check if login was successful
            {
                Application.Run(new Form1());  // Run the main form only if login is successful
            }
        }
    }
}