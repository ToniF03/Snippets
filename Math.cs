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
namespace uCalc.Math.Units.Patterns
{
    public static class Pattern
    {
        public static readonly string MassPattern = @"(\b((?i)(ton(s)?|kilogram(s)?|gram(s)|milligram(s)?|microgram(s)?|long ton(s)?|short ton(s)?|stone(s)?|pound(s)?|ounce(s)?)(?-i)|(t|kg|g|mg|µg|lt|tn|st|lb(s)?))\b|oz\.?)";
        public static readonly string TemperaturePattern = @"(\bK\b|°\b(?i)(C|F|Ra|Re|R)(?-i)\b)";
        public static readonly string DataSizePattern = @"\b((b|(K|M|G|T|P|E)?B)|(?i)(bit|(kilo|mega|giga|tera|peta|exa)?byte)(?-i))\b";
        public static readonly string TimePattern = @"(\b(c|yr|mth|wk|d|h|min|s|ms|μs|ns)\b|\b(?i)(centur(y|ies)|decade(s)?|year(s)?|month(s)?|week(s)?|day(s)?|hour(s)?|minute(s)?|(milli|micro|nano)?second(s)?)(?-i)\b)";
        public static readonly string LengthPattern = @"(μm|\b(nm|mm|cm|dm|km|dam|hm|mi|m|yd|ft|in)\b|\b(?i)(nanometer|micrometer|millimeter|centimeter|decimeter|kilometer|decameter|hectometer|mile|yard|foot|feet|inch)(?-i)\b)";
        public static readonly string AnglePattern = @"(°|( |\b)(?i)(gon|grad|deg|mil|rad|arcmin|arcsec|gradian|degree|milliradian|radian|angular minute(s)?|angular second(s)?)(?-i)\b)";
        public static readonly string FrequencyPattern = @"((k|M|G)?Hz|(?i)((kilo|mega|giga)?hertz)(?-i))";
    }
}
namespace uCalc.Math.Conversion
{
    public enum AngleUnit
    {
        Gradian,
        Degree,
        Milliradian,
        Radian,
        AngularMinute,
        AngularSecond,
        None
    }
    public enum DataSizeUnit
    {
        Bit,
        Byte,
        Kilobyte,
        Megabyte,
        Gigabyte,
        Terabyte,
        Petabyte,
        Exabyte,
        None
    }
    public enum FrequencyUnit
    {
        Hertz,
        Kilohertz,
        Megahertz,
        Gigahertz,
        None
    }
    public enum LengthUnit
    {
        Nanometer,
        Micrometer,
        Millimeter,
        Centimeter,
        Decimeter,
        Meter,
        Kilometer,
        Decameter,
        Hectometer,
        Mile,
        Yard,
        Feet,
        Inch,
        None
    }
    public enum MassUnit
    {
        Ton,
        Kilogram,
        Gram,
        Milligram,
        Microgram,
        LongTon,
        ShortTon,
        Stone,
        Pounds,
        Ounce,
        None
    }
    public enum NumeralSystemUnit
    {
        Binary,
        Octal,
        Hexadecimal,
        Decimal,
        None
    }
    public enum TemperatureUnit
    {
        Reaumur,
        Rankine,
        Kelvin,
        Celsius,
        Fahrenheit,
        None
    }
    public enum TimeUnit
    {
        Century,
        Decade,
        Year,
        Month,
        Week,
        Day,
        Hour,
        Minute,
        Second,
        Millisecond,
        Microsecond,
        Nanosecond,
        None
    }
    public static class Converter
    {
        public static double AngleConverter(double val, AngleUnit currentUnit, AngleUnit targetUnit)
        {
            if (currentUnit == AngleUnit.None || targetUnit == AngleUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            switch (targetUnit)
            {
                case AngleUnit.Gradian:
                    if (currentUnit == AngleUnit.Degree)
                        result = Angle.Gradian.ToDegree(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Gradian.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Gradian.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.Gradian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.Gradian.ToAngularSecond(val);
                    break;
                case AngleUnit.Degree:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Degree.ToGradian(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Degree.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Degree.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.Degree.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.Degree.ToAngularSecond(val);
                    break;
                case AngleUnit.Milliradian:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Milliradian.ToGradian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Milliradian.ToDegree(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.Milliradian.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.Milliradian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.Milliradian.ToAngularSecond(val);
                    break;
                case AngleUnit.Radian:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.Radian.ToGradian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.Radian.ToDegree(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.Radian.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.AngularMinute)
                        result = Angle.Radian.ToAngularMinute(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.Radian.ToAngularSecond(val);
                    break;
                case AngleUnit.AngularMinute:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.AngularMinute.ToGradian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.AngularMinute.ToDegree(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.AngularMinute.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.AngularMinute.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularMinute.ToAngularSecond(val);
                    break;
                case AngleUnit.AngularSecond:
                    if (currentUnit == AngleUnit.Gradian)
                        result = Angle.AngularSecond.ToGradian(val);
                    else if (currentUnit == AngleUnit.Degree)
                        result = Angle.AngularSecond.ToDegree(val);
                    else if (currentUnit == AngleUnit.Milliradian)
                        result = Angle.AngularSecond.ToMilliradian(val);
                    else if (currentUnit == AngleUnit.Radian)
                        result = Angle.AngularSecond.ToRadian(val);
                    else if (currentUnit == AngleUnit.AngularSecond)
                        result = Angle.AngularSecond.ToAngularMinute(val);
                    break;
            }
            return result;
        }
        public static double DataSizeConverter(double val, DataSizeUnit currentUnit, DataSizeUnit targetUnit)
        {
            if (currentUnit == DataSizeUnit.None || targetUnit == DataSizeUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();
            double result = 0;

            if (targetUnit == DataSizeUnit.Bit)
            {
                if (currentUnit == DataSizeUnit.Byte)
                    result = Math.Conversion.DataSize.Byte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToBit(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToBit(val);
            }
            else if (targetUnit == DataSizeUnit.Byte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToByte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToByte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToByte(val);
            }
            else if (targetUnit == DataSizeUnit.Kilobyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToKilobyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToKilobyte(val);
            }
            else if (targetUnit == DataSizeUnit.Megabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToMegabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToMegabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Gigabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToGigabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToGigabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Terabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToTerabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToTerabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Petabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToPetabyte(val);
                else if (currentUnit == DataSizeUnit.Exabyte)
                    result = DataSize.Exabyte.ToPetabyte(val);
            }
            else if (targetUnit == DataSizeUnit.Exabyte)
            {
                if (currentUnit == DataSizeUnit.Bit)
                    result = DataSize.Bit.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Byte)
                    result = DataSize.Byte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Kilobyte)
                    result = DataSize.Kilobyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Megabyte)
                    result = DataSize.Megabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Gigabyte)
                    result = DataSize.Gigabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Terabyte)
                    result = DataSize.Terabyte.ToExabyte(val);
                else if (currentUnit == DataSizeUnit.Petabyte)
                    result = DataSize.Petabyte.ToExabyte(val);
            }
            return result;
        }
        public static double FrequencyConverter(double val, FrequencyUnit currentUnit, FrequencyUnit targetUnit)
        {
            double result = 0;
            if (currentUnit == FrequencyUnit.None || targetUnit == FrequencyUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();

            switch (targetUnit)
            {
                case FrequencyUnit.Hertz:
                    if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToHertz(val);
                    else if (currentUnit == FrequencyUnit.Megahertz)
                        result = Frequency.Megahertz.ToHertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToHertz(val);
                    break;
                case FrequencyUnit.Kilohertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToKilohertz(val);
                    else if (currentUnit == FrequencyUnit.Megahertz)
                        result = Frequency.Megahertz.ToKilohertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToKilohertz(val);
                    break;
                case FrequencyUnit.Megahertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToMegahertz(val);
                    else if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToMegahertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Gigahertz.ToMegahertz(val);
                    break;
                case FrequencyUnit.Gigahertz:
                    if (currentUnit == FrequencyUnit.Hertz)
                        result = Frequency.Hertz.ToGigahertz(val);
                    else if (currentUnit == FrequencyUnit.Kilohertz)
                        result = Frequency.Kilohertz.ToGigahertz(val);
                    else if (currentUnit == FrequencyUnit.Gigahertz)
                        result = Frequency.Megahertz.ToGigahertz(val);
                    break;
            }
            return result;
        }
        public static double LengthConverter(double val, LengthUnit currentUnit, LengthUnit targetUnit)
        {
            if (currentUnit == LengthUnit.None || targetUnit == LengthUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();

            double result = 0;

            if (targetUnit == LengthUnit.Nanometer)
            {
                if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToNanometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToNanometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToNanometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToNanometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToNanometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToNanometer(val);
            }
            else if (targetUnit == LengthUnit.Micrometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMicrometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMicrometer(val);
            }
            else if (targetUnit == LengthUnit.Millimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMillimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMillimeter(val);
            }
            else if (targetUnit == LengthUnit.Centimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToCentimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToCentimeter(val);
            }
            else if (targetUnit == LengthUnit.Decimeter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToDecimeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToDecimeter(val);
            }
            else if (targetUnit == LengthUnit.Meter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMeter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMeter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMeter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToMeter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMeter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMeter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMeter(val);
            }
            else if (targetUnit == LengthUnit.Kilometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToKilometer(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToKilometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToKilometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToKilometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToKilometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToKilometer(val);
            }
            else if (targetUnit == LengthUnit.Decameter)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToDecameter(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToDecameter(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToDecameter(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToDecameter(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToDecameter(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToDecameter(val);
            }
            else if (targetUnit == LengthUnit.Hectometer)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToHectometer(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToHectometer(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToHectometer(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToHectometer(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToHectometer(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToHectometer(val);
            }
            else if (targetUnit == LengthUnit.Mile)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToMiles(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToMiles(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToMiles(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToMiles(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToMiles(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToMiles(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToMiles(val);
            }
            else if (targetUnit == LengthUnit.Yard)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToYards(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToYards(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToYards(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToYards(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToYards(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToYards(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToYards(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToYards(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToYards(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToYards(val);
            }
            else if (targetUnit == LengthUnit.Feet)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToFeet(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToFeet(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToFeet(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToFeet(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToFeet(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToFeet(val);
                else if (currentUnit == LengthUnit.Inch)
                    result = Length.Inches.ToFeet(val);
            }
            else if (targetUnit == LengthUnit.Inch)
            {
                if (currentUnit == LengthUnit.Nanometer)
                    result = Length.Nanometer.ToInches(val);
                else if (currentUnit == LengthUnit.Micrometer)
                    result = Length.Micrometer.ToInches(val);
                else if (currentUnit == LengthUnit.Millimeter)
                    result = Length.Millimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Centimeter)
                    result = Length.Centimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Decimeter)
                    result = Length.Decimeter.ToInches(val);
                else if (currentUnit == LengthUnit.Meter)
                    result = Length.Meter.ToInches(val);
                else if (currentUnit == LengthUnit.Kilometer)
                    result = Length.Kilometer.ToInches(val);
                else if (currentUnit == LengthUnit.Decameter)
                    result = Length.Decameter.ToInches(val);
                else if (currentUnit == LengthUnit.Hectometer)
                    result = Length.Hectometer.ToInches(val);
                else if (currentUnit == LengthUnit.Mile)
                    result = Length.Mile.ToInches(val);
                else if (currentUnit == LengthUnit.Yard)
                    result = Length.Yard.ToInches(val);
                else if (currentUnit == LengthUnit.Feet)
                    result = Length.Feet.ToInches(val);
            }

            return result;
        }
        public static double MassConverter(double val, MassUnit currentUnit, MassUnit targetUnit)
        {
            if (currentUnit == MassUnit.None || targetUnit == MassUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();

            double result = 0;

            if (currentUnit == MassUnit.Ton)
            {
                if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Tons.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Tons.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Tons.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Tons.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Tons.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Tons.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Tons.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Tons.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Tons.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Kilogram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Kilograms.ToTons(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Kilograms.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Kilograms.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Kilograms.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Kilograms.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Kilograms.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Kilograms.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Kilograms.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Kilograms.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Gram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Grams.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Grams.ToKilograms(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Grams.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Grams.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Grams.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Grams.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Grams.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Grams.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Grams.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Milligram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Milligrams.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Milligrams.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Milligrams.ToGrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Milligrams.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Milligrams.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Milligrams.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Milligrams.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Milligrams.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Milligrams.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Microgram)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Micrograms.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Micrograms.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Micrograms.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Micrograms.ToMilligrams(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Micrograms.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Micrograms.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Micrograms.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Micrograms.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Micrograms.ToOunces(val);
            }
            else if (currentUnit == MassUnit.LongTon)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.LongTons.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.LongTons.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.LongTons.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.LongTons.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.LongTons.ToMicrograms(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.LongTons.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.LongTons.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.LongTons.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.LongTons.ToOunces(val);
            }
            else if (currentUnit == MassUnit.ShortTon)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.ShortTons.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.ShortTons.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.ShortTons.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.ShortTons.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.ShortTons.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.ShortTons.ToLongTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.ShortTons.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.ShortTons.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.ShortTons.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Stone)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Stones.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Stones.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Stones.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Stones.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Stones.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Stones.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Stones.ToShortTons(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Stones.ToPounds(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Stones.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Pounds)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Pounds.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Pounds.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Pounds.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Pounds.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Pounds.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Pounds.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Pounds.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Pounds.ToStones(val);
                else if (targetUnit == MassUnit.Ounce)
                    result = Math.Conversion.Mass.Pounds.ToOunces(val);
            }
            else if (currentUnit == MassUnit.Ounce)
            {
                if (targetUnit == MassUnit.Ton)
                    result = Math.Conversion.Mass.Ounces.ToTons(val);
                else if (targetUnit == MassUnit.Kilogram)
                    result = Math.Conversion.Mass.Ounces.ToKilograms(val);
                else if (targetUnit == MassUnit.Gram)
                    result = Math.Conversion.Mass.Ounces.ToGrams(val);
                else if (targetUnit == MassUnit.Milligram)
                    result = Math.Conversion.Mass.Ounces.ToMilligrams(val);
                else if (targetUnit == MassUnit.Microgram)
                    result = Math.Conversion.Mass.Ounces.ToMicrograms(val);
                else if (targetUnit == MassUnit.LongTon)
                    result = Math.Conversion.Mass.Ounces.ToLongTons(val);
                else if (targetUnit == MassUnit.ShortTon)
                    result = Math.Conversion.Mass.Ounces.ToShortTons(val);
                else if (targetUnit == MassUnit.Stone)
                    result = Math.Conversion.Mass.Ounces.ToStones(val);
                else if (targetUnit == MassUnit.Pounds)
                    result = Math.Conversion.Mass.Ounces.ToPounds(val);
            }

            return result;
        }
        public static string NumeralSystemConverter(string val, NumeralSystemUnit currentUnit, NumeralSystemUnit targetUnit)
        {
            if (currentUnit == NumeralSystemUnit.None || targetUnit == NumeralSystemUnit.None || currentUnit == targetUnit)
                throw new ArgumentException();
            string result = "";
            if (targetUnit == NumeralSystemUnit.Binary)
            {
                if (currentUnit == NumeralSystemUnit.Octal)
                {
                    result = NumeralSystem.Octal.ToBinary(val);
                }
                else if (currentUnit == NumeralSystemUnit.Hexadecimal)
                {
                    result = NumeralSystem.Hexadecimal.ToBinary(val);
                }
                else if (currentUnit == NumeralSystemUnit.Decimal)
                {
                    result = NumeralSystem.Decimal.ToBinary(int.Parse(val));
                }
            }
            else if (targetUnit == NumeralSystemUnit.Octal)
            {
                if (currentUnit == NumeralSystemUnit.Binary)
                {
                    result = NumeralSystem.Binary.ToOctal(val);
                }
                else if (currentUnit == NumeralSystemUnit.Hexadecimal)
                {
                    result = NumeralSystem.Hexadecimal.ToOctal(val);
                }
                else if (currentUnit == NumeralSystemUnit.Decimal)
                {
                    result = NumeralSystem.Decimal.ToOctal(int.Parse(val));
                }
            }
            else if (targetUnit == NumeralSystemUnit.Hexadecimal)
            {
                if (currentUnit == NumeralSystemUnit.Binary)
                {
                    result = NumeralSystem.Binary.ToHexadecimal(val);
                }
                else if (currentUnit == NumeralSystemUnit.Octal)
                {
                    result = NumeralSystem.Octal.ToHexadecimal(val);
                }
                else if (currentUnit == NumeralSystemUnit.Decimal)
                {
                    result = NumeralSystem.Decimal.ToHexadecimal(int.Parse(val));
                }
            }
            else if (targetUnit == NumeralSystemUnit.Decimal)
            {
                if (currentUnit == NumeralSystemUnit.Binary)
                {
                    result = NumeralSystem.Binary.ToDecimal(val).ToString();
                }
                else if (currentUnit == NumeralSystemUnit.Octal)
                {
                    result = NumeralSystem.Octal.ToDecimal(val).ToString();
                }
                else if (currentUnit == NumeralSystemUnit.Hexadecimal)
                {
                    result = NumeralSystem.Hexadecimal.ToDecimal(val).ToString();
                }
            }
            return result;
        }
        public static double TemperatureConverter(double val, TemperatureUnit currentUnit, TemperatureUnit targetUnit)
        {
            if (currentUnit == TemperatureUnit.None || targetUnit == TemperatureUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            switch (targetUnit)
            {
                case TemperatureUnit.Celsius:
                    if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToCelsius(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToCelsius(val);
                    break;
                case TemperatureUnit.Fahrenheit:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToFahrenheit(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToFahrenheit(val);
                    break;
                case TemperatureUnit.Reaumur:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToReaumur(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToReaumur(val);
                    break;
                case TemperatureUnit.Rankine:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToRankine(val);
                    else if (currentUnit == TemperatureUnit.Kelvin)
                        result = Temperature.Kelvin.ToRankine(val);
                    break;
                case TemperatureUnit.Kelvin:
                    if (currentUnit == TemperatureUnit.Celsius)
                        result = Temperature.Celsius.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Fahrenheit)
                        result = Temperature.Fahrenheit.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Reaumur)
                        result = Temperature.Reaumur.ToKelvin(val);
                    else if (currentUnit == TemperatureUnit.Rankine)
                        result = Temperature.Rankine.ToKelvin(val);
                    break;
            }
            return result;
        }
        public static double TimeConverter(double val, TimeUnit currentUnit, TimeUnit targetUnit)
        {
            if (currentUnit == TimeUnit.None || targetUnit == TimeUnit.None || targetUnit == currentUnit)
                throw new ArgumentException();
            double result = 0;
            if (currentUnit == TimeUnit.Century)
            {
                if (targetUnit == TimeUnit.Decade)
                {
                    double value = Time.Centuries.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Centuries.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Centuries.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Centuries.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Centuries.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Centuries.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Centuries.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Centuries.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Centuries.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Time.Centuries.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Centuries.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Decade)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Decades.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Decades.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Decades.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Decades.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Decades.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Decades.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Decades.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Decades.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Decades.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Decades.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Decades.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Year)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Years.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Years.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Years.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Years.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Years.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Years.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Years.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Years.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Years.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Years.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Years.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Month)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Months.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Months.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Months.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Months.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Months.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Months.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Months.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Months.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Months.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Months.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Months.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Week)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Weeks.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Weeks.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Weeks.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Weeks.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Weeks.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Weeks.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Weeks.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Weeks.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Weeks.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Day)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Days.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Days.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Days.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Days.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Days.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Days.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Days.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Days.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Days.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Days.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Days.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Hour)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Hours.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Hours.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Hours.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Hours.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Hours.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Hours.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Hours.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Hours.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Hours.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Hours.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Hours.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Minute)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Minutes.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Minutes.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Minutes.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Minutes.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Minutes.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Minutes.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Minutes.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Minutes.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Minutes.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Second)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Seconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Seconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Seconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Seconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Seconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Seconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Seconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Seconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Seconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Millisecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToMicroseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Milliseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Microsecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Microseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Microseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Microseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Microseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Microseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Nanosecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            else if (currentUnit == TimeUnit.Nanosecond)
            {
                if (targetUnit == TimeUnit.Century)
                {
                    double value = Math.Conversion.Time.Microseconds.ToCenturies(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Decade)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDecades(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Year)
                {
                    double value = Math.Conversion.Time.Microseconds.ToYears(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Month)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMonths(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Week)
                {
                    double value = Math.Conversion.Time.Microseconds.ToWeeks(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Day)
                {
                    double value = Math.Conversion.Time.Microseconds.ToDays(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Hour)
                {
                    double value = Math.Conversion.Time.Microseconds.ToHours(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Minute)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMinutes(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Second)
                {
                    double value = Math.Conversion.Time.Microseconds.ToSeconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Millisecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToMilliseconds(val);
                    result = value;
                }
                else if (targetUnit == TimeUnit.Microsecond)
                {
                    double value = Math.Conversion.Time.Microseconds.ToNanoseconds(val);
                    result = value;
                }
            }
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.Angle
{
    public static class Gradian
    {
        private static double pi = System.Math.PI;
        public static double ToDegree(double val)
        {
            double result = val * 180 / pi;
            return result;
        }
        public static double ToMilliradian(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToRadian(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToAngularMinute(double val)
        {
            double result = val * (60 * 180) / 1000 * pi;
            return result;
        }
        public static double ToAngularSecond(double val)
        {
            double result = val * (3600 * 180) / 1000 * pi;
            return result;
        }
    }
    public static class Degree
    {
        private static double pi = System.Math.PI;
        public static double ToGradian(double val)
        {
            double result = val * 180 / 200;
            return result;
        }
        public static double ToMilliradian(double val)
        {
            double result = val * 100 * pi / 200;
            return result;
        }
        public static double ToRadian(double val)
        {
            double result = val * pi / 200;
            return result;
        }
        public static double ToAngularMinute(double val)
        {
            double result = val * 54;
            return result;
        }
        public static double ToAngularSecond(double val)
        {
            double result = val * 3240;
            return result;
        }
    }
    public static class Milliradian
    {
        private static double pi = System.Math.PI;
        public static double ToGradian(double val)
        {
            double result = val * 200 / 1000 * pi;
            return result;
        }
        public static double ToDegree(double val)
        {
            double result = val * 180 / 1000 * pi;
            return result;
        }
        public static double ToRadian(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToAngularMinute(double val)
        {
            double result = val * (60 * 180) / 1000 * pi;
            return result;
        }
        public static double ToAngularSecond(double val)
        {
            double result = val * (3600 * 180) / 1000 * pi;
            return result;
        }
    }
    public static class Radian
    {
        private static double pi = System.Math.PI;
        public static double ToGradian(double val)
        {
            double result = val * 200 / pi;
            return result;
        }
        public static double ToDegree(double val)
        {
            double result = val * 180 / pi;
            return result;
        }
        public static double ToMilliradian(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToAngularMinute(double val)
        {
            double result = val * (60 * 180) / pi;
            return result;
        }
        public static double ToAngularSecond(double val)
        {
            double result = val * (3600 * 180) / pi;
            return result;
        }
    }
    public static class AngularMinute
    {
        private static double pi = System.Math.PI;
        public static double ToGradian(double val)
        {
            double result = val / 54;
            return result;
        }
        public static double ToDegree(double val)
        {
            double result = val / 60;
            return result;
        }
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / (60 * 180);
            return result;
        }
        public static double ToRadian(double val)
        {
            double result = val * pi / (60 * 180);
            return result;
        }
        public static double ToAngularSecond(double val)
        {
            double result = val * 60;
            return result;
        }
    }
    public static class AngularSecond
    {
        private static double pi = System.Math.PI;
        public static double ToGradian(double val)
        {
            double result = val / 3240;
            return result;
        }
        public static double ToDegree(double val)
        {
            double result = val / 3600;
            return result;
        }
        public static double ToMilliradian(double val)
        {
            double result = val * 1000 * pi / (180 * 3600);
            return result;
        }
        public static double ToRadian(double val)
        {
            double result = val * pi / (180 * 3600);
            return result;
        }
        public static double ToAngularMinute(double val)
        {
            double result = val / 60;
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.DataSize
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
    public static class Terabyte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000000000000;
            return result;
        }
    }
    public static class Petabyte
    {
        public static double ToExabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000000000000000;
            return result;
        }
    }
    public static class Exabyte
    {
        public static double ToPetabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToTerabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToGigabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToMegabyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
        public static double ToKilobyte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000000;
            return result;
        }
        public static double ToByte(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000000000;
            return result;
        }
        public static double ToBit(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 8000000000000000000;
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.Frequency
{
    public static class Hertz
    {
        public static double ToKilohertz(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToMegahertz(double val)
        {
            double result = val / 1000000;
            return result;
        }
        public static double ToGigahertz(double val)
        {
            double result = val / 1000000000;
            return result;
        }
    }
    public static class Kilohertz
    {
        public static double ToHertz(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToMegahertz(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToGigahertz(double val)
        {
            double result = val / 1000000;
            return result;
        }
    }
    public static class Megahertz
    {
        public static double ToHertz(double val)
        {
            double result = val * 1000000;
            return result;
        }
        public static double ToKilohertz(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToGigahertz(double val)
        {
            double result = val / 1000;
            return result;
        }
    }
    public static class Gigahertz
    {
        public static double ToHertz(double val)
        {
            double result = val * 1000000000;
            return result;
        }
        public static double ToKilohertz(double val)
        {
            double result = val * 1000000;
            return result;
        }
        public static double ToMegahertz(double val)
        {
            double result = val * 1000;
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.Length
{
    public static class Nanometer
    {
        public static double ToInches(double val)
        {
            double result = val / 25400000;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val / 304800000;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 914400000;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1609000000000;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 100000000000;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10000000000;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000000;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 1000000000;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val / 100000000;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val / 10000000;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val / 1000000;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val / 1000;
            return result;
        }
    }
    public static class Micrometer
    {
        public static double ToInches(double val)
        {
            double result = val / 25400;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val / 304800;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 914400;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1609344000;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 100000000;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10000000;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 1000000000;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 1000000;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val / 100000;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val / 10000;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 1000;
            return result;
        }
    }
    public static class Millimeter
    {
        public static double ToInches(double val)
        {
            double result = val / 25.4;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val / 304.8;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 914;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1609000;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 100000;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10000;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 1000000;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val / 100;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 1000000;
            return result;
        }
    }
    public static class Centimeter
    {
        public static double ToInches(double val)
        {
            double result = val / 2.54;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val / 30.48;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 91.44;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 160934;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 10000;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 100000;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 100;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val / 1000000;
            return result;
        }
    }
    public static class Decimeter
    {
        public static double ToInches(double val)
        {
            double result = val * 3.93701;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val / 3.048;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 9.144;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 16093.4;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 100;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 10000;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 100;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 100000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 100000000;
            return result;
        }
    }
    public static class Meter
    {
        public static double ToInches(double val)
        {
            double result = val * 39.3701;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 3.28084;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val * 1.09361;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1609;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 100;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 1000;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 100;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 1000000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 1000000000;
            return result;
        }
    }
    public static class Kilometer
    {
        public static double ToInches(double val)
        {
            double result = val * 39370.1;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 3280.84;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val * 1093.61;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1.609344;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val * 100;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 10000;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 100000;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 1000000;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val / 1000000000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val / 1000000000000;
            return result;
        }
    }
    public static class Decameter
    {
        public static double ToInches(double val)
        {
            double result = val * 393.701;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 32.8084;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val * 10.9361;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 160.93;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 100;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 100;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 10000;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 10000000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 10000000000;
            return result;
        }
    }
    public static class Hectometer
    {
        public static double ToInches(double val)
        {
            double result = val * 3937.01;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 328.084;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val * 109.361;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 16.093;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val * 10;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 10;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val * 100;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 1000;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 10000;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 100000;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 100000000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 100000000000;
            return result;
        }
    }
    public static class Mile
    {
        public static double ToInches(double val)
        {
            double result = val * 63360;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 5280;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val * 1760;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val * 16.093;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 161;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val * 1.609344;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val * 1609;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val / 16093;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 160934;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 1609340;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 1609340000;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 160934000000;
            return result;
        }
    }
    public static class Yard
    {
        public static double ToInches(double val)
        {
            double result = val * 36;
            return result;
        }
        public static double ToFeet(double val)
        {
            double result = val * 3;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 1760;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 109.36;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10.936;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 1093.6;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val * 0.9144;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 9.144;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 91.44;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 914.4;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 914400;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 914400000;
            return result;
        }
    }
    public static class Feet
    {
        public static double ToInches(double val)
        {
            double result = val * 12;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 3;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 5280;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 328.1;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 10.936;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 3281;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 3.281;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 9.144;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 30.48;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val / 304.8;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val / 304800;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val / 304800000;
            return result;
        }
    }
    public static class Inches
    {
        public static double ToFeet(double val)
        {
            double result = val / 12;
            return result;
        }
        public static double ToYards(double val)
        {
            double result = val / 36;
            return result;
        }
        public static double ToMiles(double val)
        {
            double result = val / 63360;
            return result;
        }
        public static double ToHectometer(double val)
        {
            double result = val / 3937;
            return result;
        }
        public static double ToDecameter(double val)
        {
            double result = val / 394.7;
            return result;
        }
        public static double ToKilometer(double val)
        {
            double result = val / 39370;
            return result;
        }
        public static double ToMeter(double val)
        {
            double result = val / 39.37;
            return result;
        }
        public static double ToDecimeter(double val)
        {
            double result = val * 16093;
            return result;
        }
        public static double ToCentimeter(double val)
        {
            double result = val * 2.54;
            return result;
        }
        public static double ToMillimeter(double val)
        {
            double result = val * 25.4;
            return result;
        }
        public static double ToMicrometer(double val)
        {
            double result = val * 25400;
            return result;
        }
        public static double ToNanometer(double val)
        {
            double result = val * 25400000;
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.Mass
{
    public static class Tons
    {
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 100;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000000;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.016;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.102;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.473;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00045359237;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * (double)1000000 / 28.34952;
            return result;
        }
    }
    public static class Kilograms
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000000;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000984;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0011023;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.15747;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2.2046;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35.274;
            return result;
        }
    }
    public static class Grams
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000000;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000098421;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000011023;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00015747;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0022046;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.035274;
            return result;
        }
    }
    public static class Milligrams
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000098421;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000011023;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000015747;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000022046;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000035274;
            return result;
        }
    }
    public static class Micrograms
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000000;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000000000;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1000;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000000098421;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000000011023;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00000000015747;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0000000022046;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000000035274;
            return result;
        }
    }
    public static class LongTons
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.98421;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00098421;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000098421;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000098421;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000000098421;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1.12;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 160;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2240;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 35840;
            return result;
        }
    }
    public static class ShortTons
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 1.1023;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0011023;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000011023;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000011023;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000000011023;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.89286;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 142.86;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 2000;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 32000;
            return result;
        }
    }
    public static class Stones
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 157.47;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.15747;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00015747;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000015747;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.00000000015747;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0062500;
            return result;
        }
        public static double ToShortTons(double val)
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
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 224;
            return result;
        }
    }
    public static class Pounds
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2204.6;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 2.2046;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0022046;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000022046;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.0000000022046;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00044643;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.00050000;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.071429;
            return result;
        }
        public static double ToOunces(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 16;
            return result;
        }
    }
    public static class Ounces
    {
        public static double ToTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35274;
            return result;
        }
        public static double ToKilograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 35.274;
            return result;
        }
        public static double ToGrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.035274;
            return result;
        }
        public static double ToMilligrams(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000035274;
            return result;
        }
        public static double ToMicrograms(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val / 0.000000035274;
            return result;
        }
        public static double ToLongTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000027902;
            return result;
        }
        public static double ToShortTons(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.000031250;
            return result;
        }
        public static double ToStones(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.0044643;
            return result;
        }
        public static double ToPounds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 0.062500;
            return result;
        }
    }
}
namespace uCalc.Math.Conversion.NumeralSystem
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
namespace uCalc.Math.Conversion.Temperature
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
namespace uCalc.Math.Conversion.Time
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
        public static double ToMilliseconds(double val)
        {
            if (double.IsNaN(val))
                throw new ArgumentException();
            double result = val * 1000;
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
namespace uCalc.Math
{
    class Functions
    {
        /// <summary>
        /// Returns the factorial value of number greater than zero.
        /// </summary>
        /// <param name="d">A number greater than or equal to 0, but less than or equal to System.Double.MaxValue.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double Factorial(double d)
        {
            if (d < 0)
                throw new ArgumentOutOfRangeException();
            else if (d == 0)
                return 1;
            else
            {
                double result = 0;
                for (double n = d; n > 0; n--)
                {
                    if (result == 0) result = n;
                    else result *= n;
                }
                return result;
            }

        }

    }

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
            if (!new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\)|\!)*$").IsMatch(task) && !new Regex(@"^\-?\d+(\.\d+)?$").IsMatch(task))
                throw new ArgumentException();

            task = task.Trim();
            while (task.Contains("  "))
                task = task.Replace("  ", "");

            bool unclosedBrackets = task.Count(c => c == '(') != task.Count(c => c == ')');
            bool onlyValidCharacters = new Regex(@"^(\d+(\.\d+)?|\+|\-|\*|\/|\^|\(|\)|\!)*$").IsMatch(task);
            bool wrongFormat = new Regex(@"((\+|\-|\*|\/|\(|^)(!|\^|\)|$)|(\^|\/|\()($|!|\+|\*|\/|\))|(\/|\*)(\/|\*)|\d\(|\)\d|\($)").IsMatch(task);
            bool rightSyntax = onlyValidCharacters && !wrongFormat && !unclosedBrackets;
            if (rightSyntax)
            {
                // Factorial
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)!").Matches(task))
                {
                    string subTask = match.Value.Substring(0, match.Value.Length - 1);
                    if (subTask.StartsWith("("))
                        subTask.Substring(1);
                    if (subTask.StartsWith("-"))
                        task = "0";
                    else
                        task = task.Replace(match.Value, Functions.Factorial(double.Parse(subTask, CultureInfo.InvariantCulture)).ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                }

                // Powers
                foreach (Match match in new Regex(@"(\(\-\d+(\.\d+)?\)|^\-\d+(\.\d+)?|\d+(\.\d+)?)\^(\(\-\d+(\.\d+)?\)|\-?\d+(\.\d+)?)").Matches(task))
                {
                    string[] splittedTask = match.Value.Split('^');
                    double firstNumber = splittedTask[0].StartsWith("(") && splittedTask[0].EndsWith(")") ? double.Parse(splittedTask[0].Substring(1, splittedTask[0].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[0], CultureInfo.InvariantCulture);
                    double secondNumber = splittedTask[1].StartsWith("(") && splittedTask[1].EndsWith(")") ? double.Parse(splittedTask[1].Substring(1, splittedTask[1].Length - 2), CultureInfo.InvariantCulture) : double.Parse(splittedTask[1], CultureInfo.InvariantCulture);
                    double result = System.Math.Pow(firstNumber, secondNumber);
                    if ((firstNumber < 0 && secondNumber < 0) || (firstNumber > 0 && secondNumber < 0 && secondNumber % 2 != 0))
                        result = result * -1;

                    task = task.Replace(match.Value, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                }

                // Brackets
                while (task.Contains('('))
                {
                    string subtask = new Regex(@"\((\d|\.|\+|\-|\*|\/)*\)").Match(task).Value;
                    task = task.Replace(subtask, CalculateString(subtask.Substring(1, subtask.Length - 2)).ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
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
                    //task = task.Replace(subtask, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""), 1);
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
                    //task = task.Replace(subtask, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""));
                    char[] subtask2Chars = subtask.ToCharArray();
                    string newPattern = "";
                    foreach (char c in subtask2Chars)
                    {
                        if (new Regex(@"\d").IsMatch(c.ToString()))
                            newPattern = newPattern + c;
                        else
                            newPattern = newPattern + "\\" + c;
                    }
                    task = new Regex(newPattern).Replace(task, result.ToString("N10", CultureInfo.InvariantCulture).Replace(",", ""), 1);
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
