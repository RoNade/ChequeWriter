namespace ChequeWriter
{
    public static class IntExtension
    {
        public static string ToText(this int number)
        {
            return Converter.NumberToText(number);
        }
    }
}
