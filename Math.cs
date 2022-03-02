using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace uCalc
{
    public static class Extensions
    {
        public static IEnumerable<string> Split(this string str, int n)
        {
            if (String.IsNullOrEmpty(str) || n < 1)
            {
                throw new ArgumentException();
            }

            return Enumerable.Range(0, str.Length / n)
                            .Select(i => str.Substring(i * n, n));
        }
    }
}

namespace uCalc.Math.Converter.Temperature
{
    public static class Reaumur
    {
        public static double ToFahrenheit(double val)
        {
            double result = ((val / 0.8) * 1.8) + 32;
            return result;
        }
        public static double ToCelsius(double val)
        {
            double result = val / 0.8;
            return result;
        }
        public static double ToKelvin(double val)
        {
            double result = (val / 0.8) + 273.15;
            return result;
        }
        public static double ToRankine(double val)
        {
            double result = val * 2.2500 + 491.67;
            return result;
        }
    }
    public static class Rankine
    {
        public static double ToFahrenheit(double val)
        {
            double result = (val - 491.67) + 32.00;
            return result;
        }
        public static double ToCelsius(double val)
        {
            double result = (val - 491.67) / 1.8;
            return result;
        }
        public static double ToKelvin(double val)
        {
            double result = ((val - 491.67) / 1.8) + 273.15;
            return result;
        }
        public static double ToReaumur(double val)
        {
            double result = (val - 491.67) / 2.25;
            return result;
        }
    }
    public static class Kelvin
    {
        public static double ToCelsius(double val)
        {
            double result = val - 273.15;
            return result;
        }
        public static double ToFahrenheit(double val)
        {
            double result = (val - 273.15) * 1.8 + 32.00;
            return result;
        }
        public static double ToRankine(double val)
        {
            double result = val * 1.8;
            return result;
        }
        public static double ToReaumur(double val)
        {
            double result = (val - 273.15) * 0.8;
            return result;
        }
    }
    public static class Celsius
    {
        public static double ToKelvin(double val)
        {
            double result = val + 273.15;
            return result;
        }
        public static double ToFahrenheit(double val)
        {
            double result = (val * 1.8) + 32;
            return result;
        }
        public static double ToRankine(double val)
        {
            double result = (val * 1.8) + 491.67;
            return result;
        }
        public static double ToReaumur(double val)
        {
            double result = val * 0.8;
            return result;
        }
    }
    public static class Fahrenheit
    {
        public static double ToKelvin(double val)
        {
            double x = 5; double y = 9; double z = (val - (double)32) * (x / y) + (double)273.15;
            double result = z;
            return result;
        }
        public static double ToCelsius(double val)
        {
            double result = (val - 32) / 1.8;
            return result;
        }
        public static double ToRankine(double val)
        {
            double z = val + (double)459.67;
            double result = z;
            return result;
        }
        public static double ToReaumur(double val)
        {
            double result = (val - (double)32) / (double)1.8 * (double)0.8;
            return result;
        }
    }
}
namespace uCalc.Math.Converter.Mass
{
    public static class Tons
    {
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 100;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
        public static double ToLongval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.016;
            return result;
        }
        public static double ToShortval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.102;
            return result;
        }
        public static double ToSvale(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.473;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00045359237;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * (double)1000000 / 28.34952;
            return result;
        }
    }
    public static class Kilograms
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000984;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0011023;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.15747;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2.2046;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35.274;
            return result;
        }
    }
    public static class Grams
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToKiloval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMillival(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMicroval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000098421;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000011023;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00015747;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0022046;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.035274;
            return result;
        }
    }
    public static class Milligrams
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000098421;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000011023;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000015747;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000022046;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000035274;
            return result;
        }
    }
    public static class Micrograms
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000000098421;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000000011023;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000015747;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000022046;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000000035274;
            return result;
        }
    }
    public static class LongTons
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.98421;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00098421;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000098421;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000098421;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000000098421;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.12;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 160;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2240;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35840;
            return result;
        }
    }
    public static class ShortTons
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.1023;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0011023;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000011023;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000011023;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000000011023;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.89286;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 142.86;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2000;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 32000;
            return result;
        }
    }
    public static class Stones
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.47;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.15747;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00015747;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000015747;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000015747;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0062500;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0070000;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 14;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 224;
            return result;
        }
    }
    public static class Pounds
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2204.6;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2.2046;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0022046;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000022046;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000022046;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00044643;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00050000;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.071429;
            return result;
        }
        public static double ToOunce(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 16;
            return result;
        }
    }
    public static class Ounces
    {
        public static double ToTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35274;
            return result;
        }
        public static double ToKilogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35.274;
            return result;
        }
        public static double ToGram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.035274;
            return result;
        }
        public static double ToMilligram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000035274;
            return result;
        }
        public static double ToMicrogram(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000000035274;
            return result;
        }
        public static double ToLongTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000027902;
            return result;
        }
        public static double ToShortTon(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000031250;
            return result;
        }
        public static double ToStone(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0044643;
            return result;
        }
        public static double ToPound(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.062500;
            return result;
        }
    }
}
namespace uCalc.Math.Converter.Time
{
    public static class Centuries
    {
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 100;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1200;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5214.29;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 36500;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 876000;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52560000;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3153600000000000000;
            return result;
        }
    }
    public static class Decades
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 120;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 521.429;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3650;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 87600;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 5256000;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 315360000000000000;
            return result;
        }
    }
    public static class Years
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 100;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 12;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52.1429;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 365;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8760;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 525600;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 31536000000000000;
            return result;
        }
    }
    public static class Months
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1200;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 120;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 12;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 4.345;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 30.417;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 730;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 43800;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2628000000000000;
            return result;
        }
    }
    public static class Weeks
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5214.3;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 521.43;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 52.143;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 4.345;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 7;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 420;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 10080;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 604800000000000;
            return result;
        }
    }
    public static class Days
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 36500;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3650;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 365;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 30.417;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 7;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 24;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1440;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 86400000000000;
            return result;
        }
    }
    public static class Hours
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 876000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 87600;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 8760;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 730.001;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 168;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 24;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 3600000000000;
            return result;
        }
    }
    public static class Minutes
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 52560000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 5256000;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 525600;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 43800;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 10080;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1440;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 60000000000;
            return result;
        }
    }
    public static class Seconds
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60;
            return result;
        }
        public static double ToMillival(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMicroval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToNanoval(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
    }
    public static class Milliseconds
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
    }
    public static class Microseconds
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToNanoseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
    }
    public static class Nanoseconds
    {
        public static double ToCenturies(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3153600000000000000;
            return result;
        }
        public static double ToDecades(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 315360000000000000;
            return result;
        }
        public static double ToYears(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 31536000000000000;
            return result;
        }
        public static double ToMonths(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2628000000000000;
            return result;
        }
        public static double ToWeeks(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 604800000000000;
            return result;
        }
        public static double ToDays(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 86400000000000;
            return result;
        }
        public static double ToHours(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 3600000000000;
            return result;
        }
        public static double ToMinutes(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 60000000000;
            return result;
        }
        public static double ToSeconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToMicroseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
    }
}
namespace uCalc.Math.Converter.NumeralSystem
{
    public static class Decimal
    {
        public static string ToBinary(int dec)
        {
            string bin = Convert.ToString(dec, 2);
            if (bin.Length % 4 != 0)
                bin = bin.PadLeft(bin.Length + (4 - (bin.Length % 4)), '0');
            bin = string.Join(" ", bin.Split(4));
            return bin;
        }
        public static string ToHexadecimal(int dec)
        {
            return "0x" + dec.ToString("x").ToUpper();
        }
        public static string ToOctal(int dec)
        {
            string oct = Convert.ToString(dec, 8);
            if (oct.Length % 4 != 0)
                oct = oct.PadLeft(oct.Length + (4 - (oct.Length % 4)), '0');
            oct = string.Join(" ", oct.Split(4));
            return oct;
        }
    }
    public static class Binary
    {
        public static int ToDecimal(string binary)
        {
            if (binary.Contains(" "))
                binary = binary.Replace(" ", "");
            if (new Regex(@"^[0-1]*$").IsMatch(binary))
                return Convert.ToInt32(binary, 2);
            else
                throw new ArgumentException();
        }
        public static string ToHexadecimal(string binary)
        {
            if (binary.Contains(" "))
                binary = binary.Replace(" ", "");
            if (new Regex(@"^[0-1]*$").IsMatch(binary))
                return "0x" + int.Parse(Convert.ToInt32(binary, 2).ToString()).ToString("x").ToUpper();
            else
                throw new ArgumentException();
        }
        public static string ToOctal(string binary)
        {
            if (binary.Contains(" "))
                binary = binary.Replace(" ", "");
            if (!new Regex(@"^[0-1]*$").IsMatch(binary))
                throw new ArgumentException();
            string oct = Convert.ToString(int.Parse(Convert.ToInt32(binary, 2).ToString()), 8);
            if (oct.Length % 4 != 0)
                oct = oct.PadLeft(oct.Length + (4 - (oct.Length % 4)), '0');
            oct = string.Join(" ", oct.Split(4));
            return oct;
        }
    }
    public static class Hexadecimal
    {
        public static int ToDecimal(string hexadecimal)
        {
            if (!new Regex("^(0x)?[0-9a-fA-F]+$").IsMatch(hexadecimal))
                return Convert.ToInt32(hexadecimal, 2);
            return Convert.ToInt32(hexadecimal.Split('x')[1], 16);
        }
        public static string ToBinary(string hexadecimal)
        {
            if (!new Regex("^(0x)?[0-9a-fA-F]+$").IsMatch(hexadecimal))
                throw new ArgumentException();
            string bin = Convert.ToString(int.Parse(ToDecimal(hexadecimal).ToString()), 2);
            if (bin.Length % 4 != 0)
                bin = bin.PadLeft(bin.Length + (4 - (bin.Length % 4)), '0');
            bin = string.Join(" ", bin.Split(4));
            return bin;
        }
        public static string ToOctal(string hexadecimal)
        {
            if (!new Regex("^(0x)?[0-9a-fA-F]+$").IsMatch(hexadecimal))
                throw new ArgumentException();
            string oct = Convert.ToString(int.Parse(ToDecimal(hexadecimal).ToString()), 8);
            if (oct.Length % 4 != 0)
                oct = oct.PadLeft(oct.Length + (4 - (oct.Length % 4)), '0');
            oct = string.Join(" ", oct.Split(4));
            return oct;
        }
    }
    public static class Octal
    {
        public static string ToDecimal(string octal)
        {
            if (octal.Contains(" "))
                octal = octal.Replace(" ", "");
            if (!new Regex(@"^[0-7]*$").IsMatch(octal))
                throw new ArgumentException();
            return Convert.ToInt32(octal, 8).ToString();
        }
        public static string ToBinary(string octal)
        {
            if (octal.Contains(" "))
                octal = octal.Replace(" ", "");
            if (!new Regex(@"^[0-7]*$").IsMatch(octal))
                throw new ArgumentException();
            string bin = Convert.ToString(int.Parse(ToDecimal(octal).ToString()), 2);
            if (bin.Length % 4 != 0)
                bin = bin.PadLeft(bin.Length + (4 - (bin.Length % 4)), '0');
            bin = string.Join(" ", bin.Split(4));
            return bin;
        }
        public static string ToHexadecimal(string octal)
        {
            if (octal.Contains(" "))
                octal = octal.Replace(" ", "");
            if (!new Regex(@"^[0-7]*$").IsMatch(octal))
                throw new ArgumentException();
            return "0x" + int.Parse(ToDecimal(octal)).ToString("x").ToUpper();
        }
    }
}
namespace uCalc.Math.Converter.DataSize
{
    public static class Bit
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000000000000000000;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000000000000000;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000000000000;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000000000;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000000;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val / 8000;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            return val;
        }
    }
    public static class Byte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000000000;
            return result;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8;
            return result;
        }
    }
    public static class Kilobyte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000000;
            return result;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000;
            return result;
        }
    }
    public static class Megabyte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000000;
            return result;
        }
    }
    public static class Gigabyte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000000000;
            return result;
        }
    }
}
namespace uCalc.Math
{
    class Calculator
    {
        /// <summary>
        /// Converts a Unix timestamp to a DateTime.
        /// </summary>
        /// <param name="unixTimeStamp">The Unix timestamp to convert to a DateTime.</param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            if (unixTimeStamp < 0)
                throw new ArgumentException();

            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        /// <summary>
        /// Converts a DateTime to a Unix timestamp.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert to a Unix timestamp.</param>
        /// <returns></returns>
        public static double DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            double unixTimeStamp = (dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimeStamp;
        }

