using System.Numerics;

namespace CompaDecimalSystem;

public static class CompaDecimalExtensions
{
    public static CompaDecimal ToCompaDecimal(this string value)
    {
        return new CompaDecimal(value);
    }

    public static CompaDecimal ToCompaDecimal<T>(this T value) where T : struct, IConvertible
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Byte:
            case TypeCode.SByte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
                // Convert to long for processing
                long longValue = Convert.ToInt64(value);
                return ToCompaDecimal(longValue);
            default:
                throw new ArgumentException("Type must be an integer type.");
        }
    }

    public static CompaDecimal ToCompaDecimal(this long value)
    {
        char[] compa_digits = GetCompaDigits();
        int base_size = compa_digits.Length;
        string result = string.Empty;

        if (value == 0)
        {
            return new CompaDecimal(compa_digits[0].ToString());
        }

        while (value > 0)
        {
            int remainder = (int)(value % base_size);
            result = compa_digits[remainder] + result;
            value /= base_size;
        }

        return new CompaDecimal(result);
    }

    public static CompaDecimal ToCompaDecimal(this BigInteger value)
    {
        char[] compa_digits = GetCompaDigits();
        int base_size = compa_digits.Length;
        string result = string.Empty;

        if (value == 0)
        {
            return new CompaDecimal(compa_digits[0].ToString());
        }

        BigInteger workingValue = BigInteger.Abs(value);
        while (workingValue > 0)
        {
            int remainder = (int)(workingValue % base_size);
            result = compa_digits[remainder] + result;
            workingValue /= base_size;
        }

        return new CompaDecimal(result);
    }

    public static BigInteger ToBigInteger(this CompaDecimal compaDecimal)
    {
        char[] compa_digits = GetCompaDigits();
        int base_size = compa_digits.Length;
        BigInteger result = 0;

        for (int i = 0; i < compaDecimal.Value.Length; i++)
        {
            char c = compaDecimal.Value[i];
            int digitValue = Array.IndexOf(compa_digits, c);
            if (digitValue < 0)
            {
                throw new ArgumentException($"Character '{c}' is not a valid CompaDecimal character.");
            }
            result = result * base_size + digitValue;
        }

        return result;
    }

    public static long ToLong(this CompaDecimal compaDecimal)
{
    return (long)compaDecimal.ToBigInteger();
}

    public static int ToInt(this CompaDecimal compaDecimal)
    {
        return (int)compaDecimal.ToBigInteger();
    }

    public static short ToShort(this CompaDecimal compaDecimal)
    {
        return (short)compaDecimal.ToBigInteger();
    }

    public static byte ToByte(this CompaDecimal compaDecimal)
    {
        return (byte)compaDecimal.ToBigInteger();
    }

    private static char[] GetCompaDigits()
    {
        return "0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!\"#$%&'()*+,-./:;<=>?@[\\]^_`|}{ ~".ToCharArray();
    }

}