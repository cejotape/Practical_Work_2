namespace MAUI
{
    public partial class ForgotPasswordPage : ContentPage
    {

        public ForgotPasswordPage()
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

        // When the users clicks the "Recover Password" button, this method is called.
        private void OnRecoverClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                resultLabel.Text = "Please enter your username.";
                return;
            }

            List<User> users = LoadUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    resultLabel.Text = "Your password is: " + users[i].Password;
                    return;
                }
            }

            resultLabel.Text = "Username not found.";
        }
    }
}