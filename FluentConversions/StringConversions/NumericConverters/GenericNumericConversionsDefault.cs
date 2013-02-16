// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericNumericConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;
    using FluentConversions.ConversionDelegates;
    using FluentConversions.StringConversions.OtherConverters;

    public class GenericNumericConversionsDefault<T>
    {
        private readonly string _input;

        private readonly GenericTryParse<T> _tryParseMethod;

        private readonly GenericTryParseNumeric<T> _tryParseNumericMethod;

        private readonly NumberStyles _defaultStyles;

        internal GenericNumericConversionsDefault(
            string input, GenericTryParse<T> tryParseMethod, GenericTryParseNumeric<T> tryParseNumericMethod, NumberStyles defaultStyles)
        {
            _input = input;
            _tryParseMethod = tryParseMethod;
            _tryParseNumericMethod = tryParseNumericMethod;
            _defaultStyles = defaultStyles;
        }

        public T Parse(T defaultValue = default(T))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, _tryParseMethod);
        }

        public T Parse(IFormatProvider provider, T defaultValue = default(T))
        {
            return Parse(provider, _defaultStyles, defaultValue);
        }

        public T Parse(NumberStyles style, T defaultValue = default(T))
        {
            return Parse(CultureInfo.CurrentCulture, style, defaultValue);
        }

        public T Parse(IFormatProvider provider, NumberStyles style, T defaultValue = default(T))
        {
            return GenericNumericStringParser.TryParseDefaultNumeric(_input, style, provider, defaultValue, _tryParseNumericMethod);
        }

        public T ParseInvariant(T defaultValue = default(T))
        {
            return Parse(CultureInfo.InvariantCulture, _defaultStyles, defaultValue);
        }

        public T ParseInvariant(NumberStyles style, T defaultValue = default(T))
        {
            return Parse(CultureInfo.InvariantCulture, style, defaultValue);
        }

        public T ParseCulture(T defaultValue = default(T))
        {
            return Parse(CultureInfo.CurrentCulture, _defaultStyles, defaultValue);
        }

        public T ParseCulture(NumberStyles style, T defaultValue = default(T))
        {
            return Parse(CultureInfo.CurrentCulture, style, defaultValue);
        }
    }
}
