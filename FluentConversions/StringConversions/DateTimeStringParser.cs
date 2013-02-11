// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeStringParser.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions
{
    using System.Collections.Generic;
    using System.Globalization;

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
    }
}
