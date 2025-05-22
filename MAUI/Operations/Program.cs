/*using System;

namespace oppguidedpw
{
    public class Program
    {
        public static void Main()
        {
            Converter converter = new Converter();
            Operations ops = new Operations(";");

            int error;
            string input = "";
            string output = "";
            string errorMessage;

            int operation = converter.PrintOperations();

            while (operation >= 1 && operation <= converter.GetNumberOperations())
            {
                error = 1;

                while (error == 1)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Insert the number to convert: ");

                        input = Console.ReadLine();

                        output = converter.PerformConversion(
                            operation,
                            input);

                        converter.PrintConversion(
                            operation,
                            input,
                            output);

                        error = 0;
                        errorMessage = "";

                    }
                    catch (OverflowException e)
                    {
                        errorMessage = e.Message;
                        Console.WriteLine("Introduce a number or a bit valid for the input ...");
                        Console.ReadLine();
                    }
                    catch (FormatException e)
                    {
                        errorMessage = e.Message;
                        Console.WriteLine("Introduce a valid input for the conversion chosen ...");
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        errorMessage = e.Message;
                        Console.WriteLine("An unknown error has occured.");
                        Console.ReadLine();
                    }

                    ops.AddOperation(input, output, operation, error, errorMessage);
                }

                operation = converter.PrintOperations();
            }
            ops.SaveOperations("output.csv");
        }
    }
}
*/
