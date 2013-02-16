// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    public class DateTimeConversionsDefault
    {
        private readonly string _input;

        internal DateTimeConversionsDefault(string input)
        {
            _input = input;
        }

        public DateTime Parse(DateTime defaultValue = default(DateTime))
        {
            return Parse(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime Parse(DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return Parse(CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime Parse(IFormatProvider provider, DateTime defaultValue = default(DateTime))
        {
            return Parse(provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime Parse(IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return DateTimeStringParser.DateTimeTryParseDefault(_input, provider, styles, defaultValue);
        }

        public DateTime ParseExact(string format, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExact(string format, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime ParseExact(IEnumerable<string> formats, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExact(IEnumerable<string> formats, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime ParseExact(string format, IFormatProvider provider, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(format, provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExact(string format, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return DateTimeStringParser.DateTimeTryParseExactDefault(_input, format, provider, styles, defaultValue);
        }

        public DateTime ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(formats, provider, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return DateTimeStringParser.DateTimeTryParseExactDefault(_input, formats, provider, styles, defaultValue);
        }

        public DateTime ParseCulture(DateTime defaultValue = default(DateTime))
        {
            return ParseCulture(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseCulture(DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return Parse(CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime ParseExactCulture(string format, DateTime defaultValue = default(DateTime))
        {
            return ParseExactCulture(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExactCulture(string format, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime ParseExactCulture(IEnumerable<string> formats, DateTime defaultValue = default(DateTime))
        {
            return ParseExactCulture(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExactCulture(IEnumerable<string> formats, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public DateTime ParseInvariant(DateTime defaultValue = default(DateTime))
        {
            return ParseInvariant(DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseInvariant(DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return Parse(CultureInfo.InvariantCulture, styles, defaultValue);
        }

        public DateTime ParseExactInvariant(string format, DateTime defaultValue = default(DateTime))
        {
            return ParseExactInvariant(format, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExactInvariant(string format, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles, defaultValue);
        }

        public DateTime ParseExactInvariant(IEnumerable<string> formats, DateTime defaultValue = default(DateTime))
        {
            return ParseExactInvariant(formats, DateTimeStyles.AllowWhiteSpaces, defaultValue);
        }

        public DateTime ParseExactInvariant(IEnumerable<string> formats, DateTimeStyles styles, DateTime defaultValue = default(DateTime))
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles, defaultValue);
        }
    }
}
