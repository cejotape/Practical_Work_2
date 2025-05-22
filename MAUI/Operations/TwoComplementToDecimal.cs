using System;

namespace oppguidedpw
{
    public class TwoComplementToDecimal : Conversion
    {
        public TwoComplementToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
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

            int n = input.Length;
            bool isNegative = input[0] == '1';

            int result = 0;

            // Check if the number is negative (the first bit is 1)
            if(!isNegative)
            {
                // Convert binary to decimal directly
                for(int i = 0; i < n; i++)
                {
                    int bit = input[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }
            }
            else
            {
                // If negative it applies Two's Complement conversion
                char[] inverted = new char[n];

                // Step 1: Loop to invert all bits
                for(int i = 0; i < n; i++)
                {
                    inverted[i] = input[i] == '0' ? '1' : '0';
                }

                // Step 2: Loop to add 1 to the inverted number
                for(int i = n - 1; i >= 0; i--)
                {
                    if (inverted[i] == '0')
                    {
                        inverted[i] = '1';
                        break;
                    }
                    else
                    {
                        inverted[i] = '0';
                    }
                }

                // Step 3: Loop to convert the final binary number to decimal
                for(int i = 0; i < n; i++)
                {
                    int bit = inverted[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }

                // Apply negative sign because the binary number was negative
                result *= -1;
            }

            return result.ToString();
        }
    }
}