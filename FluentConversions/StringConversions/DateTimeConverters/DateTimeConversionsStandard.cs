// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class DateTimeConversionsStandard
    {
        private readonly string _input;

        internal DateTimeConversionsStandard(string input)
        {
            _input = input;
        }

        public DateTime Parse(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.CurrentCulture, styles);
        }

        public DateTime Parse(IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTime.Parse(_input, provider, styles);
        }

        public DateTime ParseExact(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public DateTime ParseExact(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public DateTime ParseExact(string format, IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTime.ParseExact(_input, format, provider, styles);
        }

        public DateTime ParseExact(IEnumerable<string> formats, IFormatProvider provider, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return DateTime.ParseExact(_input, formats.ToArray(), provider, styles);
        }

        public DateTime ParseCulture(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.CurrentCulture, styles);
        }

        public DateTime ParseExactCulture(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public DateTime ParseExactCulture(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public DateTime ParseInvariant(DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return Parse(CultureInfo.InvariantCulture, styles);
        }

        public DateTime ParseExactInvariant(string format, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles);
        }

        public DateTime ParseExactInvariant(IEnumerable<string> formats, DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces)
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles);
        }
    }
}
