// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeStringParser.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal static class DateTimeStringParser
    {
        public static DateTime? DateTimeTryParseNullable(string value, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime result;
            if (!DateTime.TryParse(value, provider, styles, out result))
                return null;

            return result;
        }

        public static DateTime? DateTimeTryParseExactNullable(string value, string format, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime result;
            if (!DateTime.TryParseExact(value, format, provider, styles, out result))
                return null;

            return result;
        }

        public static DateTime? DateTimeTryParseExactNullable(
            string value, IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime result;
            if (!DateTime.TryParseExact(value, formats.ToArray(), provider, styles, out result))
                return null;

            return result;
        }

        public static DateTime DateTimeTryParseDefault(string value, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)
        {
            DateTime result;
            return !DateTime.TryParse(value, provider, styles, out result) ? defaultValue : result;
        }

        public static DateTime DateTimeTryParseExactDefault(
            string value, string format, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)
        {
            DateTime result;
            return !DateTime.TryParseExact(value, format, provider, styles, out result) ? defaultValue : result;
        }

        public static DateTime DateTimeTryParseExactDefault(
            string value, IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue)
        {
            DateTime result;
            return !DateTime.TryParseExact(value, formats.ToArray(), provider, styles, out result) ? defaultValue : result;
        }

        public static DateTimeOffset? DateTimeOffsetTryParseNullable(string value, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTimeOffset result;
            if (!DateTimeOffset.TryParse(value, provider, styles, out result))
                return null;

            return result;
        }

        public static DateTimeOffset? DateTimeOffsetTryParseExactNullable(string value, string format, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTimeOffset result;
            if (!DateTimeOffset.TryParseExact(value, format, provider, styles, out result))
                return null;

            return result;
        }

        public static DateTimeOffset? DateTimeOffsetTryParseExactNullable(
            string value, IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTimeOffset result;
            if (!DateTimeOffset.TryParseExact(value, formats.ToArray(), provider, styles, out result))
                return null;

            return result;
        }

        public static DateTimeOffset DateTimeOffsetTryParseDefault(
            string value, IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue)
        {
            DateTimeOffset result;
            return !DateTimeOffset.TryParse(value, provider, styles, out result) ? defaultValue : result;
        }

        public static DateTimeOffset DateTimeOffsetTryParseExactDefault(
            string value, string format, IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue)
        {
            DateTimeOffset result;
            return !DateTimeOffset.TryParseExact(value, format, provider, styles, out result) ? defaultValue : result;
        }

        public static DateTimeOffset DateTimeOffsetTryParseExactDefault(
            string value, IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue)
        {
            DateTimeOffset result;
            return !DateTimeOffset.TryParseExact(value, formats.ToArray(), provider, styles, out result) ? defaultValue : result;
        }
    }
}
