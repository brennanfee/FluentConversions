// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericNumericConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;
    using FluentConversions.ConversionDelegates;

    public class GenericNumericConversionsNullable<T> where T : struct
    {
        private readonly string _input;

        private readonly GenericTryParseNumeric<T> _tryParseMethod;

        private readonly NumberStyles _defaultStyles;

        internal GenericNumericConversionsNullable(string input, GenericTryParseNumeric<T> tryParseMethod, NumberStyles defaultStyles)
        {
            _input = input;
            _tryParseMethod = tryParseMethod;
            _defaultStyles = defaultStyles;
        }

        public T? Parse()
        {
            return Parse(CultureInfo.CurrentCulture, _defaultStyles);
        }

        public T? Parse(NumberStyles style)
        {
            return Parse(CultureInfo.CurrentCulture, style);
        }

        public T? Parse(IFormatProvider provider)
        {
            return Parse(provider, _defaultStyles);
        }

        public T? Parse(IFormatProvider provider, NumberStyles style)
        {
            return GenericNumericStringParser.TryParseNullableNumeric(_input, style, provider, _tryParseMethod);
        }

        public T? ParseInvariant()
        {
            return ParseInvariant(_defaultStyles);
        }

        public T? ParseInvariant(NumberStyles style)
        {
            return Parse(CultureInfo.InvariantCulture, style);
        }

        public T? ParseCulture()
        {
            return ParseCulture(_defaultStyles);
        }

        public T? ParseCulture(NumberStyles style)
        {
            return Parse(CultureInfo.CurrentCulture, style);
        }
    }
}
