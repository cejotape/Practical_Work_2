# Practical_Work_2

# Table of Contents

1. Introduction
2. Description
3. Class diagram
4. Problems faced
5. Conclusions

# Introduction 
- This document summarizes the development process of the Practical Work II, in which I have had to create a graphical base converter application in a user-friendly way.
- The application has been built using .NET MAUI, it features a complete user system, in which users are able to register, log in, perform numerical base conversions, track their usage (operations), and manage their account.
- It includes a base conversion tool that performs binary, decimal, octal, hexadecimal and two's complement conversions. 
- All data is stored in a CSV file, which everytime a new user is created gets uploaded and starts to track their operations. Following the same pattern, when an existing user logs in, it adds the number of operations to the last number saved.
- This work is meant to show how these basic programming things can built such a nice software as the one that we are recreating.


# Description

- **Login and Registration System**

- Login Page: Allows users to log in and includes a link to a password recovery screen and to the register page.
- Register Page: Includes form validation (matching passwords, minimum length, format requirements, and acceptance of terms).
- Password Validation: Requires one uppercase, one lowercase, one digit, and one special character.
- Forgot Password: Allows the user to recover their password using their username. 


- **Conversion Page**

- Converts values between bases including:
- Decimal ⇄ Binary, Octal, Hexadecimal, Two's Complement
- Binary ⇄ Decimal
- Octal ⇄ Decimal
- Hexadecimal ⇄ Decimal
- Two's Complement ⇄ Decimal
- Each conversion validates the input manually.
- Every successful conversion increases the user’s operation count in users.csv.


- **Operations Page**

- Displays current user’s:
- Name
- Username
- Password
- Number of conversions completed
- Includes navigation options: back, logout, and exit.


- **File Management**

- User data is stored in users.csv in the following format: Name,Username,Password,OperationCount
- Uses StreamReader to read and StreamWriter to write.

# Class diagram

- **User's diagram**
+-----------------------+
|         User          |
+-----------------------+
| - Name : string       |
| - Username : string   |  
| - Password : string   |
| - OperationCount : int|
+-----------------------+
| +ToCsv()              |
| +FromCsv(string)      |
+-----------------------+

- **ConverterWrapper diagram**
+---------------------------------+
|         ConverterWrapper        |
+---------------------------------+
| +DecimalToBinary(string)        |
| +DecimalToTwoComplement(string) |
| +DecimalToOctal(string)         |
| +DecimalToHexadecimal(string)   |
| +BinaryToDecimal(string)        |
| +TwoComplementToDecimal(string) |
| +OctalToDecimal(string)         |
| +HexadecimalToDecimal(string)   |
+---------------------------------+


MAUI Pages:
- MainPage.xaml.cs (Login)
- RegisterPage.xaml.cs
- ForgotPasswordPage.xaml.cs
- ConversorPage.xaml.cs
- OperationsPage.xaml.cs


- **MainPage diagram**
+------------------------------+
|         MainPage             |
+------------------------------+
| - filePath : string          |
+------------------------------+
| +LoadUsers()                 |
| +OnLoginClicked()            |
| +OnRegisterClicked()         |
| +OnForgotPasswordClicked()   |
+------------------------------+

- **RegisterPage diagram**
+------------------------------+
|       RegisterPage           |
+------------------------------+
| +LoadUsers()                 |
| +SaveUsers()                 |
| +IsValidPassword()           |
| +OnRegisterClicked()         |
+------------------------------+

- **ForgotPasswordPage diagram**
+------------------------------+
|    ForgotPasswordPage        |
+------------------------------+
| +LoadUsers()                 |
| +OnRecoverClicked()          |
+------------------------------+

- **ConversorPage diagram**
+------------------------------+
|      ConversorPage           |
+------------------------------+
| +IncrementOperationCount()   |
| +OnKeypadClicked()           |
| +OnClearClicked()            |
| +OnConvertClicked()          |
+------------------------------+

- **OperationsPage diagram**
+------------------------------+
|      OperationsPage          |
+------------------------------+
| +LoadUserData()              |
| +OnBackClicked()             |
| +OnLogoutClicked()           |
| +OnExitClicked()             |
+------------------------------+

# Problems faced
- At the beginning I tried to use JSON serialization, but due to some facts, including that after reading the slides I found easier to do it with a CSV, I ended up using CSV instead of JSON.
- When I first tried to register myself and see if the CSV worked, I found out that it was empty. However, this was rapidly solved by checking the path, which, of course, was incorrect at the registration page.
- While putting the operations of the previous activities I found out that I would need a lot of code, so in order to do it in a more efficient way, I created the ConverterWrapper, which serves as a single access point to all conversion operations. This class saved me a lot of work, so instead of having to instantiate each individual converter class, the wrapper contains static methods that create the correct converter and execute the .Change() method.
- I have had to put a lot of careful while connecting each page, because it is true that I may have tried to connect the Main Page with the Main Page due to a lack of attention, this made me be more aware of where I was programming and putting the buttons.
- While creating the pad of operations, it probably at first sight was the most ugly thing I could have done, but after some minutes of putting rows and columns in a more organizated way it is nice to the sight, since my point of view.

# Conclusions
- It is true that I have learnt many things by doing this, for example how to finally use the StreamReader and StreamWriter tools.
- The most remarkable point as I see it is how I make a lot simpler the code by using the ConvertWrapper class, which simplified a lot the code.
- I have succesfully implemented the validation of the user authentication, including the design of the password and the terms that must be accepted.
- I have seen the importance of having all organized because if not it is a chaos and it complicates a lot the work.
- Despite my performance in the exam this has helped me a lot to program more fluid and to know where to start.
