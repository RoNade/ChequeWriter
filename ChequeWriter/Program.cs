using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ChequeWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var stop = false;

            do
            {

                Console.Write("Enter a numerical monetary amount between one cent and two billion dollars: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    var pattern = @"^(?<Dollars>\d{0,10})?(?:\.(?<Cents>\d{2}))?$";
                    var match = Regex.Match(input, pattern, RegexOptions.Multiline);

                    if (match.Success)
                    {
                        int.TryParse(match.Groups["Dollars"].Value, out var dollars);
                        int.TryParse(match.Groups["Cents"].Value, out var cents);

                        if ((dollars > 2000000000) || (dollars == 0 && cents == 0) || (dollars == 2000000000 && cents > 0) )
                        {
                            Console.WriteLine("The input must be within the specified range !\n");
                            continue;
                        }

                        var sb = new StringBuilder();

                        if (dollars > 0)
                        {
                            sb.Append($"{dollars.ToText()} dollar{((dollars > 1) ? "s" : "")}");
                        }

                        if (cents > 0)
                        {
                            if (dollars > 0)
                            {
                                sb.Append(" and ");
                            }

                            sb.Append($"{cents.ToText()} cent{((cents > 1) ? "s" : "")}");
                        }

                        Console.WriteLine($"You entered: '{sb}'\n");
                    }
                    else
                    {
                        Console.WriteLine("The input must respect the formats #.##, .## or # !\n");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please provide an input!\n");
                    continue;
                }

                var confirmation = false;

                do
                {

                    Console.Write("Enter \"ok\" to continue or \"exit\" to terminate: ");
                    var command = Console.ReadLine();

                    if (command.ToLower().Trim() == "ok")
                    {
                        confirmation = true;
                        Console.WriteLine();
                    }
                    else if (command.ToLower().Trim() == "exit")
                    {
                        confirmation = true;
                        stop = true;
                    }

                } while (!confirmation);
                
            } while (!stop);
        }
    }
}
