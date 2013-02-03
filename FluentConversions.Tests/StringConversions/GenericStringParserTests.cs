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
    using FluentConversions.StringConversions;
    using Xunit;

    public class GenericStringParserTests
    {
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
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.ParseNumeric<int>(null, NumberStyles.Integer, null));
        }

        [Fact]
        public void PassingNullMethodToParseNumericCultureThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.ParseNumericCulture<int>(null, NumberStyles.Integer, null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseNullableThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseNullable<int>(null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseNullableNumericThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseNullableNumeric<int>(null, NumberStyles.Integer, null, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseDefaultThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseDefault(null, 0, null));
        }

        [Fact]
        public void PassingNullMethodToTryParseDefaultNumericThrows()
        {
            Assert.Throws<ArgumentNullException>(() => GenericStringParser.TryParseDefaultNumeric(null, NumberStyles.Integer, null, 0, null));
        }
    }
}
