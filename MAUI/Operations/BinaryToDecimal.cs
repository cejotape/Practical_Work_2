using System;

namespace oppguidedpw
{
    public class BinaryToDecimal : Conversion
    {
        public BinaryToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {

        }
        
        public override string Change(string input)
        {
            // Check if the input is a valid binary number
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '0' && input[i] != '1')
                {
                    throw new FormatException("Bad format: input is not a valid binary number.");
                }
            }
            int decimalValue = 0;
            int baseValue = 1;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == '1')
                {
                    decimalValue += baseValue;
                }
                else if (input[i] != '0')
                {
                    return "Invalid binary number";
                }
                baseValue *= 2;
            }

            return decimalValue.ToString();
        }
    }
}