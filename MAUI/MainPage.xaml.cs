namespace MAUI
{
	public partial class MainPage : ContentPage
	{
		string filePath = "users.csv";

		public MainPage()
		{
			InitializeComponent();
		}

		private List<User> LoadUsers()
		{
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

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			string username = usernameEntry.Text;
			string password = passwordEntry.Text;
			List<User> users = LoadUsers();
			foreach (User user in users)
			{
				if (user.Username == username && user.Password == password)
				{
					Preferences.Set("CurrentUser", username);
					await DisplayAlert("Welcome", $"Hello, {user.Name}!", "OK");
					await Shell.Current.GoToAsync(nameof(ConversorPage));
					return;
				}
			}
			await DisplayAlert("Error", "Invalid username or password", "OK");
		}

		private async void OnRegisterClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(RegisterPage));
		}

		private async void OnForgotPasswordClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync(nameof(ForgotPasswordPage));
		}

	}
}
