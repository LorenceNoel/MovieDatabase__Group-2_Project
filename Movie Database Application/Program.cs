using System;
using System.Windows.Forms;
using Movie_Database_Application.Forms;

namespace Movie_Database_Application
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    string username = loginForm.Username;
                    bool isAdmin = loginForm.IsAdmin;
                    int userId = loginForm.UserID;

                    Application.Run(new UserProfileForm(username, isAdmin, userId));
                }
            }
        }
    }
}