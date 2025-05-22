using oppguidedpw;

namespace MAUI
{
    public partial class ConversorPage : ContentPage
    {
        public ConversorPage()
        {
            InitializeComponent();
        }

        // Increments the current user's operation count in the users.csv file.
        private void IncrementOperationCount()
        {
            string filePath = "users.csv";
            string username = Preferences.Get("CurrentUser", "");

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

            // Finds the current user and increment its count
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    users[i].OperationCount++;
                    break;
                }
            }

            // Saves the updated user list back to the file
            StreamWriter writer = new StreamWriter(filePath, false);
            for (int i = 0; i < users.Count; i++)
            {
                writer.WriteLine(users[i].ToCsv());
            }
            writer.Close();
        }

        private void OnKeypadClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            inputEntry.Text += button.Text;
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            inputEntry.Text = "";
            resultLabel.Text = "";
        }

        private async void OnConvertClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input = inputEntry.Text;
            string command = button.CommandParameter.ToString();
            string result = "";
            try
            {
                switch (command)
                {
                    case "DecimalToBinary":
                        result = ConverterWrapper.DecimalToBinary(input);
                        break;
                    case "DecimalToTwoComplement":
                        result = ConverterWrapper.DecimalToTwoComplement(input);
                        break;
                    case "DecimalToOctal":
                        result = ConverterWrapper.DecimalToOctal(input);
                        break;
                    case "DecimalToHexadecimal":
                        result = ConverterWrapper.DecimalToHexadecimal(input);
                        break;
                    case "BinaryToDecimal":
                        result = ConverterWrapper.BinaryToDecimal(input);
                        break;
                    case "TwoComplementToDecimal":
                        result = ConverterWrapper.TwoComplementToDecimal(input);
                        break;
                    case "OctalToDecimal":
                        result = ConverterWrapper.OctalToDecimal(input);
                        break;
                    case "HexadecimalToDecimal":
                        result = ConverterWrapper.HexadecimalToDecimal(input);
                        break;
                }

                IncrementOperationCount();
                resultLabel.Text = "Result: " + result;
            }
            catch
            {
                await DisplayAlert("Error", "Invalid input format or conversion error.", "OK");
                inputEntry.Text = "";
                resultLabel.Text = "";
            }
        }

        private async void OnOperationsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OperationsPage));
        }
    }
}
