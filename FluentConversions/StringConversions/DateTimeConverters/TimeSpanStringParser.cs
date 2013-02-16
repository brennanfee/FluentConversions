// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanStringParser.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    internal static class TimeSpanStringParser
    {
        public static TimeSpan? TryParseNullable(string value, IFormatProvider provider)
        {
            TimeSpan result;
            if (!TimeSpan.TryParse(value, provider, out result))
                return null;

            return result;
        }

        public static TimeSpan? TryParseExactNullable(string value, string format, IFormatProvider provider, TimeSpanStyles styles)
        {
            TimeSpan result;
            if (!TimeSpan.TryParseExact(value, format, provider, styles, out result))
                return null;

            return result;
        }

        public static TimeSpan? TryParseExactNullable(string value, IEnumerable<string> formats, IFormatProvider provider, TimeSpanStyles styles)
        {
            TimeSpan result;
            if (!TimeSpan.TryParseExact(value, formats.ToArray(), provider, styles, out result))
                return null;

            return result;
        }

        public static TimeSpan TryParseDefault(string value, IFormatProvider provider, TimeSpan defaultValue)
        {
            TimeSpan result;
            return !TimeSpan.TryParse(value, provider, out result) ? defaultValue : result;
        }

        public static TimeSpan TryParseExactDefault(string value, string format, IFormatProvider provider, TimeSpanStyles styles, TimeSpan defaultValue)
        {
            TimeSpan result;
            return !TimeSpan.TryParseExact(value, format, provider, styles, out result) ? defaultValue : result;
        }

        public static TimeSpan TryParseExactDefault(string value, IEnumerable<string> formats, IFormatProvider provider, TimeSpanStyles styles, TimeSpan defaultValue)
        {
            TimeSpan result;
            return !TimeSpan.TryParseExact(value, formats.ToArray(), provider, styles, out result) ? defaultValue : result;
        }
    }
}
