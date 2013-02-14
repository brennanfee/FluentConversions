// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericStringParserTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests.StringConversions
{
    using System.Globalization;
    using System.Linq;
    using FluentAssertions;
    using FluentConversions.StringConversions.NumericConverters;
    using FluentConversions.StringConversions.OtherConverters;
    using Xunit;

    public class GenericStringParserTests
    {
        [Fact]
        public void PassingValidValuesToParsePasses()
        {
            var result = GenericStringParser.Parse("10", int.Parse);
            result.Should().Be(10);
        }

        [Fact]
        public void PassingValidValuesToParseCulturePasses()
        {
            var result = GenericStringParser.ParseCulture("10", CultureInfo.InvariantCulture, int.Parse);
            result.Should().Be(10);
        }

        [Fact]
        public void PassingValidValuesToTryParseNullablePasses()
        {
            var result = GenericStringParser.TryParseNullable<int>("10", int.TryParse);
            result.Should().Be(10);
        }

        [Fact]
        public void PassingInvalidValuesToTryParseNullableReturnsNull()
        {
            var result = GenericStringParser.TryParseNullable<int>("ABC", int.TryParse);
            result.Should().Be(null);
        }

        [Fact]
        public void PassingNullMethodToParseThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.Parse<int>(null, null));
        }

        [Fact]
        public void PassingNullMethodToParseCultureThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.ParseCulture<int>(null, null, null));
        }

        [Fact]
        public void PassingNullMethodToParseNumericThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericNumericStringParser.ParseNumeric<int>(null, NumberStyles.Integer, null));
        }

        [Fact]
        public void PassingNullMethodToParseNumericCultureThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericNumericStringParser.ParseNumericCulture<int>(null, NumberStyles.Integer, null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseNullableThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseNullable<int>(null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseNullableNumericThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericNumericStringParser.TryParseNullableNumeric<int>(null, NumberStyles.Integer, null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseDefaultThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseDefault(null, 0, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseDefaultNumericThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericNumericStringParser.TryParseDefaultNumeric(null, NumberStyles.Integer, null, 0, null));
        }
    }
}
