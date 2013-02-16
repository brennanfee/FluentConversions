// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeOffsetConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    public class DateTimeOffsetConversionsNullable
    {
        private readonly string _input;

        internal DateTimeOffsetConversionsNullable(string input)
        {
            _input = input;
        }

        public DateTimeOffset? Parse(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? Parse(IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeOffsetTryParseNullable(_input, provider, styles);
        }

        public DateTimeOffset? ParseExact(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? ParseExact(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? ParseExact(string format, IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeOffsetTryParseExactNullable(_input, format, provider, styles);
        }

        public DateTimeOffset? ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTimeStringParser.DateTimeOffsetTryParseExactNullable(_input, formats, provider, styles);
        }

        public DateTimeOffset? ParseCulture(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? ParseExactCulture(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? ParseExactCulture(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public DateTimeOffset? ParseInvariant(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.InvariantCulture, styles);
        }

        public DateTimeOffset? ParseExactInvariant(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles);
        }

        public DateTimeOffset? ParseExactInvariant(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles);
        }
    }
}
