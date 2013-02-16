// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeStringParserTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.Tests.StringConversions.DateTimeConverters
{
    using System.Globalization;
    using FluentAssertions;
    using FluentConversions.StringConversions.DateTimeConverters;
    using Xunit;

    public class DateTimeStringParserTests
    {
        [Fact]
        public void InvalidMatchInDateTimeTryParseExactNullableMultipleFormatsReturnsNull()
        {
            var result = DateTimeStringParser.DateTimeTryParseExactNullable("ABC", new[] { "s", "o" }, new CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces);
            result.HasValue.Should().BeFalse();
        }

        [Fact]
        public void InvalidMatchInDateTimeOffsetTryParseExactNullableMultipleFormatsReturnsNull()
        {
            var result = DateTimeStringParser.DateTimeOffsetTryParseExactNullable("ABC", new[] { "s", "o" }, new CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces);
            result.HasValue.Should().BeFalse();
        }
    }
}
