// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;

    public class CurrencyConversionsNullable
    {
        private readonly GenericNumericConversionsNullable<decimal> _converter;

        internal CurrencyConversionsNullable(string input)
        {
            _converter = new GenericNumericConversionsNullable<decimal>(input, decimal.TryParse, NumberStyles.Currency);
        }

        public decimal? Parse(bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, round);
        }

        public decimal? Parse(IFormatProvider provider, bool round = false)
        {
            var result = _converter.Parse(provider);
            if (!result.HasValue)
                return null;

            if (!round)
                return result;

            provider = provider ?? CultureInfo.CurrentCulture;
            var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
            return Math.Round(result.Value, numberFormat.CurrencyDecimalDigits);
        }

        public decimal? ParseInvariant(bool round = false)
        {
            return Parse(CultureInfo.InvariantCulture, round);
        }

        public decimal? ParseCulture(bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, round);
        }
    }
}
