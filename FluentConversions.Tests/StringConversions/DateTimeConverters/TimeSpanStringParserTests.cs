// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanStringParserTests.cs" company="Brennan A. Fee">
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

    public class TimeSpanStringParserTests
    {
        [Fact]
        public void InvalidTryParseExactNullableWithMultipleFormatsReturnsNull()
        {
            var result = TimeSpanStringParser.TryParseExactNullable("ABC", new[] { "g", "G" }, new CultureInfo("en-US"), TimeSpanStyles.None);
            result.HasValue.Should().BeFalse();
        }
    }
}
