// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeOffsetConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    public class DateTimeOffsetConversionsDefault
    {
        private readonly string _input;

        internal DateTimeOffsetConversionsDefault(string input)
        {
            _input = input;
        }

        public DateTimeOffset Parse(DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return Parse(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset Parse(DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return Parse(CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset Parse(IFormatProvider provider, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return Parse(provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset Parse(IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return DateTimeStringParser.DateTimeOffsetTryParseDefault(_input, provider, styles, defaultValue);
        }

        public DateTimeOffset ParseExact(string format, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExact(string format, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExact(IEnumerable<string> formats, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExact(IEnumerable<string> formats, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExact(string format, IFormatProvider provider, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(format, provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExact(string format, IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return DateTimeStringParser.DateTimeOffsetTryParseExactDefault(_input, format, provider, styles, defaultValue);
        }

        public DateTimeOffset ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(formats, provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return DateTimeStringParser.DateTimeOffsetTryParseExactDefault(_input, formats, provider, styles, defaultValue);
        }

        public DateTimeOffset ParseCulture(DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseCulture(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseCulture(DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return Parse(CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExactCulture(string format, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExactCulture(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExactCulture(string format, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExactCulture(IEnumerable<string> formats, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExactCulture(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExactCulture(
            IEnumerable<string> formats, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseInvariant(DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseInvariant(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseInvariant(DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return Parse(CultureInfo.InvariantCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExactInvariant(string format, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExactInvariant(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExactInvariant(string format, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles, defaultValue);
        }

        public DateTimeOffset ParseExactInvariant(IEnumerable<string> formats, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExactInvariant(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTimeOffset ParseExactInvariant(
            IEnumerable<string> formats, DateTimeStyles styles, DateTimeOffset defaultValue = default(DateTimeOffset))
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles, defaultValue);
        }
    }
}
