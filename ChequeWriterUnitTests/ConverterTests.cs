using NUnit.Framework;
using ChequeWriter;

namespace ChequeWriterUnitTests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCase(1201389099, ExpectedResult = "one billion, two hundred and one million, three hundred and eighty-nine thousand, ninety-nine")]
        [TestCase(100503200, ExpectedResult = "one hundred million, five hundred and three thousand, two hundred")]
        [TestCase(102545, ExpectedResult = "one hundred and two thousand, five hundred and forty-five")]
        [TestCase(25863, ExpectedResult = "twenty-five thousand, eight hundred and sixty-three")]
        [TestCase(5602, ExpectedResult = "five thousand, six hundred and two")]
        [TestCase(415, ExpectedResult = "four hundred and fifteen")]
        [TestCase(1000000000, ExpectedResult = "one billion")]
        [TestCase(3000000, ExpectedResult = "three million")]
        [TestCase(5000, ExpectedResult = "five thousand")]
        [TestCase(57, ExpectedResult = "fifty-seven")]
        [TestCase(30, ExpectedResult = "thirty")]
        [TestCase(12, ExpectedResult = "twelve")]
        [TestCase(8, ExpectedResult = "eight")]
        [TestCase(0, ExpectedResult = "")]
        public string ConversionTest(int input)
        {
            return Converter.NumberToText(input);
        }
    }
}
