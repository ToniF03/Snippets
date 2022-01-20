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
                    public static double ToLongTons(double ton)
                    {
                        return ton / 1.016;
                    }
                    public static double ToShortTons(double ton)
                    {
                        return ton / 1.102;
                    }
                    public static double ToStones(double ton)
                    {
                        return ton / 157.473;
                    }
                    public static double ToPounds(double ton)
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

        public static double CalculateString(string task)
        {
            if (!new Regex(@"([\*\/\+][\*\/\+\)])").IsMatch(task) && !task.Contains("()") && !new Regex(@"\d{1,},\d{1,},").IsMatch(task))
            {
                string _task = task;
                Regex regex = new Regex(@"(\([0-9,\+\-\*\/]{1,}\))(?!.*\1)");

                if (new Regex(@"([0-9]\()").IsMatch(_task))
                {
                    string s = new Regex(@"([0-9]\()").Match(_task).ToString();
                    _task = _task.Replace(s, s.Substring(0, s.Length - 1) + "*)");
                }

                while (regex.IsMatch(_task))
                {
                    string intermediateTask = regex.Match(_task).ToString();
                    _task = _task.Replace(intermediateTask, CalculateString(intermediateTask.Substring(1, intermediateTask.Length - 2)).ToString());
                }

                regex = new Regex(@"(([^0-9]\-(\d{1,},\d{1,}|\d{1,})|(\d{1,},\d{1,}|\d{1,}))[\/\*](\-(\d{1,},\d{1,}|\d{1,})|(\d{1,},\d{1,}|\d{1,})))");
                string intermediateTask2 = regex.Match(_task).ToString();

                while (_task.Contains('*') || _task.Contains('/'))
                {
                    if (intermediateTask2.Contains("/"))
                    {
                        double Number1 = 0;
                        double Number2 = 0;

                        string[] splitted = intermediateTask2.Split('/');

                        if (splitted[0].Substring(0, 1) == "(" || splitted[0].Substring(0, 1) == "+" || (splitted[0].Length >= 2 && splitted[0].Substring(0, 2) == "--")) splitted[0] = splitted[0].Substring(1);
                        if (intermediateTask2.Substring(0, 1) == "(" || intermediateTask2.Substring(0, 1) == "+" || intermediateTask2.Substring(0, 2) == "--") intermediateTask2 = intermediateTask2.Substring(1);

                        Number1 = double.Parse(splitted[0]);
                        Number2 = double.Parse(splitted[1]);

                        if (Number2 != 0)
                            _task = _task.Replace(intermediateTask2, (Number1 / Number2).ToString());
                        else
                            return double.NaN;

                        intermediateTask2 = regex.Match(_task).ToString();
                    }
                    else if (intermediateTask2.Contains("*"))
                    {
                        double Number1 = 0;
                        double Number2 = 0;

                        string[] splitted = intermediateTask2.Split('*');

                        if (splitted[0].Substring(0, 1) == "(" || splitted[0].Substring(0, 1) == "+" || (splitted[0].Length >= 2 && splitted[0].Substring(0, 2) == "--")) splitted[0] = splitted[0].Substring(1);


                        Number1 = double.Parse(splitted[0]);
                        Number2 = double.Parse(splitted[1]);

                        _task = _task.Replace(intermediateTask2, (Number1 * Number2).ToString());

                        intermediateTask2 = regex.Match(_task).ToString();
                    }
                }

                regex = new Regex(@"((\-(\d{1,},\d{1,}|\d{1,})|(\d{1,},\d{1,}|\d{1,}))[\+\-](\-(\d{1,},\d{1,}|\d{1,})|(\d{1,},\d{1,}|\d{1,})))");
                intermediateTask2 = regex.Match(_task).ToString();

                if (!new Regex(@"^(\d+|\d+,\d+)$").IsMatch(_task.Substring(1)))
                {
                    while ((_task.Contains('-') || _task.Contains('+')) && !new Regex(@"^(\d+|\d+,\d+)$").IsMatch(_task.Substring(1)))
                    {
                        if (intermediateTask2.Contains("+"))
                        {
                            double Number1 = 0;
                            double Number2 = 0;

                            string[] splitted = intermediateTask2.Split('+');

                            if (splitted[0].Substring(0, 1) == "(") splitted[0] = splitted[0].Substring(1);

                            Number1 = double.Parse(splitted[0]);
                            Number2 = double.Parse(splitted[1]);

                            _task = _task.Replace(intermediateTask2, (Number1 + Number2).ToString());

                            intermediateTask2 = regex.Match(_task).ToString();
                        }
                        else if (intermediateTask2.Contains("-"))
                        {
                            double Number1 = 0;
                            double Number2 = 0;

                            string[] splitted = intermediateTask2.Split('-');

                            if (splitted[0] != "" && splitted[0].Substring(0, 1) == "(") splitted[0] = splitted[0].Substring(1);

                            if (splitted[0] == "") Number1 = -double.Parse(splitted[1]);
                            else Number1 = double.Parse(splitted[0]);
                            if (splitted.Count() == 4) Number2 = -double.Parse(splitted[3]);
                            else if (splitted[0] != "" && splitted.Count() == 3) Number2 = -double.Parse(splitted[2]);
                            else Number2 = double.Parse(splitted[1]);

                            _task = _task.Replace(intermediateTask2, (Number1 - Number2).ToString());

                            intermediateTask2 = regex.Match(_task).ToString();
                        }
                    }
                }
                return double.Parse(_task);
            }
            return double.NaN;
        }
    }
}
