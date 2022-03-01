using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace uCalc.Math.Converter.Temperature
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
namespace uCalc.Math.Converter.Mass
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
namespace uCalc.Math.Converter.Time
{
    public static class Centuries
    {
        public static double ToDecades(double centuries)
        {
            double result = centuries * 10;
            return result;
        }
        public static double ToYears(double centuries)
        {
            double result = centuries * 100;
            return result;
        }
        public static double ToMonths(double centuries)
        {
            double result = centuries * 1200;
            return result;
        }
        public static double ToWeeks(double centuries)
        {
            double result = centuries * 5214.29;
            return result;
        }
        public static double ToDays(double centuries)
        {
            double result = centuries * 36500;
            return result;
        }
        public static double ToHours(double centuries)
        {
            double result = centuries * 876000;
            return result;
        }
        public static double ToMinutes(double centuries)
        {
            double result = centuries * 52560000;
            return result;
        }
        public static double ToSeconds(double centuries)
        {
            double result = centuries * 3153600000;
            return result;
        }
        public static double ToMilliseconds(double centuries)
        {
            double result = centuries * 3153600000000;
            return result;
        }
        public static double ToMicroseconds(double centuries)
        {
            double result = centuries * 3153600000000000;
            return result;
        }
        public static double ToNanoseconds(double centuries)
        {
            double result = centuries * 3153600000000000000;
            return result;
        }
    }
    public static class Decades
    {
        public static double ToCenturies(double decades)
        {
            double result = decades / 10;
            return result;
        }
        public static double ToYears(double decades)
        {
            double result = decades * 10;
            return result;
        }
        public static double ToMonths(double decades)
        {
            double result = decades * 120;
            return result;
        }
        public static double ToWeeks(double decades)
        {
            double result = decades * 521.429;
            return result;
        }
        public static double ToDays(double decades)
        {
            double result = decades * 3650;
            return result;
        }
        public static double ToHours(double decades)
        {
            double result = decades * 87600;
            return result;
        }
        public static double ToMinutes(double decades)
        {
            double result = decades * 5256000;
            return result;
        }
        public static double ToSeconds(double decades)
        {
            double result = decades * 315360000;
            return result;
        }
        public static double ToMilliseconds(double decades)
        {
            double result = decades * 315360000000;
            return result;
        }
        public static double ToMicroseconds(double decades)
        {
            double result = decades * 315360000000000;
            return result;
        }
        public static double ToNanoseconds(double decades)
        {
            double result = decades * 315360000000000000;
            return result;
        }
    }
    public static class Years
    {
        public static double ToCenturies(double years)
        {
            double result = years / 100;
            return result;
        }
        public static double ToDecades(double years)
        {
            double result = years / 10;
            return result;
        }
        public static double ToMonths(double years)
        {
            double result = years * 12;
            return result;
        }
        public static double ToWeeks(double years)
        {
            double result = years * 52.1429;
            return result;
        }
        public static double ToDays(double years)
        {
            double result = years * 365;
            return result;
        }
        public static double ToHours(double years)
        {
            double result = years * 8760;
            return result;
        }
        public static double ToMinutes(double years)
        {
            double result = years * 525600;
            return result;
        }
        public static double ToSeconds(double years)
        {
            double result = years * 31536000;
            return result;
        }
        public static double ToMilliseconds(double years)
        {
            double result = years * 31536000000;
            return result;
        }
        public static double ToMicroseconds(double years)
        {
            double result = years * 31536000000000;
            return result;
        }
        public static double ToNanoseconds(double years)
        {
            double result = years * 31536000000000000;
            return result;
        }
    }
    public static class Months
    {
        public static double ToCenturies(double months)
        {
            double result = months / 1200;
            return result;
        }
        public static double ToDecades(double months)
        {
            double result = months / 120;
            return result;
        }
        public static double ToYears(double months)
        {
            double result = months / 12;
            return result;
        }
        public static double ToWeeks(double months)
        {
            double result = months * 4.345;
            return result;
        }
        public static double ToDays(double months)
        {
            double result = months * 30.417;
            return result;
        }
        public static double ToHours(double months)
        {
            double result = months * 730;
            return result;
        }
        public static double ToMinutes(double months)
        {
            double result = months * 43800;
            return result;
        }
        public static double ToSeconds(double months)
        {
            double result = months * 2628000;
            return result;
        }
        public static double ToMilliseconds(double months)
        {
            double result = months * 2628000000;
            return result;
        }
        public static double ToMicroseconds(double months)
        {
            double result = months * 2628000000000;
            return result;
        }
        public static double ToNanoseconds(double months)
        {
            double result = months * 2628000000000000;
            return result;
        }
    }
    public static class Weeks
    {
        public static double ToCenturies(double weeks)
        {
            double result = weeks / 5214.3;
            return result;
        }
        public static double ToDecades(double weeks)
        {
            double result = weeks * 521.43;
            return result;
        }
        public static double ToYears(double weeks)
        {
            double result = weeks * 52.143;
            return result;
        }
        public static double ToMonths(double weeks)
        {
            double result = weeks * 4.345;
            return result;
        }
        public static double ToDays(double weeks)
        {
            double result = weeks * 7;
            return result;
        }
        public static double ToHours(double weeks)
        {
            double result = weeks * 420;
            return result;
        }
        public static double ToMinutes(double weeks)
        {
            double result = weeks * 10080;
            return result;
        }
        public static double ToSeconds(double weeks)
        {
            double result = weeks * 604800;
            return result;
        }
        public static double ToMilliseconds(double weeks)
        {
            double result = weeks * 604800000;
            return result;
        }
        public static double ToMicroseconds(double weeks)
        {
            double result = weeks * 604800000000;
            return result;
        }
        public static double ToNanoseconds(double weeks)
        {
            double result = weeks * 604800000000000;
            return result;
        }
    }
    public static class Days
    {
        public static double ToCenturies(double days)
        {
            double result = days / 36500;
            return result;
        }
        public static double ToDecades(double days)
        {
            double result = days / 3650;
            return result;
        }
        public static double ToYears(double days)
        {
            double result = days / 365;
            return result;
        }
        public static double ToMonths(double days)
        {
            double result = days / 30.417;
            return result;
        }
        public static double ToWeeks(double days)
        {
            double result = days / 7;
            return result;
        }
        public static double ToHours(double days)
        {
            double result = days * 24;
            return result;
        }
        public static double ToMinutes(double days)
        {
            double result = days * 1440;
            return result;
        }
        public static double ToSeconds(double days)
        {
            double result = days * 86400;
            return result;
        }
        public static double ToMilliseconds(double days)
        {
            double result = days * 86400000;
            return result;
        }
        public static double ToMicroseconds(double days)
        {
            double result = days * 86400000000;
            return result;
        }
        public static double ToNanoseconds(double days)
        {
            double result = days * 86400000000000;
            return result;
        }
    }
    public static class Hours
    {
        public static double ToCenturies(double hours)
        {
            double result = hours / 876000;
            return result;
        }
        public static double ToDecades(double hours)
        {
            double result = hours / 87600;
            return result;
        }
        public static double ToYears(double hours)
        {
            double result = hours / 8760;
            return result;
        }
        public static double ToMonths(double hours)
        {
            double result = hours / 730.001;
            return result;
        }
        public static double ToWeeks(double hours)
        {
            double result = hours / 168;
            return result;
        }
        public static double ToDays(double hours)
        {
            double result = hours / 24;
            return result;
        }
        public static double ToMinutes(double hours)
        {
            double result = hours * 60;
            return result;
        }
        public static double ToSeconds(double hours)
        {
            double result = hours * 3600;
            return result;
        }
        public static double ToMilliseconds(double hours)
        {
            double result = hours * 3600000;
            return result;
        }
        public static double ToMicroseconds(double hours)
        {
            double result = hours * 3600000000;
            return result;
        }
        public static double ToNanoseconds(double hours)
        {
            double result = hours * 3600000000000;
            return result;
        }
    }
    public static class Minutes
    {
        public static double ToCenturies(double minutes)
        {
            double result = minutes / 52560000;
            return result;
        }
        public static double ToDecades(double minutes)
        {
            double result = minutes / 5256000;
            return result;
        }
        public static double ToYears(double minutes)
        {
            double result = minutes / 525600;
            return result;
        }
        public static double ToMonths(double minutes)
        {
            double result = minutes / 43800;
            return result;
        }
        public static double ToWeeks(double minutes)
        {
            double result = minutes / 10080;
            return result;
        }
        public static double ToDays(double minutes)
        {
            double result = minutes / 1440;
            return result;
        }
        public static double ToHours(double minutes)
        {
            double result = minutes / 60;
            return result;
        }
        public static double ToSeconds(double minutes)
        {
            double result = minutes * 60;
            return result;
        }
        public static double ToMilliseconds(double minutes)
        {
            double result = minutes * 60000;
            return result;
        }
        public static double ToMicroseconds(double minutes)
        {
            double result = minutes * 60000000;
            return result;
        }
        public static double ToNanoseconds(double minutes)
        {
            double result = minutes * 60000000000;
            return result;
        }
    }
    public static class Seconds
    {
        public static double ToCenturies(double seconds)
        {
            double result = seconds / 3153600000;
            return result;
        }
        public static double ToDecades(double seconds)
        {
            double result = seconds / 315360000;
            return result;
        }
        public static double ToYears(double seconds)
        {
            double result = seconds / 31536000;
            return result;
        }
        public static double ToMonths(double seconds)
        {
            double result = seconds / 2628000;
            return result;
        }
        public static double ToWeeks(double seconds)
        {
            double result = seconds / 604800;
            return result;
        }
        public static double ToDays(double seconds)
        {
            double result = seconds / 86400;
            return result;
        }
        public static double ToHours(double seconds)
        {
            double result = seconds / 3600;
            return result;
        }
        public static double ToMinutes(double seconds)
        {
            double result = seconds / 60;
            return result;
        }
        public static double ToMilliseconds(double seconds)
        {
            double result = seconds * 1000;
            return result;
        }
        public static double ToMicroseconds(double seconds)
        {
            double result = seconds * 1000000;
            return result;
        }
        public static double ToNanoseconds(double seconds)
        {
            double result = seconds * 1000000000;
            return result;
        }
    }
    public static class Milliseconds
    {
        public static double ToCenturies(double milliseconds)
        {
            double result = milliseconds / 3153600000000;
            return result;
        }
        public static double ToDecades(double milliseconds)
        {
            double result = milliseconds / 315360000000;
            return result;
        }
        public static double ToYears(double milliseconds)
        {
            double result = milliseconds / 31536000000;
            return result;
        }
        public static double ToMonths(double milliseconds)
        {
            double result = milliseconds / 2628000000;
            return result;
        }
        public static double ToWeeks(double milliseconds)
        {
            double result = milliseconds / 604800000;
            return result;
        }
        public static double ToDays(double milliseconds)
        {
            double result = milliseconds / 86400000;
            return result;
        }
        public static double ToHours(double milliseconds)
        {
            double result = milliseconds / 3600000;
            return result;
        }
        public static double ToMinutes(double milliseconds)
        {
            double result = milliseconds / 60000;
            return result;
        }
        public static double ToSeconds(double milliseconds)
        {
            double result = milliseconds / 1000;
            return result;
        }
        public static double ToMicroseconds(double milliseconds)
        {
            double result = milliseconds * 1000000;
            return result;
        }
        public static double ToNanoseconds(double milliseconds)
        {
            double result = milliseconds * 1000000000;
            return result;
        }
    }
    public static class Microseconds
    {
        public static double ToCenturies(double microseconds)
        {
            double result = microseconds / 3153600000000000;
            return result;
        }
        public static double ToDecades(double microseconds)
        {
            double result = microseconds / 315360000000000;
            return result;
        }
        public static double ToYears(double microseconds)
        {
            double result = microseconds / 31536000000000;
            return result;
        }
        public static double ToMonths(double microseconds)
        {
            double result = microseconds / 2628000000000;
            return result;
        }
        public static double ToWeeks(double microseconds)
        {
            double result = microseconds / 604800000000;
            return result;
        }
        public static double ToDays(double microseconds)
        {
            double result = microseconds / 86400000000;
            return result;
        }
        public static double ToHours(double microseconds)
        {
            double result = microseconds / 3600000000;
            return result;
        }
        public static double ToMinutes(double microseconds)
        {
            double result = microseconds / 60000000;
            return result;
        }
        public static double ToSeconds(double microseconds)
        {
            double result = microseconds / 1000000;
            return result;
        }
        public static double ToMilliseconds(double microseconds)
        {
            double result = microseconds * 1000000000;
            return result;
        }
        public static double ToNanoseconds(double microseconds)
        {
            double result = microseconds * 1000000000000;
            return result;
        }
    }
    public static class Nanoseconds
    {
        public static double ToCenturies(double nanoseconds)
        {
            double result = nanoseconds / 3153600000000000000;
            return result;
        }
        public static double ToDecades(double nanoseconds)
        {
            double result = nanoseconds / 315360000000000000;
            return result;
        }
        public static double ToYears(double nanoseconds)
        {
            double result = nanoseconds / 31536000000000000;
            return result;
        }
        public static double ToMonths(double nanoseconds)
        {
            double result = nanoseconds / 2628000000000000;
            return result;
        }
        public static double ToWeeks(double nanoseconds)
        {
            double result = nanoseconds / 604800000000000;
            return result;
        }
        public static double ToDays(double nanoseconds)
        {
            double result = nanoseconds / 86400000000000;
            return result;
        }
        public static double ToHours(double nanoseconds)
        {
            double result = nanoseconds / 3600000000000;
            return result;
        }
        public static double ToMinutes(double nanoseconds)
        {
            double result = nanoseconds / 60000000000;
            return result;
        }
        public static double ToSeconds(double nanoseconds)
        {
            double result = nanoseconds / 1000000000;
            return result;
        }
        public static double ToMilliseconds(double nanoseconds)
        {
            double result = nanoseconds / 1000000;
            return result;
        }
        public static double ToMicroseconds(double nanoseconds)
        {
            double result = nanoseconds / 1000;
            return result;
        }
    }
}
namespace uCalc.Math.Converter.NumeralSystems
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
