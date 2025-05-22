public class User
{
    public string Name;
    public string Username;
    public string Password;
    public int OperationCount;

    public User(string name, string username, string password, int count)
    {
        Name = name;
        Username = username;
        Password = password;
        OperationCount = count;
    }

    public string ToCsv()
    {
        return Name + "," + Username + "," + Password + "," + OperationCount;
    }

    public static User FromCsv(string line)
    {
        string[] parts = line.Split(',');
        return new User(parts[0], parts[1], parts[2], int.Parse(parts[3]));
    }
}