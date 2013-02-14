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
    using FluentConversions.StringConversions.DateTimeConverters;
    using FluentConversions.StringConversions.NumericConverters;
    using FluentConversions.StringConversions.OtherConverters;

    public class StandardStringConversions
    {
        private readonly string _input;

        public StandardStringConversions(string input)
        {
            _input = input;
        }

        public GenericNumericConversionsStandard<byte> Byte
        {
            get { return new GenericNumericConversionsStandard<byte>(_input, byte.Parse, byte.Parse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsStandard<short> Int16
        {
            get { return new GenericNumericConversionsStandard<short>(_input, short.Parse, short.Parse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsStandard<int> Int32
        {
            get { return new GenericNumericConversionsStandard<int>(_input, int.Parse, int.Parse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsStandard<long> Int64
        {
            get { return new GenericNumericConversionsStandard<long>(_input, long.Parse, long.Parse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsStandard<sbyte> SByte
        {
            get { return new GenericNumericConversionsStandard<sbyte>(_input, sbyte.Parse, sbyte.Parse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsStandard<ushort> UInt16
        {
            get { return new GenericNumericConversionsStandard<ushort>(_input, ushort.Parse, ushort.Parse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsStandard<uint> UInt32
        {
            get { return new GenericNumericConversionsStandard<uint>(_input, uint.Parse, uint.Parse, NumberStyles.Integer); }
        }

        [CLSCompliant(false)]
        public GenericNumericConversionsStandard<ulong> UInt64
        {
            get { return new GenericNumericConversionsStandard<ulong>(_input, ulong.Parse, ulong.Parse, NumberStyles.Integer); }
        }

        public GenericNumericConversionsStandard<float> Single
        {
            get { return new GenericNumericConversionsStandard<float>(_input, float.Parse, float.Parse, NumberStyles.Float | NumberStyles.AllowThousands); }
        }

        public GenericNumericConversionsStandard<double> Double
        {
            get
            {
                return new GenericNumericConversionsStandard<double>(
                    _input, double.Parse, double.Parse, NumberStyles.Float | NumberStyles.AllowThousands);
            }
        }

        public GenericNumericConversionsStandard<decimal> Decimal
        {
            get { return new GenericNumericConversionsStandard<decimal>(_input, decimal.Parse, decimal.Parse, NumberStyles.Number); }
        }

        public CurrencyConversionsStandard Currency
        {
            get { return new CurrencyConversionsStandard(_input); }
        }

        public CharConversionsStandard Char
        {
            get { return new CharConversionsStandard(_input); }
        }

        public BoolConversionsStandard Bool
        {
            get { return new BoolConversionsStandard(_input); }
        }

        public GuidConversionsStandard Guid
        {
            get { return new GuidConversionsStandard(_input); }
        }

        public EnumConversionsStandard Enum
        {
            get { return new EnumConversionsStandard(_input); }
        }

        public DateTimeConversionsStandard DateTime
        {
            get { return new DateTimeConversionsStandard(_input); }
        }

        public DateTimeOffsetConversionsStandard DateTimeOffset
        {
            get { return new DateTimeOffsetConversionsStandard(_input); }
        }
    }
}
