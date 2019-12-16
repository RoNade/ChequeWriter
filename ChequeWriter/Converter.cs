using System;

namespace ChequeWriter
{
    public static class Converter
    {
        public static string DigitToText(int input)
        {
            switch (input)
            {
                case 0: return "";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new IndexOutOfRangeException($"{input} not a digit");
        }

        public static string TeenToText(int input)
        {
            switch (input)
            {
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
            }

            throw new IndexOutOfRangeException($"{input} not a teen");
        }

        public static string TenToText(int input)
        {
            var tenDigit = Convert.ToInt32(Math.Floor(input/10.00));

            var ten = "";
            switch (tenDigit)
            {
                case 2: ten = "twenty"; break;
                case 3: ten = "thirty"; break;
                case 4: ten = "forty"; break;
                case 5: ten = "fifty"; break;
                case 6: ten = "sixty"; break;
                case 7: ten = "seventy"; break;
                case 8: ten = "eighty"; break;
                case 9: ten = "ninety"; break;
            }

            if (!string.IsNullOrEmpty(ten))
            {
                if ((input % 10) == 0) return ten;
                var remainder = input - ((input / 10) * 10);

                var unit = DigitToText(remainder);
                return $"{ten}-{unit}";
            }

            throw new IndexOutOfRangeException($"{input} not in targeted range");
        }

        public static string NumberToText(int input)
        {
            if (input == 0) return "";

            var magnitude = input.ToString().Length;
            var span = (magnitude % 3 != 0) ? magnitude % 3 : 3;
            var selection = input.ToString().Substring(0, span);

            var scale = "";
            if (magnitude >= 4 && magnitude <= 6) scale = " thousand";
            if (magnitude >= 7 && magnitude <= 9) scale = " million";
            if (magnitude >= 10 && magnitude <= 12) scale = " billion";

            var hundredStr = "";
            var tenStr = "";
            var unitStr = "";

            if (selection.Length % 3 == 0)
            {
                var hundred = int.Parse(selection[0].ToString());
                hundredStr = $"{DigitToText(hundred)} hundred";
                selection = selection.Substring(1);

                if (selection != "00")
                {
                    hundredStr += " and ";
                }
            }

            if (selection.Length % 3 == 2)
            {
                var remainder = int.Parse(selection);

                if (remainder >= 10 && remainder <= 19)
                {
                    tenStr = TeenToText(remainder);
                }
                else if (remainder > 19)
                {
                    tenStr = TenToText(remainder);
                }
                else
                {
                    tenStr = DigitToText(remainder);
                }
            }

            if (selection.Length % 3 == 1)
            {
                var unit = int.Parse(selection);
                unitStr = DigitToText(unit);
            }
            
            int.TryParse(input.ToString().Substring(span), out var pending);
            var result = $"{hundredStr + tenStr + unitStr + scale + ((pending != 0) ? ", " : "")}";

            return  result + NumberToText(pending);
        }
    }
}
