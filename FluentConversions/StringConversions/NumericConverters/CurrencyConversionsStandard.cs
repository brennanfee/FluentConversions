// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;

    public class CurrencyConversionsStandard
    {
        private readonly GenericNumericConversionsStandard<decimal> _converter;

        internal CurrencyConversionsStandard(string input)
        {
            _converter = new GenericNumericConversionsStandard<decimal>(input, decimal.Parse, decimal.Parse, NumberStyles.Currency);
        }

        public decimal Parse(bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, round);
        }

        public decimal Parse(IFormatProvider provider, bool round = false)
        {
            var result = _converter.Parse(provider);

            if (round)
            {
                provider = provider ?? CultureInfo.CurrentCulture;
                var numberFormat = (NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo)) ?? CultureInfo.CurrentCulture.NumberFormat;
                return Math.Round(result, numberFormat.CurrencyDecimalDigits);
            }

            return result;
        }

        public decimal ParseInvariant(bool round = false)
        {
            return Parse(CultureInfo.InvariantCulture, round);
        }

        public decimal ParseCulture(bool round = false)
        {
            return Parse(CultureInfo.CurrentCulture, round);
        }
    }
}
