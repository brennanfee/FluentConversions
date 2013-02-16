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
    using FluentConversions.StringConversions.DateTimeConverters;
    using FluentConversions.StringConversions.NumericConverters;
    using FluentConversions.StringConversions.OtherConverters;

    public class DefaultStringConversions
    {
        private readonly string _input;

        public DefaultStringConversions(string input)
        {
            _input = input;
        }

        public GenericNumericConversionsDefault<byte> Byte
        {
            get { return new GenericNumericConversionsDefault<byte>(_input, byte.TryParse, byte.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsDefault<short> Int16
        {
            get { return new GenericNumericConversionsDefault<short>(_input, short.TryParse, short.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsDefault<int> Int32
        {
            get { return new GenericNumericConversionsDefault<int>(_input, int.TryParse, int.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsDefault<long> Int64
        {
            get { return new GenericNumericConversionsDefault<long>(_input, long.TryParse, long.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsDefault<sbyte> SByte
        {
            get { return new GenericNumericConversionsDefault<sbyte>(_input, sbyte.TryParse, sbyte.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsDefault<ushort> UInt16
        {
            get { return new GenericNumericConversionsDefault<ushort>(_input, ushort.TryParse, ushort.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsDefault<uint> UInt32
        {
            get { return new GenericNumericConversionsDefault<uint>(_input, uint.TryParse, uint.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsDefault<ulong> UInt64
        {
            get { return new GenericNumericConversionsDefault<ulong>(_input, ulong.TryParse, ulong.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsDefault<float> Single
        {
            get
            {
                return new GenericNumericConversionsDefault<float>(
                    _input, float.TryParse, float.TryParse, NumberStyles.Float | NumberStyles.AllowThousands);
            }
        }

        public GenericNumericConversionsDefault<double> Double
        {
            get
            {
                return new GenericNumericConversionsDefault<double>(
                    _input, double.TryParse, double.TryParse, NumberStyles.Float | NumberStyles.AllowThousands);
            }
        }

        public GenericNumericConversionsDefault<decimal> Decimal
        {
            get { return new GenericNumericConversionsDefault<decimal>(_input, decimal.TryParse, decimal.TryParse, NumberStyles.Number); }
        }

        public CurrencyConversionsDefault Currency
        {
            get { return new CurrencyConversionsDefault(_input); }
        }

        public CharConversionsDefault Char
        {
            get { return new CharConversionsDefault(_input); }
        }

        public BoolConversionsDefault Bool
        {
            get { return new BoolConversionsDefault(_input); }
        }

        public GuidConversionsDefault Guid
        {
            get { return new GuidConversionsDefault(_input); }
        }

        public EnumConversionsDefault Enum
        {
            get { return new EnumConversionsDefault(_input); }
        }

        public DateTimeConversionsDefault DateTime
        {
            get { return new DateTimeConversionsDefault(_input); }
        }

        public DateTimeOffsetConversionsDefault DateTimeOffset
        {
            get { return new DateTimeOffsetConversionsDefault(_input); }
        }

        public TimeSpanConversionsDefault TimeSpan
        {
            get { return new TimeSpanConversionsDefault(_input); }
        }
    }
}
