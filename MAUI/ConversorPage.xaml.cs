using oppguidedpw;

namespace MAUI
{
    // This class represents the calculator page of the app.
    public partial class ConversorPage : ContentPage
    {
        public ConversorPage()
        {
            InitializeComponent();
        }

        // Increment the current user's operation count in the users.csv file.
        private void IncrementOperationCount()
        {
            string filePath = "users.csv";
            string username = Preferences.Get("CurrentUser", "");

            List<User> users = new List<User>();

            // Load the users from the file
            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                string line = reader.ReadLine();
                while (line != null)
                {
                    users.Add(User.FromCsv(line)); // Convert each line to a User object
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            // Find the current user and increment its count
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    users[i].OperationCount++;
                    break;
                }
            }

            // Save the updated user list back to the file
            StreamWriter writer = new StreamWriter(filePath, false);
            for (int i = 0; i < users.Count; i++)
            {
                writer.WriteLine(users[i].ToCsv());
            }
            writer.Close();
        }

        // Event handlers for button clicks
        private void OnKeypadClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            inputEntry.Text += button.Text;
        }

        // Clear the input and result labels
        private void OnClearClicked(object sender, EventArgs e)
        {
            inputEntry.Text = "";
            resultLabel.Text = "";
        }

        // Handle the conversion when a button is clicked
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

                // Increment the operation count and display the result
                IncrementOperationCount();
                resultLabel.Text = "Result: " + result;
            }
            catch
            {
                // Handle any exceptions that occur during conversion and reset the fields
                await DisplayAlert("Error", "Invalid input format or conversion error.", "OK");
                inputEntry.Text = "";
                resultLabel.Text = "";
            }
        }

        // Navigate to the operations page
        private async void OnOperationsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OperationsPage));
        }
    }
}
