namespace MAUI
{
    public partial class OperationsPage : ContentPage
    {
        public OperationsPage()
        {
            InitializeComponent();
            LoadUserData(); // This shows the user data when the page opens
        }

        private void LoadUserData()
        {
            string filePath = "users.csv";
            string currentUsername = Preferences.Get("CurrentUser", ""); // Get the current username from preferences

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                string line = reader.ReadLine();

                // Loop through the file until we find the current user
                while (line != null)
                {
                    User user = User.FromCsv(line);

                    if (user.Username == currentUsername)
                    {
                        nameLabel.Text = "Name: " + user.Name;
                        usernameLabel.Text = "Username: " + user.Username;
                        passwordLabel.Text = "Password: " + user.Password;
                        operationsLabel.Text = "Operations done: " + user.OperationCount;
                        break;
                    }

                    line = reader.ReadLine();
                }

                reader.Close();
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(".."); // back to Conversor
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Preferences.Remove("CurrentUser");
            await Shell.Current.GoToAsync("//MainPage"); // back to Login
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // Close the app
        }
    }
}
