using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace uCalc
{
    class Math
    {
        public static class Converter
        {
            public static class Temperature
            {
                public static class Reaumur
                {

                    public static double ToFahrenheit(double reaumur)
                    {
                        return ((reaumur / 0.8) * 1.8) + 32;
                    }

                    public static double ToCelsius(double reaumur)
                    {
                        return reaumur / 0.8;
                    }
                    public static double ToKelvin(double reaumur)
                    {
                        return (reaumur / 0.8) + 273.15;
                    }

                    public static double ToRankine(double reaumur)
                    {
                        return reaumur * 2.2500 + 491.67;
                    }
                }

                public static class Rankine
                {
                    public static double ToFahrenheit(double rankine)
                    {
                        return (rankine - 491.67) + 32.00;
                    }

                    public static double ToCelsius(double rankine)
                    {
                        return (rankine - 491.67) / 1.8;
                    }

                    public static double ToKelvin(double rankine)
                    {
                        return ((rankine - 491.67) / 1.8) + 273.15;
                    }
                    public static double ToReaumur(double rankine)
                    {
                        return (rankine - 491.67) / 2.25;
                    }
                }

                public static class Kelvin
                {
                    public static double ToCelsius(double kelvin)
                    {
                        return kelvin - 273.15;
                    }

                    public static double ToFahrenheit(double kelvin)
                    {
                        return (kelvin - 273.15) * 1.8 + 32.00;
                    }

                    public static double ToRankine(double kelvin)
                    {
                        return kelvin * 1.8;
                    }
                    public static double ToReaumur(double kelvin)
                    {
                        return (kelvin - 273.15) * 0.8;
                    }
                }

                public static class Celsius
                {
                    public static double ToKelvin(double celsius)
                    {
                        return celsius + 273.15;
                    }

                    public static double ToFahrenheit(double celsius)
                    {
                        return (celsius * 1.8) + 32;
                    }

                    public static double ToRankine(double celsius)
                    {
                        return (celsius * 1.8) + 491.67;
                    }

                    public static double ToReaumur(double celsius)
                    {
                        return celsius * 0.8;
                    }
                }

                public static class Fahrenheit
                {
                    public static double ToKelvin(double fahrenheit)
                    {
                        double x = 5; double y = 9; double z = (fahrenheit - (double)32) * (x / y) + (double)273.15;
                        return z;
                    }

                    public static double ToCelsius(double fahrenheit)
                    {
                        return (fahrenheit - 32) / 1.8;
                    }

                    public static double ToRankine(double fahrenheit)
                    {
                        double z = fahrenheit + (double)459.67;
                        return z;
                    }

                    public static double ToReaumur(double fahrenheit)
                    {
                        return (fahrenheit - (double)32) / (double)1.8 * (double)0.8;
                    }
                }
            }
            public static class Mass
            {
                public static class Ton
                {
                    public static double ToKilogram(double ton)
                    {
                        return ton * 1000;
                    }
                    public static double ToGram(double ton)
                    {
                        return ton * 1000000;
                    }
                    public static double ToMilligram(double ton)
                    {
                        return ton * 1000000000;
                    }
                    public static double ToMicrogram(double ton)
                    {
                        return ton * 1000000000000;
                    }
                    public static double ToLongTon(double ton)
                    {
                        return ton / 1.016;
                    }
                    public static double ToShortTon(double ton)
                    {
                        return ton / 1.102;
                    }
                    public static double ToStone(double ton)
                    {
                        return ton / 157.473;
                    }
                    public static double ToPound(double ton)
                    {
                        return ton / 0.00045359237;
                    }
                    public static double ToOunce(double ton)
                    {
                        return ton * (double)1000000 / 28.34952;
                    }
                }
                public static class Kilogram
                {
                    public static double ToTon(double kilogram)
                    {
                        return kilogram / 1000;
                    }
                    public static double ToGram(double kilogram)
                    {
                        return kilogram * 1000;
                    }
                    public static double ToMilligram(double kilogram)
                    {
                        return kilogram * 1000000;
                    }
                    public static double ToMicrogram(double kilogram)
                    {
                        return kilogram * 1000000000;
                    }
                    public static double ToLongTon(double kilogram)
                    {
                        return kilogram * 0.000984;
                    }
                    public static double ToShortTon(double kilogram)
                    {
                        return kilogram * 0.0011023;
                    }
                    public static double ToStone(double kilogram)
                    {
                        return kilogram * 0.15747;
                    }
                    public static double ToPound(double kilogram)
                    {
                        return kilogram * 2.2046;
                    }
                    public static double ToOunce(double kilogram)
                    {
                        return kilogram * 35.274;
                    }
                }
                public static class Gram
                {
                    public static double ToTon(double gram)
                    {
                        return gram / 1000000;
                    }
                    public static double ToKilogram(double gram)
                    {
                        return gram / 1000;
                    }
                    public static double ToMilligram(double gram)
                    {
                        return gram * 1000;
                    }
                    public static double ToMicrogram(double gram)
                    {
                        return gram * 1000000;
                    }
                    public static double ToLongTon(double gram)
                    {
                        return gram * 0.00000098421;
                    }
                    public static double ToShortTon(double gram)
                    {
                        return gram * 0.0000011023;
                    }
                    public static double ToStone(double gram)
                    {
                        return gram * 0.00015747;
                    }
                    public static double ToPound(double gram)
                    {
                        return gram * 0.0022046;
                    }
                    public static double ToOunce(double gram)
                    {
                        return gram * 0.035274;
                    }
                }
                public static class Milligram
                {
                    public static double ToTon(double milligram)
                    {
                        return milligram / 1000000000;
                    }
                    public static double ToKilogram(double milligram)
                    {
                        return milligram / 1000000;
                    }
                    public static double ToGram(double milligram)
                    {
                        return milligram / 1000;
                    }
                    public static double ToMicrogram(double milligram)
                    {
                        return milligram * 1000;
                    }
                    public static double ToLongTon(double milligram)
                    {
                        return milligram * 0.00000000098421;
                    }
                    public static double ToShortTon(double milligram)
                    {
                        return milligram * 0.0000000011023;
                    }
                    public static double ToStone(double milligram)
                    {
                        return milligram * 0.00000015747;
                    }
                    public static double ToPound(double milligram)
                    {
                        return milligram * 0.0000022046;
                    }
                    public static double ToOunce(double milligram)
                    {
                        return milligram * 0.000035274;
                    }
                }
                public static class Microgram
                {
                    public static double ToTon(double microgram)
                    {
                        return microgram / 1000000000000;
                    }
                    public static double ToKilogram(double microgram)
                    {
                        return microgram / 1000000000;
                    }
                    public static double ToGram(double microgram)
                    {
                        return microgram / 1000000000;
                    }
                    public static double ToMilligram(double microgram)
                    {
                        return microgram / 1000;
                    }
                    public static double ToLongTon(double microgram)
                    {
                        return microgram * 0.00000000000098421;
                    }
                    public static double ToShortTon(double microgram)
                    {
                        return microgram * 0.0000000000011023;
                    }
                    public static double ToStone(double microgram)
                    {
                        return microgram * 0.00000000015747;
                    }
                    public static double ToPound(double microgram)
                    {
                        return microgram * 0.0000000022046;
                    }
                    public static double ToOunce(double microgram)
                    {
                        return microgram * 0.000000035274;
                    }
                }
                public static class LongTon
                {
                    public static double ToTon(double longton)
                    {
                        return longton / 0.98421;
                    }
                    public static double ToKilogram(double longton)
                    {
                        return longton / 0.00098421;
                    }
                    public static double ToGram(double longton)
                    {
                        return longton / 0.00000098421;
                    }
                    public static double ToMilligram(double longton)
                    {
                        return longton / 0.00000000098421;
                    }
                    public static double ToMicrogram(double longton)
                    {
                        return longton / 0.00000000000098421;
                    }
                    public static double ToShortTon(double longton)
                    {
                        return longton * 1.12;
                    }
                    public static double ToStone(double longton)
                    {
                        return longton * 160;
                    }
                    public static double ToPound(double longton)
                    {
                        return longton * 2240;
                    }
                    public static double ToOunce(double longton)
                    {
                        return longton * 35840;
                    }
                }
                public static class ShortTon
                {
                    public static double ToTon(double shortton)
                    {
                        return shortton / 1.1023;
                    }
                    public static double ToKilogram(double shortton)
                    {
                        return shortton / 0.0011023;
                    }
                    public static double ToGram(double shortton)
                    {
                        return shortton / 0.0000011023;
                    }
                    public static double ToMilligram(double shortton)
                    {
                        return shortton / 0.0000000011023;
                    }
                    public static double ToMicrogram(double shortton)
                    {
                        return shortton / 0.0000000000011023;
                    }
                    public static double ToLongTon(double shortton)
                    {
                        return shortton * 0.89286;
                    }
                    public static double ToStone(double shortton)
                    {
                        return shortton * 142.86;
                    }
                    public static double ToPound(double shortton)
                    {
                        return shortton * 2000;
                    }
                    public static double ToOunce(double shortton)
                    {
                        return shortton * 32000;
                    }
                }
                public static class Stone
                {
                    public static double ToTon(double stone)
                    {
                        return stone / 157.47;
                    }
                    public static double ToKilogram(double stone)
                    {
                        return stone / 0.15747;
                    }
                    public static double ToGram(double stone)
                    {
                        return stone / 0.00015747;
                    }
                    public static double ToMilligram(double stone)
                    {
                        return stone / 0.00000015747;
                    }
                    public static double ToMicrogram(double stone)
                    {
                        return stone / 0.00000000015747;
                    }
                    public static double ToLongTon(double stone)
                    {
                        return stone * 0.0062500;
                    }
                    public static double ToShortTon(double stone)
                    {
                        return stone * 0.0070000;
                    }
                    public static double ToPounds(double stone)
                    {
                        return stone * 14;
                    }
                    public static double ToOunce(double stone)
                    {
                        return stone * 224;
                    }
                }
                public static class Pound
                {
                    public static double ToTon(double pound)
                    {
                        return pound / 2204.6;
                    }
                    public static double ToKilogram(double pound)
                    {
                        return pound / 2.2046;
                    }
                    public static double ToGram(double pound)
                    {
                        return pound / 0.0022046;
                    }
                    public static double ToMilligram(double pound)
                    {
                        return pound / 0.0000022046;
                    }
                    public static double ToMicrogram(double pound)
                    {
                        return pound / 0.0000000022046;
                    }
                    public static double ToLongTon(double pound)
                    {
                        return pound * 0.00044643;
                    }
                    public static double ToShortTon(double pound)
                    {
                        return pound * 0.00050000;
                    }
                    public static double ToStone(double pound)
                    {
                        return pound * 0.071429;
                    }
                    public static double ToOunce(double pound)
                    {
                        return pound * 16;
                    }
                }
                public static class Ounce
                {
                    public static double ToTon(double ounce)
                    {
                        return ounce / 35274;
                    }
                    public static double ToKilogram(double ounce)
                    {
                        return ounce / 35.274;
                    }
                    public static double ToGram(double ounce)
                    {
                        return ounce / 0.035274;
                    }
                    public static double ToMilligram(double ounce)
                    {
                        return ounce / 0.000035274;
                    }
                    public static double ToMicrogram(double ounce)
                    {
                        return ounce / 0.000000035274;
                    }
                    public static double ToLongTon(double ounce)
                    {
                        return ounce * 0.000027902;
                    }
                    public static double ToShortTon(double ounce)
                    {
                        return ounce * 0.000031250;
                    }
                    public static double ToStone(double ounce)
                    {
                        return ounce * 0.0044643;
                    }
                    public static double ToPound(double ounce)
                    {
                        return ounce * 0.062500;
                    }
                }
            }
        }

        /// <summary>
        /// Calculates a string based math task. Accepts brackets, exponentials and obeys math rules.
        /// </summary>
        /// <param name="task">The task string to be calculated</param>
        /// <returns></returns>
        public static double CalculateString(string task)
        {
            task = task.Trim();
            while (task.Contains("  "))
                task = task.Replace("  ", "");

            bool unclosedBrackets = task.Count(c => c == '(') != task.Count(c => c == ')');
            bool onlyValidCharacters = new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\))*$").IsMatch(task);
            bool wrongFormat = new Regex(@"((\+|\-|\*|\/|\(|^)(\^|\)|$)|(\^|\/|\()($|\+|\*|\/|\))|(\/|\*)(\/|\*)|\d\(|\)\d|\($)").IsMatch(task);
            bool rightSyntax = onlyValidCharacters && !wrongFormat && !unclosedBrackets;
            if (rightSyntax)
            {
                // Exponents
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)\^(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)").Matches(task))
                {
                    string[] splittedTask = match.Value.Split('^');
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = System.Math.Pow(firstNumber, secondNumber);
                    if ((firstNumber < 0 && secondNumber < 0) || (firstNumber > 0 && secondNumber < 0 && secondNumber % 2 != 0))
                        result = result * -1;

                    task = task.Replace(match.Value, result.ToString("N5").Replace(",", "."));
                }

                // Brackets
                while (task.Contains('('))
                {
                    string subtask = new Regex(@"\((\d|\.|\+|\-|\*|\/)*\)").Match(task).Value;
                    task = task.Replace(subtask, CalculateString(subtask.Substring(1, subtask.Length - 2)).ToString("N5").Replace(",", "."));
                }

                // Multiply / Divide
                while (task.Contains('*') || task.Contains('/'))
                {
                    string subtask = new Regex(@"((\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)(\*|\/)(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)){1}").Match(task).Value;
                    char op = subtask.Contains("*") ? '*' : '/';
                    string[] splittedTask = subtask.Split(op);
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = op == '*' ? firstNumber * secondNumber : firstNumber / secondNumber;
                    //task = task.Replace(subtask, result.ToString("N5").Replace(",", "."));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N5").Replace(',', '.'), 1);
                }

                // Summation / Substraction
                while ((task.Contains('+') || task.Contains('-')) && !(new Regex(@"^\-\d+(\.\d+)?$").IsMatch(task)))
                {
                    string subtask = new Regex(@"((\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)(\+|\-)(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)){1}").Match(task).Value;
                    char op = subtask.Contains("+") ? '+' : '-';
                    string[] splittedTask = subtask.Split(op);
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = op == '+' ? firstNumber + secondNumber : firstNumber - secondNumber;
                    //task = task.Replace(subtask, result.ToString("N5").Replace(",", "."));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N5").Replace(',', '.'), 1);
                }


                if (new Regex(@"^\-?\d+(\.\d+)$").IsMatch(task))
                    return double.Parse(task.Replace(',', '.'), CultureInfo.InvariantCulture);
                else
                    return double.NaN;
            }
            else
                return double.NaN;
        }
    }
}
