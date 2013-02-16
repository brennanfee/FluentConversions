// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;

    public class CurrencyConversionsDefault
    {
        private readonly GenericNumericConversionsDefault<decimal> _converter;

        internal CurrencyConversionsDefault(string input)
        {
            _converter = new GenericNumericConversionsDefault<decimal>(input, decimal.TryParse, decimal.TryParse, NumberStyles.Currency);
        }

        public decimal Parse(decimal defaultValue = default(decimal), bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, defaultValue, round);
        }

        public decimal Parse(IFormatProvider provider, decimal defaultValue = default(decimal), bool round = false)
        {
            var result = _converter.Parse(provider, defaultValue);

            if (round)
            {
                provider = provider ?? CultureInfo.CurrentCulture;
                var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
                return Math.Round(result, numberFormat.CurrencyDecimalDigits);
            }

            return result;
        }

        public decimal ParseInvariant(decimal defaultValue = default(decimal), bool round = false)
        {
            return Parse(CultureInfo.InvariantCulture, defaultValue, round);
        }

        public decimal ParseCulture(decimal defaultValue = default(decimal), bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, defaultValue, round);
        }
    }
}
