// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableStringConversions.cs" company="Brennan A. Fee">
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

    public class NullableStringConversions
    {
        private readonly string _input;

        public NullableStringConversions(string input)
        {
            _input = input;
        }

        public GenericNumericConversionsNullable<byte> Byte
        {
            get { return new GenericNumericConversionsNullable<byte>(_input, byte.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsNullable<short> Int16
        {
            get { return new GenericNumericConversionsNullable<short>(_input, short.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsNullable<int> Int32
        {
            get { return new GenericNumericConversionsNullable<int>(_input, int.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsNullable<long> Int64
        {
            get { return new GenericNumericConversionsNullable<long>(_input, long.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsNullable<sbyte> SByte
        {
            get { return new GenericNumericConversionsNullable<sbyte>(_input, sbyte.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsNullable<ushort> UInt16
        {
            get { return new GenericNumericConversionsNullable<ushort>(_input, ushort.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsNullable<uint> UInt32
        {
            get { return new GenericNumericConversionsNullable<uint>(_input, uint.TryParse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsNullable<ulong> UInt64
        {
            get { return new GenericNumericConversionsNullable<ulong>(_input, ulong.TryParse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsNullable<float> Single
        {
            get { return new GenericNumericConversionsNullable<float>(_input, float.TryParse, NumberStyles.Float | NumberStyles.AllowThousands); }
        }

        public GenericNumericConversionsNullable<double> Double
        {
            get { return new GenericNumericConversionsNullable<double>(_input, double.TryParse, NumberStyles.Float | NumberStyles.AllowThousands); }
        }

        public GenericNumericConversionsNullable<decimal> Decimal
        {
            get { return new GenericNumericConversionsNullable<decimal>(_input, decimal.TryParse, NumberStyles.Number); }
        }

        public CurrencyConversionsNullable Currency
        {
            get { return new CurrencyConversionsNullable(_input); }
        }

        public CharConversionsNullable Char
        {
            get { return new CharConversionsNullable(_input); }
        }

        public BoolConversionsNullable Bool
        {
            get { return new BoolConversionsNullable(_input); }
        }

        public GuidConversionsNullable Guid
        {
            get { return new GuidConversionsNullable(_input); }
        }

        public EnumConversionsNullable Enum
        {
            get { return new EnumConversionsNullable(_input); }
        }

        public DateTimeConversionsNullable DateTime
        {
            get { return new DateTimeConversionsNullable(_input); }
        }

        public DateTimeOffsetConversionsNullable DateTimeOffset
        {
            get { return new DateTimeOffsetConversionsNullable(_input); }
        }
    }
}
