// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultStringConversions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions
{
    using System.Globalization;
    using System.Linq;

    public class DefaultStringConversions
    {
        private readonly string _input;

        public DefaultStringConversions(string input)
        {
            _input = input;
        }

        public byte Byte(byte defaultValue = default(byte))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, byte.TryParse);
        }

        public byte Byte(IFormatProvider provider, byte defaultValue = default(byte))
        {
            return Byte(NumberStyles.Integer, provider, defaultValue);
        }

        public byte Byte(NumberStyles style, byte defaultValue = default(byte))
        {
            return Byte(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public byte Byte(NumberStyles style, IFormatProvider provider, byte defaultValue = default(byte))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, byte.TryParse);
        }

        public byte ByteInvariant(byte defaultValue = default(byte))
        {
            return Byte(CultureInfo.InvariantCulture, defaultValue);
        }

        public byte ByteInvariant(NumberStyles style, byte defaultValue = default(byte))
        {
            return Byte(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public byte ByteCulture(byte defaultValue = default(byte))
        {
            return Byte(CultureInfo.CurrentCulture, defaultValue);
        }

        public byte ByteCulture(NumberStyles style, byte defaultValue = default(byte))
        {
            return Byte(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public short Int16(short defaultValue = default(short))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, short.TryParse);
        }

        public short Int16(IFormatProvider provider, short defaultValue = default(short))
        {
            return Int16(NumberStyles.Integer, provider, defaultValue);
        }

        public short Int16(NumberStyles style, short defaultValue = default(short))
        {
            return Int16(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public short Int16(NumberStyles style, IFormatProvider provider, short defaultValue = default(short))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, short.TryParse);
        }

        public short Int16Invariant(short defaultValue = default(short))
        {
            return Int16(CultureInfo.InvariantCulture, defaultValue);
        }

        public short Int16Invariant(NumberStyles style, short defaultValue = default(short))
        {
            return Int16(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public short Int16Culture(short defaultValue = default(short))
        {
            return Int16(CultureInfo.CurrentCulture, defaultValue);
        }

        public short Int16Culture(NumberStyles style, short defaultValue = default(short))
        {
            return Int16(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public int Int32(int defaultValue = default(int))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, int.TryParse);
        }

        public int Int32(IFormatProvider provider, int defaultValue = default(int))
        {
            return Int32(NumberStyles.Integer, provider, defaultValue);
        }

        public int Int32(NumberStyles style, int defaultValue = default(int))
        {
            return Int32(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public int Int32(NumberStyles style, IFormatProvider provider, int defaultValue = default(int))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, int.TryParse);
        }

        public int Int32Invariant(int defaultValue = default(int))
        {
            return Int32(CultureInfo.InvariantCulture, defaultValue);
        }

        public int Int32Invariant(NumberStyles style, int defaultValue = default(int))
        {
            return Int32(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public int Int32Culture(int defaultValue = default(int))
        {
            return Int32(CultureInfo.CurrentCulture, defaultValue);
        }

        public int Int32Culture(NumberStyles style, int defaultValue = default(int))
        {
            return Int32(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public long Int64(long defaultValue = default(long))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, long.TryParse);
        }

        public long Int64(IFormatProvider provider, long defaultValue = default(long))
        {
            return Int64(NumberStyles.Integer, provider, defaultValue);
        }

        public long Int64(NumberStyles style, long defaultValue = default(long))
        {
            return Int64(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public long Int64(NumberStyles style, IFormatProvider provider, long defaultValue = default(long))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, long.TryParse);
        }

        public long Int64Invariant(long defaultValue = default(long))
        {
            return Int64(CultureInfo.InvariantCulture, defaultValue);
        }

        public long Int64Invariant(NumberStyles style, long defaultValue = default(long))
        {
            return Int64(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public long Int64Culture(long defaultValue = default(long))
        {
            return Int64(CultureInfo.CurrentCulture, defaultValue);
        }

        public long Int64Culture(NumberStyles style, long defaultValue = default(long))
        {
            return Int64(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByte(sbyte defaultValue = default(sbyte))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, sbyte.TryParse);
        }

        [CLSCompliant(false)]
        public sbyte SByte(IFormatProvider provider, sbyte defaultValue = default(sbyte))
        {
            return SByte(NumberStyles.Integer, provider, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByte(NumberStyles style, sbyte defaultValue = default(sbyte))
        {
            return SByte(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByte(NumberStyles style, IFormatProvider provider, sbyte defaultValue = default(sbyte))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, sbyte.TryParse);
        }

        [CLSCompliant(false)]
        public sbyte SByteInvariant(sbyte defaultValue = default(sbyte))
        {
            return SByte(CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByteInvariant(NumberStyles style, sbyte defaultValue = default(sbyte))
        {
            return SByte(style, CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByteCulture(sbyte defaultValue = default(sbyte))
        {
            return SByte(CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public sbyte SByteCulture(NumberStyles style, sbyte defaultValue = default(sbyte))
        {
            return SByte(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16(ushort defaultValue = default(ushort))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, ushort.TryParse);
        }

        [CLSCompliant(false)]
        public ushort UInt16(IFormatProvider provider, ushort defaultValue = default(ushort))
        {
            return UInt16(NumberStyles.Integer, provider, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16(NumberStyles style, ushort defaultValue = default(ushort))
        {
            return UInt16(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16(NumberStyles style, IFormatProvider provider, ushort defaultValue = default(ushort))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, ushort.TryParse);
        }

        [CLSCompliant(false)]
        public ushort UInt16Invariant(ushort defaultValue = default(ushort))
        {
            return UInt16(CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16Invariant(NumberStyles style, ushort defaultValue = default(ushort))
        {
            return UInt16(style, CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16Culture(ushort defaultValue = default(ushort))
        {
            return UInt16(CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ushort UInt16Culture(NumberStyles style, ushort defaultValue = default(ushort))
        {
            return UInt16(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32(uint defaultValue = default(uint))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, uint.TryParse);
        }

        [CLSCompliant(false)]
        public uint UInt32(IFormatProvider provider, uint defaultValue = default(uint))
        {
            return UInt32(NumberStyles.Integer, provider, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32(NumberStyles style, uint defaultValue = default(uint))
        {
            return UInt32(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32(NumberStyles style, IFormatProvider provider, uint defaultValue = default(uint))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, uint.TryParse);
        }

        [CLSCompliant(false)]
        public uint UInt32Invariant(uint defaultValue = default(uint))
        {
            return UInt32(CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32Invariant(NumberStyles style, uint defaultValue = default(uint))
        {
            return UInt32(style, CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32Culture(uint defaultValue = default(uint))
        {
            return UInt32(CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public uint UInt32Culture(NumberStyles style, uint defaultValue = default(uint))
        {
            return UInt32(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64(ulong defaultValue = default(ulong))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, ulong.TryParse);
        }

        [CLSCompliant(false)]
        public ulong UInt64(IFormatProvider provider, ulong defaultValue = default(ulong))
        {
            return UInt64(NumberStyles.Integer, provider, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64(NumberStyles style, ulong defaultValue = default(ulong))
        {
            return UInt64(style, CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64(NumberStyles style, IFormatProvider provider, ulong defaultValue = default(ulong))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, ulong.TryParse);
        }

        [CLSCompliant(false)]
        public ulong UInt64Invariant(ulong defaultValue = default(ulong))
        {
            return UInt64(CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64Invariant(NumberStyles style, ulong defaultValue = default(ulong))
        {
            return UInt64(style, CultureInfo.InvariantCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64Culture(ulong defaultValue = default(ulong))
        {
            return UInt64(CultureInfo.CurrentCulture, defaultValue);
        }

        [CLSCompliant(false)]
        public ulong UInt64Culture(NumberStyles style, ulong defaultValue = default(ulong))
        {
            return UInt64(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public float Single(float defaultValue = default(float))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, float.TryParse);
        }

        public float Single(IFormatProvider provider, float defaultValue = default(float))
        {
            return Single(NumberStyles.Float | NumberStyles.AllowThousands, provider, defaultValue);
        }

        public float Single(NumberStyles style, float defaultValue = default(float))
        {
            return Single(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public float Single(NumberStyles style, IFormatProvider provider, float defaultValue = default(float))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, float.TryParse);
        }

        public float SingleInvariant(float defaultValue = default(float))
        {
            return Single(CultureInfo.InvariantCulture, defaultValue);
        }

        public float SingleInvariant(NumberStyles style, float defaultValue = default(float))
        {
            return Single(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public float SingleCulture(float defaultValue = default(float))
        {
            return Single(CultureInfo.CurrentCulture, defaultValue);
        }

        public float SingleCulture(NumberStyles style, float defaultValue = default(float))
        {
            return Single(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public double Double(double defaultValue = default(double))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, double.TryParse);
        }

        public double Double(IFormatProvider provider, double defaultValue = default(double))
        {
            return Double(NumberStyles.Float | NumberStyles.AllowThousands, provider, defaultValue);
        }

        public double Double(NumberStyles style, double defaultValue = default(double))
        {
            return Double(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public double Double(NumberStyles style, IFormatProvider provider, double defaultValue = default(double))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, double.TryParse);
        }

        public double DoubleInvariant(double defaultValue = default(double))
        {
            return Double(CultureInfo.InvariantCulture, defaultValue);
        }

        public double DoubleInvariant(NumberStyles style, double defaultValue = default(double))
        {
            return Double(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public double DoubleCulture(double defaultValue = default(double))
        {
            return Double(CultureInfo.CurrentCulture, defaultValue);
        }

        public double DoubleCulture(NumberStyles style, double defaultValue = default(double))
        {
            return Double(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public decimal Decimal(decimal defaultValue = default(decimal))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, decimal.TryParse);
        }

        public decimal Decimal(IFormatProvider provider, decimal defaultValue = default(decimal))
        {
            return Decimal(NumberStyles.Number, provider, defaultValue);
        }

        public decimal Decimal(NumberStyles style, decimal defaultValue = default(decimal))
        {
            return Decimal(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public decimal Decimal(NumberStyles style, IFormatProvider provider, decimal defaultValue = default(decimal))
        {
            return GenericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, decimal.TryParse);
        }

        public decimal DecimalInvariant(decimal defaultValue = default(decimal))
        {
            return Decimal(CultureInfo.InvariantCulture, defaultValue);
        }

        public decimal DecimalInvariant(NumberStyles style, decimal defaultValue = default(decimal))
        {
            return Decimal(style, CultureInfo.InvariantCulture, defaultValue);
        }

        public decimal DecimalCulture(decimal defaultValue = default(decimal))
        {
            return Decimal(CultureInfo.CurrentCulture, defaultValue);
        }

        public decimal DecimalCulture(NumberStyles style, decimal defaultValue = default(decimal))
        {
            return Decimal(style, CultureInfo.CurrentCulture, defaultValue);
        }

        public decimal Currency(decimal defaultValue = default(decimal), bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, defaultValue);
            return round ? Math.Round(result, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal Currency(IFormatProvider provider, decimal defaultValue = default(decimal), bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, provider, defaultValue);

            if (round)
            {
                provider = provider ?? CultureInfo.CurrentCulture;
                var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
                return Math.Round(result, numberFormat.CurrencyDecimalDigits);
            }

            return result;
        }

        public decimal CurrencyInvariant(decimal defaultValue = default(decimal), bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.InvariantCulture, defaultValue);
            return round ? Math.Round(result, CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal CurrencyCulture(decimal defaultValue = default(decimal), bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.CurrentCulture, defaultValue);
            return round ? Math.Round(result, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public char Char(char defaultValue = default(char))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, char.TryParse);
        }

        public bool Bool(bool defaultValue = default(bool))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, bool.TryParse);
        }

        public Guid Guid(Guid defaultValue = default(Guid))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, System.Guid.TryParse);
        }

        public Guid GuidExact(string format = "D", Guid defaultValue = default(Guid))
        {
            Guid result;
            return !System.Guid.TryParseExact(_input, format, out result) ? defaultValue : result;
        }

        public T Enum<T>(T defaultValue = default(T), bool ignoreCase = true) where T : struct
        {
            T result;
            return !System.Enum.TryParse(_input, ignoreCase, out result) ? defaultValue : result;
        }
    }
}
