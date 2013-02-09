// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardStringConversions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions
{
    using System.Globalization;
    using System.Linq;

    public class StandardStringConversions
    {
        private readonly string _input;

        public StandardStringConversions(string input)
        {
            _input = input;
        }

        public byte Byte()
        {
            return GenericStringParser.Parse(_input, byte.Parse);
        }

        public byte Byte(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, byte.Parse);
        }

        public byte Byte(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, byte.Parse);
        }

        public byte Byte(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, byte.Parse);
        }

        public byte ByteInvariant()
        {
            return Byte(CultureInfo.InvariantCulture);
        }

        public byte ByteInvariant(NumberStyles style)
        {
            return Byte(style, CultureInfo.InvariantCulture);
        }

        public byte ByteCulture()
        {
            return Byte(CultureInfo.CurrentCulture);
        }

        public byte ByteCulture(NumberStyles style)
        {
            return Byte(style, CultureInfo.CurrentCulture);
        }

        public short Int16()
        {
            return GenericStringParser.Parse(_input, short.Parse);
        }

        public short Int16(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, short.Parse);
        }

        public short Int16(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, short.Parse);
        }

        public short Int16(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, short.Parse);
        }

        public short Int16Invariant()
        {
            return Int16(CultureInfo.InvariantCulture);
        }

        public short Int16Invariant(NumberStyles style)
        {
            return Int16(style, CultureInfo.InvariantCulture);
        }

        public short Int16Culture()
        {
            return Int16(CultureInfo.CurrentCulture);
        }

        public short Int16Culture(NumberStyles style)
        {
            return Int16(style, CultureInfo.CurrentCulture);
        }

        public int Int32()
        {
            return GenericStringParser.Parse(_input, int.Parse);
        }

        public int Int32(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, int.Parse);
        }

        public int Int32(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, int.Parse);
        }

        public int Int32(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, int.Parse);
        }

        public int Int32Invariant()
        {
            return Int32(CultureInfo.InvariantCulture);
        }

        public int Int32Invariant(NumberStyles style)
        {
            return Int32(style, CultureInfo.InvariantCulture);
        }

        public int Int32Culture()
        {
            return Int32(CultureInfo.CurrentCulture);
        }

        public int Int32Culture(NumberStyles style)
        {
            return Int32(style, CultureInfo.CurrentCulture);
        }

        public long Int64()
        {
            return GenericStringParser.Parse(_input, long.Parse);
        }

        public long Int64(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, long.Parse);
        }

        public long Int64(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, long.Parse);
        }

        public long Int64(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, long.Parse);
        }

        public long Int64Invariant()
        {
            return Int64(CultureInfo.InvariantCulture);
        }

        public long Int64Invariant(NumberStyles style)
        {
            return Int64(style, CultureInfo.InvariantCulture);
        }

        public long Int64Culture()
        {
            return Int64(CultureInfo.CurrentCulture);
        }

        public long Int64Culture(NumberStyles style)
        {
            return Int64(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public sbyte SByte()
        {
            return GenericStringParser.Parse(_input, sbyte.Parse);
        }

        [CLSCompliant(false)]
        public sbyte SByte(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, sbyte.Parse);
        }

        [CLSCompliant(false)]
        public sbyte SByte(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, sbyte.Parse);
        }

        [CLSCompliant(false)]
        public sbyte SByte(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, sbyte.Parse);
        }

        [CLSCompliant(false)]
        public sbyte SByteInvariant()
        {
            return SByte(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public sbyte SByteInvariant(NumberStyles style)
        {
            return SByte(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public sbyte SByteCulture()
        {
            return SByte(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public sbyte SByteCulture(NumberStyles style)
        {
            return SByte(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ushort UInt16()
        {
            return GenericStringParser.Parse(_input, ushort.Parse);
        }

        [CLSCompliant(false)]
        public ushort UInt16(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, ushort.Parse);
        }

        [CLSCompliant(false)]
        public ushort UInt16(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, ushort.Parse);
        }

        [CLSCompliant(false)]
        public ushort UInt16(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, ushort.Parse);
        }

        [CLSCompliant(false)]
        public ushort UInt16Invariant()
        {
            return UInt16(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ushort UInt16Invariant(NumberStyles style)
        {
            return UInt16(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ushort UInt16Culture()
        {
            return UInt16(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ushort UInt16Culture(NumberStyles style)
        {
            return UInt16(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public uint UInt32()
        {
            return GenericStringParser.Parse(_input, uint.Parse);
        }

        [CLSCompliant(false)]
        public uint UInt32(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, uint.Parse);
        }

        [CLSCompliant(false)]
        public uint UInt32(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, uint.Parse);
        }

        [CLSCompliant(false)]
        public uint UInt32(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, uint.Parse);
        }

        [CLSCompliant(false)]
        public uint UInt32Invariant()
        {
            return UInt32(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public uint UInt32Invariant(NumberStyles style)
        {
            return UInt32(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public uint UInt32Culture()
        {
            return UInt32(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public uint UInt32Culture(NumberStyles style)
        {
            return UInt32(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ulong UInt64()
        {
            return GenericStringParser.Parse(_input, ulong.Parse);
        }

        [CLSCompliant(false)]
        public ulong UInt64(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, ulong.Parse);
        }

        [CLSCompliant(false)]
        public ulong UInt64(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, ulong.Parse);
        }

        [CLSCompliant(false)]
        public ulong UInt64(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, ulong.Parse);
        }

        [CLSCompliant(false)]
        public ulong UInt64Invariant()
        {
            return UInt64(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ulong UInt64Invariant(NumberStyles style)
        {
            return UInt64(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ulong UInt64Culture()
        {
            return UInt64(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ulong UInt64Culture(NumberStyles style)
        {
            return UInt64(style, CultureInfo.CurrentCulture);
        }

        public float Single()
        {
            return GenericStringParser.Parse(_input, float.Parse);
        }

        public float Single(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, float.Parse);
        }

        public float Single(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, float.Parse);
        }

        public float Single(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, float.Parse);
        }

        public float SingleInvariant()
        {
            return Single(CultureInfo.InvariantCulture);
        }

        public float SingleInvariant(NumberStyles style)
        {
            return Single(style, CultureInfo.InvariantCulture);
        }

        public float SingleCulture()
        {
            return Single(CultureInfo.CurrentCulture);
        }

        public float SingleCulture(NumberStyles style)
        {
            return Single(style, CultureInfo.CurrentCulture);
        }

        public double Double()
        {
            return GenericStringParser.Parse(_input, double.Parse);
        }

        public double Double(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, double.Parse);
        }

        public double Double(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, double.Parse);
        }

        public double Double(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, double.Parse);
        }

        public double DoubleInvariant()
        {
            return Double(CultureInfo.InvariantCulture);
        }

        public double DoubleInvariant(NumberStyles style)
        {
            return Double(style, CultureInfo.InvariantCulture);
        }

        public double DoubleCulture()
        {
            return Double(CultureInfo.CurrentCulture);
        }

        public double DoubleCulture(NumberStyles style)
        {
            return Double(style, CultureInfo.CurrentCulture);
        }

        public decimal Decimal()
        {
            return GenericStringParser.Parse(_input, decimal.Parse);
        }

        public decimal Decimal(IFormatProvider provider)
        {
            return GenericStringParser.ParseCulture(_input, provider, decimal.Parse);
        }

        public decimal Decimal(NumberStyles style)
        {
            return GenericStringParser.ParseNumeric(_input, style, decimal.Parse);
        }

        public decimal Decimal(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.ParseNumericCulture(_input, style, provider, decimal.Parse);
        }

        public decimal DecimalInvariant()
        {
            return Decimal(CultureInfo.InvariantCulture);
        }

        public decimal DecimalInvariant(NumberStyles style)
        {
            return Decimal(style, CultureInfo.InvariantCulture);
        }

        public decimal DecimalCulture()
        {
            return Decimal(CultureInfo.CurrentCulture);
        }

        public decimal DecimalCulture(NumberStyles style)
        {
            return Decimal(style, CultureInfo.CurrentCulture);
        }

        public decimal Currency(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency);
            return round ? Math.Round(result, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal Currency(IFormatProvider provider, bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, provider);

            if (round)
            {
                provider = provider ?? CultureInfo.CurrentCulture;
                var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
                return Math.Round(result, numberFormat.CurrencyDecimalDigits);
            }

            return result;
        }

        public decimal CurrencyInvariant(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.InvariantCulture);
            return round ? Math.Round(result, CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal CurrencyCulture(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.CurrentCulture);
            return round ? Math.Round(result, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }
    }
}
