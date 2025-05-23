using oppguidedpw;

namespace MAUI
{
    // This static class acts as a simplified interface to use the conversion classes
    public static class ConverterWrapper
    {
        public static string DecimalToBinary(string input)
        {
            var converter = new DecimalToBinary("DecimalToBinary", "definition");
            return converter.Change(input);
        }

        public static string DecimalToTwoComplement(string input)
        {
            var converter = new DecimalToTwoComplement("DecimalToTwoComplement", "definition");
            return converter.Change(input);
        }

        public static string DecimalToOctal(string input)
        {
            var converter = new DecimalToOctal("DecimalToOctal", "definition");
            return converter.Change(input);
        }

        public static string DecimalToHexadecimal(string input)
        {
            var converter = new DecimalToHexadecimal("DecimalToHexadecimal", "definition");
            return converter.Change(input);
        }

        public static string BinaryToDecimal(string input)
        {
            var converter = new BinaryToDecimal("BinaryToDecimal", "definition");
            return converter.Change(input);
        }

        public static string TwoComplementToDecimal(string input)
        {
            var converter = new TwoComplementToDecimal("TwoComplementToDecimal", "definition");
            return converter.Change(input);
        }

        public static string OctalToDecimal(string input)
        {
            var converter = new OctalToDecimal("OctalToDecimal", "definition");
            return converter.Change(input);
        }

        public static string HexadecimalToDecimal(string input)
        {
            var converter = new HexadecimalToDecimal("HexadecimalToDecimal", "definition");
            return converter.Change(input);
        }
    }
}
