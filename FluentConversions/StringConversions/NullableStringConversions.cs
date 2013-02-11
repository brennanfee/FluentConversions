// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableStringConversions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class NullableStringConversions
    {
        private readonly string _input;

        public NullableStringConversions(string input)
        {
            _input = input;
        }

        public byte? Byte()
        {
            return GenericStringParser.TryParseNullable<byte>(_input, byte.TryParse);
        }

        public byte? Byte(IFormatProvider provider)
        {
            return Byte(NumberStyles.Integer, provider);
        }

        public byte? Byte(NumberStyles style)
        {
            return Byte(style, CultureInfo.CurrentCulture);
        }

        public byte? Byte(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<byte>(_input, style, provider, byte.TryParse);
        }

        public byte? ByteInvariant()
        {
            return Byte(CultureInfo.InvariantCulture);
        }

        public byte? ByteInvariant(NumberStyles style)
        {
            return Byte(style, CultureInfo.InvariantCulture);
        }

        public byte? ByteCulture()
        {
            return Byte(CultureInfo.CurrentCulture);
        }

        public byte? ByteCulture(NumberStyles style)
        {
            return Byte(style, CultureInfo.CurrentCulture);
        }

        public short? Int16()
        {
            return GenericStringParser.TryParseNullable<short>(_input, short.TryParse);
        }

        public short? Int16(IFormatProvider provider)
        {
            return Int16(NumberStyles.Integer, provider);
        }

        public short? Int16(NumberStyles style)
        {
            return Int16(style, CultureInfo.CurrentCulture);
        }

        public short? Int16(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<short>(_input, style, provider, short.TryParse);
        }

        public short? Int16Invariant()
        {
            return Int16(CultureInfo.InvariantCulture);
        }

        public short? Int16Invariant(NumberStyles style)
        {
            return Int16(style, CultureInfo.InvariantCulture);
        }

        public short? Int16Culture()
        {
            return Int16(CultureInfo.CurrentCulture);
        }

        public short? Int16Culture(NumberStyles style)
        {
            return Int16(style, CultureInfo.CurrentCulture);
        }

        public int? Int32()
        {
            return GenericStringParser.TryParseNullable<int>(_input, int.TryParse);
        }

        public int? Int32(IFormatProvider provider)
        {
            return Int32(NumberStyles.Integer, provider);
        }

        public int? Int32(NumberStyles style)
        {
            return Int32(style, CultureInfo.CurrentCulture);
        }

        public int? Int32(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<int>(_input, style, provider, int.TryParse);
        }

        public int? Int32Invariant()
        {
            return Int32(CultureInfo.InvariantCulture);
        }

        public int? Int32Invariant(NumberStyles style)
        {
            return Int32(style, CultureInfo.InvariantCulture);
        }

        public int? Int32Culture()
        {
            return Int32(CultureInfo.CurrentCulture);
        }

        public int? Int32Culture(NumberStyles style)
        {
            return Int32(style, CultureInfo.CurrentCulture);
        }

        public long? Int64()
        {
            return GenericStringParser.TryParseNullable<long>(_input, long.TryParse);
        }

        public long? Int64(IFormatProvider provider)
        {
            return Int64(NumberStyles.Integer, provider);
        }

        public long? Int64(NumberStyles style)
        {
            return Int64(style, CultureInfo.CurrentCulture);
        }

        public long? Int64(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<long>(_input, style, provider, long.TryParse);
        }

        public long? Int64Invariant()
        {
            return Int64(CultureInfo.InvariantCulture);
        }

        public long? Int64Invariant(NumberStyles style)
        {
            return Int64(style, CultureInfo.InvariantCulture);
        }

        public long? Int64Culture()
        {
            return Int64(CultureInfo.CurrentCulture);
        }

        public long? Int64Culture(NumberStyles style)
        {
            return Int64(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public sbyte? SByte()
        {
            return GenericStringParser.TryParseNullable<sbyte>(_input, sbyte.TryParse);
        }

        [CLSCompliant(false)]
        public sbyte? SByte(IFormatProvider provider)
        {
            return SByte(NumberStyles.Integer, provider);
        }

        [CLSCompliant(false)]
        public sbyte? SByte(NumberStyles style)
        {
            return SByte(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public sbyte? SByte(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<sbyte>(_input, style, provider, sbyte.TryParse);
        }

        [CLSCompliant(false)]
        public sbyte? SByteInvariant()
        {
            return SByte(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public sbyte? SByteInvariant(NumberStyles style)
        {
            return SByte(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public sbyte? SByteCulture()
        {
            return SByte(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public sbyte? SByteCulture(NumberStyles style)
        {
            return SByte(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ushort? UInt16()
        {
            return GenericStringParser.TryParseNullable<ushort>(_input, ushort.TryParse);
        }

        [CLSCompliant(false)]
        public ushort? UInt16(IFormatProvider provider)
        {
            return UInt16(NumberStyles.Integer, provider);
        }

        [CLSCompliant(false)]
        public ushort? UInt16(NumberStyles style)
        {
            return UInt16(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ushort? UInt16(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<ushort>(_input, style, provider, ushort.TryParse);
        }

        [CLSCompliant(false)]
        public ushort? UInt16Invariant()
        {
            return UInt16(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ushort? UInt16Invariant(NumberStyles style)
        {
            return UInt16(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ushort? UInt16Culture()
        {
            return UInt16(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ushort? UInt16Culture(NumberStyles style)
        {
            return UInt16(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public uint? UInt32()
        {
            return GenericStringParser.TryParseNullable<uint>(_input, uint.TryParse);
        }

        [CLSCompliant(false)]
        public uint? UInt32(IFormatProvider provider)
        {
            return UInt32(NumberStyles.Integer, provider);
        }

        [CLSCompliant(false)]
        public uint? UInt32(NumberStyles style)
        {
            return UInt32(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public uint? UInt32(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<uint>(_input, style, provider, uint.TryParse);
        }

        [CLSCompliant(false)]
        public uint? UInt32Invariant()
        {
            return UInt32(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public uint? UInt32Invariant(NumberStyles style)
        {
            return UInt32(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public uint? UInt32Culture()
        {
            return UInt32(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public uint? UInt32Culture(NumberStyles style)
        {
            return UInt32(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ulong? UInt64()
        {
            return GenericStringParser.TryParseNullable<ulong>(_input, ulong.TryParse);
        }

        [CLSCompliant(false)]
        public ulong? UInt64(IFormatProvider provider)
        {
            return UInt64(NumberStyles.Integer, provider);
        }

        [CLSCompliant(false)]
        public ulong? UInt64(NumberStyles style)
        {
            return UInt64(style, CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ulong? UInt64(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<ulong>(_input, style, provider, ulong.TryParse);
        }

        [CLSCompliant(false)]
        public ulong? UInt64Invariant()
        {
            return UInt64(CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ulong? UInt64Invariant(NumberStyles style)
        {
            return UInt64(style, CultureInfo.InvariantCulture);
        }

        [CLSCompliant(false)]
        public ulong? UInt64Culture()
        {
            return UInt64(CultureInfo.CurrentCulture);
        }

        [CLSCompliant(false)]
        public ulong? UInt64Culture(NumberStyles style)
        {
            return UInt64(style, CultureInfo.CurrentCulture);
        }

        public float? Single()
        {
            return GenericStringParser.TryParseNullable<float>(_input, float.TryParse);
        }

        public float? Single(IFormatProvider provider)
        {
            return Single(NumberStyles.Float | NumberStyles.AllowThousands, provider);
        }

        public float? Single(NumberStyles style)
        {
            return Single(style, CultureInfo.CurrentCulture);
        }

        public float? Single(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<float>(_input, style, provider, float.TryParse);
        }

        public float? SingleInvariant()
        {
            return Single(CultureInfo.InvariantCulture);
        }

        public float? SingleInvariant(NumberStyles style)
        {
            return Single(style, CultureInfo.InvariantCulture);
        }

        public float? SingleCulture()
        {
            return Single(CultureInfo.CurrentCulture);
        }

        public float? SingleCulture(NumberStyles style)
        {
            return Single(style, CultureInfo.CurrentCulture);
        }

        public double? Double()
        {
            return GenericStringParser.TryParseNullable<double>(_input, double.TryParse);
        }

        public double? Double(IFormatProvider provider)
        {
            return Double(NumberStyles.Float | NumberStyles.AllowThousands, provider);
        }

        public double? Double(NumberStyles style)
        {
            return Double(style, CultureInfo.CurrentCulture);
        }

        public double? Double(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<double>(_input, style, provider, double.TryParse);
        }

        public double? DoubleInvariant()
        {
            return Double(CultureInfo.InvariantCulture);
        }

        public double? DoubleInvariant(NumberStyles style)
        {
            return Double(style, CultureInfo.InvariantCulture);
        }

        public double? DoubleCulture()
        {
            return Double(CultureInfo.CurrentCulture);
        }

        public double? DoubleCulture(NumberStyles style)
        {
            return Double(style, CultureInfo.CurrentCulture);
        }

        public decimal? Decimal()
        {
            return GenericStringParser.TryParseNullable<decimal>(_input, decimal.TryParse);
        }

        public decimal? Decimal(IFormatProvider provider)
        {
            return Decimal(NumberStyles.Number, provider);
        }

        public decimal? Decimal(NumberStyles style)
        {
            return Decimal(style, CultureInfo.CurrentCulture);
        }

        public decimal? Decimal(NumberStyles style, IFormatProvider provider)
        {
            return GenericStringParser.TryParseNullableNumeric<decimal>(_input, style, provider, decimal.TryParse);
        }

        public decimal? DecimalInvariant()
        {
            return Decimal(CultureInfo.InvariantCulture);
        }

        public decimal? DecimalInvariant(NumberStyles style)
        {
            return Decimal(style, CultureInfo.InvariantCulture);
        }

        public decimal? DecimalCulture()
        {
            return Decimal(CultureInfo.CurrentCulture);
        }

        public decimal? DecimalCulture(NumberStyles style)
        {
            return Decimal(style, CultureInfo.CurrentCulture);
        }

        public decimal? Currency(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency);
            if (!result.HasValue)
                return null;

            return round ? Math.Round(result.Value, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal? Currency(IFormatProvider provider, bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, provider);
            if (!result.HasValue)
                return null;

            if (round)
            {
                provider = provider ?? CultureInfo.CurrentCulture;
                var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
                return Math.Round(result.Value, numberFormat.CurrencyDecimalDigits);
            }

            return result;
        }

        public decimal? CurrencyInvariant(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.InvariantCulture);
            if (!result.HasValue)
                return null;

            return round ? Math.Round(result.Value, CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public decimal? CurrencyCulture(bool round = false)
        {
            var result = Decimal(NumberStyles.Currency, CultureInfo.CurrentCulture);
            if (!result.HasValue)
                return null;

            return round ? Math.Round(result.Value, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits) : result;
        }

        public char? Char()
        {
            return GenericStringParser.TryParseNullable<char>(_input, char.TryParse);
        }

        public bool? Bool()
        {
            return GenericStringParser.TryParseNullable<bool>(_input, bool.TryParse);
        }

        public Guid? Guid()
        {
            return GenericStringParser.TryParseNullable<Guid>(_input, System.Guid.TryParse);
        }

        public Guid? GuidExact(string format = "D")
        {
            Guid result;
            if (!System.Guid.TryParseExact(_input, format, out result))
                return null;

            return result;
        }

        public T? Enum<T>(bool ignoreCase = true) where T : struct
        {
            T result;
            if (!System.Enum.TryParse(_input, ignoreCase, out result))
                return null;

            return result;
        }

        public DateTime? DateTime(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeTryParseNullable(_input, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? DateTime(IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeTryParseNullable(_input, provider, styles);
        }

        public DateTime? ParseExact(string format, IFormatProvider provider)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, format, provider, DateTimeStyles.AllowWhiteSpaces);
        }

        public DateTime? ParseExact(IEnumerable<string> formats, IFormatProvider provider)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, formats, provider, DateTimeStyles.AllowWhiteSpaces);
        }

        public DateTime? ParseExact(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, format, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? ParseExact(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, formats, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? ParseExact(string format, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, format, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTimeStringParser.DateTimeTryParseExactNullable(_input, formats, provider, styles);
        }

        public DateTime? DateTimeCulture()
        {
            return GenericStringParser.ParseCulture(_input, CultureInfo.CurrentCulture, System.DateTime.Parse);
        }

        public DateTime? DateTimeCulture(DateTimeStyles styles)
        {
            return System.DateTime.Parse(_input, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? ParseExactCulture(string format)
        {
            return System.DateTime.ParseExact(_input, format, CultureInfo.CurrentCulture);
        }

        public DateTime? ParseExactCulture(IEnumerable<string> formats)
        {
            return System.DateTime.ParseExact(_input, formats.ToArray(), CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }

        public DateTime? ParseExactCulture(string format, DateTimeStyles styles)
        {
            return System.DateTime.ParseExact(_input, format, CultureInfo.CurrentCulture, styles);
        }

        public DateTime? ParseExactCulture(IEnumerable<string> formats, DateTimeStyles styles)
        {
            return System.DateTime.ParseExact(_input, formats.ToArray(), CultureInfo.CurrentCulture, styles);
        }

        public DateTime? DateTimeInvariant()
        {
            return GenericStringParser.ParseCulture(_input, CultureInfo.InvariantCulture, System.DateTime.Parse);
        }

        public DateTime? DateTimeInvariant(DateTimeStyles styles)
        {
            return System.DateTime.Parse(_input, CultureInfo.InvariantCulture, styles);
        }

        public DateTime? ParseExactInvariant(string format)
        {
            return System.DateTime.ParseExact(_input, format, CultureInfo.InvariantCulture);
        }

        public DateTime? ParseExactInvariant(IEnumerable<string> formats)
        {
            return System.DateTime.ParseExact(_input, formats.ToArray(), CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
        }

        public DateTime? ParseExactInvariant(string format, DateTimeStyles styles)
        {
            return System.DateTime.ParseExact(_input, format, CultureInfo.InvariantCulture, styles);
        }

        public DateTime? ParseExactInvariant(IEnumerable<string> formats, DateTimeStyles styles)
        {
            return System.DateTime.ParseExact(_input, formats.ToArray(), CultureInfo.InvariantCulture, styles);
        }
    }
}
