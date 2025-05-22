using System;

namespace oppguidedpw
{
    public class OctalToDecimal : Conversion
    {
        public OctalToDecimal(string name, string definition) : base(name, definition, new OctalInputValidator())
        {

        }

        public override string Change(string input)
        {
            // Check if the input is a valid octal number
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '7')
                {
                    throw new FormatException("Bad format: input is not a valid octal number.");
                }
            }
            int decimalValue = 0;
            int length = input.Length;

            for(int i = 0; i < length; i++)
            {
                char digitChar = input[i];
                int digit = digitChar - '0';
                int power = length - i - 1;

                decimalValue += digit * (int) Math.Pow(8, power);
            }

            return decimalValue.ToString();
        }
    }
}