        /// <summary>
        /// Calculates a string based math task. Accepts brackets, exponentials and obeys math rules.
        /// </summary>
        /// <param name="task">The task string to be calculated</param>
        /// <returns></returns>
        public static double CalculateString(string task)
        {
            if (!new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\))*$").IsMatch(task) && new Regex(@"^\-?\d+(\.\d+)?$").IsMatch(task))
                throw new ArgumentException();

            task = task.Trim();
            while (task.Contains("  "))
                task = task.Replace("  ", "");

            bool unclosedBrackets = task.Count(c => c == '(') != task.Count(c => c == ')');
            bool onlyValidCharacters = new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\))*$").IsMatch(task);
            bool wrongFormat = new Regex(@"((\+|\-|\*|\/|\(|^)(\^|\)|$)|(\^|\/|\()($|\+|\*|\/|\))|(\/|\*)(\/|\*)|\d\(|\)\d|\($)").IsMatch(task);
            bool rightSyntax = onlyValidCharacters && !wrongFormat && !unclosedBrackets;
            if (rightSyntax)
            {
                // Powers
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)\^(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)").Matches(task))
                {
                    string[] splittedTask = match.Value.Split('^');
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = System.Math.Pow(firstNumber, secondNumber);
                    if ((firstNumber < 0 && secondNumber < 0) || (firstNumber > 0 && secondNumber < 0 && secondNumber % 2 != 0))
                        result = result * -1;

                    task = task.Replace(match.Value, result.ToString("N5", CultureInfo.InvariantCulture).Replace(",", "")); //.Replace(",", "."));
                }

                // Brackets
                while (task.Contains('('))
                {
                    string subtask = new Regex(@"\((\d|\.|\+|\-|\*|\/)*\)").Match(task).Value;
                    task = task.Replace(subtask, CalculateString(subtask.Substring(1, subtask.Length - 2)).ToString("N5", CultureInfo.InvariantCulture).Replace(",", ""));
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
                    //task = task.Replace(subtask, result.ToString("N5", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N5", CultureInfo.InvariantCulture).Replace(",", ""), 1);
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
                    //task = task.Replace(subtask, result.ToString("N5", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N5", CultureInfo.InvariantCulture).Replace(",", ""), 1);
                }


                if (new Regex(@"^\-?\d+(\.\d+)?$").IsMatch(task))
                    return double.Parse(task, CultureInfo.InvariantCulture);
                else
                    return double.NaN;
            }
            else
                return double.NaN;
        }
    }
}
