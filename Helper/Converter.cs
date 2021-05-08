using System.Text.RegularExpressions;
using System;

namespace RomanToNumericMicroservice.Helper
{
    public class Converter : IConverter
    {
        private const string romanPattern = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex romanNumberRegex;
        public Converter()
        {
            romanNumberRegex = new Regex(romanPattern, RegexOptions.IgnoreCase);
        }
        public int RomanToNumeric(string romanstring)
        {
            validateRomanNumber(romanstring);
            return computerRomanToNumeric(romanstring);
        }

        private void validateRomanNumber(string romanstring)
        {
            if (string.IsNullOrEmpty(romanstring))
            {
                throw new ArgumentException($"Number is Null or Empty");
            }
            if (!romanNumberRegex.IsMatch(romanstring))
            {
                throw new ArgumentException($"{romanstring} number is not a roman number");
            }
        }

        private int computerRomanToNumeric(string romanstring)
        {
            int numericNumber = 0;

            for (int i = 0; i < romanstring.Length; i++)
            {
                var currentValue = romanstring.Substring(i, 1).ToRomanEnum();
                var NextValue = i != romanstring.Length - 1 ? romanstring.Substring(i + 1, 1).ToRomanEnum() : 0;

                if (currentValue < NextValue)
                    numericNumber -= (int)currentValue;
                else
                    numericNumber += (int)currentValue;
            }

            return numericNumber;
        }
    }
}