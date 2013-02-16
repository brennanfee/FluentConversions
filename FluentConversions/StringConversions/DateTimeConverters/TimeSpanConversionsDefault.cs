// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    public class TimeSpanConversionsDefault
    {
        private readonly string _input;

        internal TimeSpanConversionsDefault(string input)
        {
            _input = input;
        }

        public TimeSpan Parse(TimeSpan defaultValue = default(TimeSpan))
        {
            return Parse(CultureInfo.CurrentCulture, defaultValue);
        }

        public TimeSpan Parse(IFormatProvider provider, TimeSpan defaultValue = default(TimeSpan))
        {
            return TimeSpanStringParser.TryParseDefault(_input, provider, defaultValue);
        }

        public TimeSpan ParseExact(string format, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(format, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExact(string format, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public TimeSpan ParseExact(string format, IFormatProvider provider, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(format, provider, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExact(string format, IFormatProvider provider, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return TimeSpanStringParser.TryParseExactDefault(_input, format, provider, styles, defaultValue);
        }

        public TimeSpan ParseExact(IEnumerable<string> formats, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(formats, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExact(IEnumerable<string> formats, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public TimeSpan ParseExact(IEnumerable<string> formats, IFormatProvider provider, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(formats, provider, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExact(IEnumerable<string> formats, IFormatProvider provider, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return TimeSpanStringParser.TryParseExactDefault(_input, formats, provider, styles, defaultValue);
        }

        public TimeSpan ParseCulture(TimeSpan defaultValue = default(TimeSpan))
        {
            return Parse(CultureInfo.CurrentCulture, defaultValue);
        }

        public TimeSpan ParseExactCulture(string format, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExactCulture(format, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExactCulture(string format, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public TimeSpan ParseExactCulture(IEnumerable<string> formats, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExactCulture(formats, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExactCulture(IEnumerable<string> formats, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles, defaultValue);
        }

        public TimeSpan ParseInvariant(TimeSpan defaultValue = default(TimeSpan))
        {
            return Parse(CultureInfo.InvariantCulture, defaultValue);
        }

        public TimeSpan ParseExactInvariant(string format, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExactInvariant(format, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExactInvariant(string format, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles, defaultValue);
        }

        public TimeSpan ParseExactInvariant(IEnumerable<string> formats, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExactInvariant(formats, TimeSpanStyles.None, defaultValue);
        }

        public TimeSpan ParseExactInvariant(IEnumerable<string> formats, TimeSpanStyles styles, TimeSpan defaultValue = default(TimeSpan))
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles, defaultValue);
        }
    }
}
