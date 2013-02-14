// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericNumericConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;
    using FluentConversions.ConversionDelegates;

    public class GenericNumericConversionsStandard<T>
    {
        private readonly string _input;

        private readonly GenericParseNumeric<T> _parseNumericMethod;

        private readonly GenericParseNumericCulture<T> _parseNumericCultureMethod;

        private readonly NumberStyles _defaultStyles;

        internal GenericNumericConversionsStandard(
            string input, GenericParseNumeric<T> parseNumericMethod, GenericParseNumericCulture<T> parseNumericCultureMethod, NumberStyles defaultStyles)
        {
            _input = input;
            _parseNumericMethod = parseNumericMethod;
            _parseNumericCultureMethod = parseNumericCultureMethod;
            _defaultStyles = defaultStyles;
        }

        public T Parse()
        {
            return Parse(CultureInfo.CurrentCulture, _defaultStyles);
        }

        public T Parse(NumberStyles style)
        {
            return GenericNumericStringParser.ParseNumeric(_input, style, _parseNumericMethod);
        }

        public T Parse(IFormatProvider provider)
        {
            return Parse(provider, _defaultStyles);
        }

        public T Parse(IFormatProvider provider, NumberStyles style)
        {
            return GenericNumericStringParser.ParseNumericCulture(_input, style, provider, _parseNumericCultureMethod);
        }

        public T ParseInvariant()
        {
            return ParseInvariant(_defaultStyles);
        }

        public T ParseInvariant(NumberStyles style)
        {
            return Parse(CultureInfo.InvariantCulture, style);
        }

        public T ParseCulture()
        {
            return ParseCulture(_defaultStyles);
        }

        public T ParseCulture(NumberStyles style)
        {
            return Parse(CultureInfo.CurrentCulture, style);
        }
    }
}
