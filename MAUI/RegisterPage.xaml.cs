namespace MAUI
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private List<User> LoadUsers()
        {
            string filePath = "users.csv";
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                string line = reader.ReadLine();
                while (line != null)
                {
                    users.Add(User.FromCsv(line));
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            return users;
        }

        // Save the users to the CSV file
        private void SaveUsers(List<User> users)
        {
            string filePath = "users.csv";
            StreamWriter writer = new StreamWriter(filePath, false);

            for (int i = 0; i < users.Count; i++)
            {
                writer.WriteLine(users[i].ToCsv());
            }

            writer.Close();
        }

        // Validate the password according to the specified rules
        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 &&
                   password.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()) >= 0 &&
                   password.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) >= 0 &&
                   password.IndexOfAny("0123456789".ToCharArray()) >= 0 &&
                   password.IndexOfAny("!@#€&%/".ToCharArray()) >= 0;
        }

        // When the user clicks the "Register" button, this method is called.
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            string confirmPassword = confirmPasswordEntry.Text;

            // Validate the input fields
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            // Name and username must be different
            if (name == username)
            {
                await DisplayAlert("Error", "Name and username must be different.", "OK");
                return;
            }

            // Passwords must match
            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // Password must meet the specified criteria
            if (!IsValidPassword(password))
            {
                await DisplayAlert("Error", "Password must be at least 8 characters long and include uppercase, lowercase, number, and symbol between these !@#€&%/.", "OK");
                return;
            }

            // User must accept the privacy policy
            if (!termsCheckbox.IsChecked)
            {
                await DisplayAlert("Error", "You must accept the privacy policy.", "OK");
                return;
            }

            // Check if the username already exists
            List<User> users = LoadUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    await DisplayAlert("Error", "That username is already taken.", "OK");
                    return;
                }
            }

            users.Add(new User(name, username, password, 0));
            SaveUsers(users);

            await DisplayAlert("Success", "Account created successfully!", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}