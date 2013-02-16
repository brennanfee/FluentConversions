// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.DateTimeConverters
{
    using System.Collections.Generic;
    using System.Globalization;

    public class TimeSpanConversionsNullable
    {
        private readonly string _input;

        internal TimeSpanConversionsNullable(string input)
        {
            _input = input;
        }

        public TimeSpan? Parse()
        {
            return Parse(CultureInfo.CurrentCulture);
        }

        public TimeSpan? Parse(IFormatProvider provider)
        {
            return TimeSpanStringParser.TryParseNullable(_input, provider);
        }

        public TimeSpan? ParseExact(string format, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public TimeSpan? ParseExact(string format, IFormatProvider provider, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return TimeSpanStringParser.TryParseExactNullable(_input, format, provider, styles);
        }

        public TimeSpan? ParseExact(IEnumerable<string> formats, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public TimeSpan? ParseExact(IEnumerable<string> formats, IFormatProvider provider, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return TimeSpanStringParser.TryParseExactNullable(_input, formats, provider, styles);
        }

        public TimeSpan? ParseCulture()
        {
            return Parse(CultureInfo.CurrentCulture);
        }

        public TimeSpan? ParseExactCulture(string format, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(format, CultureInfo.CurrentCulture, styles);
        }

        public TimeSpan? ParseExactCulture(IEnumerable<string> formats, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(formats, CultureInfo.CurrentCulture, styles);
        }

        public TimeSpan? ParseInvariant()
        {
            return Parse(CultureInfo.InvariantCulture);
        }

        public TimeSpan? ParseExactInvariant(string format, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(format, CultureInfo.InvariantCulture, styles);
        }

        public TimeSpan? ParseExactInvariant(IEnumerable<string> formats, TimeSpanStyles styles = TimeSpanStyles.None)
        {
            return ParseExact(formats, CultureInfo.InvariantCulture, styles);
        }
    }
}
