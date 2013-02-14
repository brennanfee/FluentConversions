// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultStringConversionTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests.StringConversions
{
    using System.Globalization;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class DefaultStringConversionTests
    {
        public class ByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertWithDefaultTo().Byte.Parse(NumberStyles.Integer);

                result.Should().Be(171);
            }
        }

        public class Int16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = short.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int16.Parse();

                result.Should().Be(short.MinValue);
            }
        }

        public class Int32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = int.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int32.Parse();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int32.ParseInvariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const int DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().Int32.Parse(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "XYZ";
                const int DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().Int32.ParseInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().Int32.ParseInvariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Int32.Parse(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Int32.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Int32.ParseCulture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }

        public class Int64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = long.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int64.Parse();

                result.Should().Be(long.MinValue);
            }
        }

        public class SByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertWithDefaultTo().SByte.Parse(NumberStyles.Integer);

                result.Should().Be(127);
            }
        }

        public class UInt16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ushort.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt16.Parse();

                result.Should().Be(ushort.MinValue);
            }
        }

        public class UInt32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = uint.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt32.Parse();

                result.Should().Be(uint.MinValue);
            }
        }

        public class UInt64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ulong.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt64.Parse();

                result.Should().Be(ulong.MinValue);
            }
        }

        public class SingleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = float.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Single.Parse();

                FloatAssertions.AlmostEqual(result, float.MinValue).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Single.ParseInvariant();

                FloatAssertions.AlmostEqual(result, float.MaxValue).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "3.4e39";
                const float DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Single.Parse(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "XYZ";
                const float DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().Single.ParseInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertWithDefaultTo().Single.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Single.Parse();

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Single.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Single.ParseCulture(NumberStyles.Number);

                    result.Should().Be(1234);
                }
            }
        }

        public class DoubleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = (-1e300).ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Double.Parse();

                FloatAssertions.AlmostEqual(result, -1e300).Should().BeTrue();
            }
        }

        public class DecimalTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = decimal.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Decimal.Parse();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";
                const decimal DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Decimal.Parse(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertWithDefaultTo().Decimal.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertWithDefaultTo().Decimal.Parse();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Decimal.ParseCulture(NumberStyles.Number & ~NumberStyles.AllowThousands);

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertWithDefaultTo().Decimal.ParseCulture();

                    result.Should().Be(1234.567m);
                }
            }
        }

        public class CurrencyTests
        {
            [Fact]
            public void BaseUsesCurrentCulture()
            {
                const string Number = "1 234,567 kr";

                using (new CultureInfoScope("sv-SE"))
                {
                    var result = Number.ConvertWithDefaultTo().Currency.Parse();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void BaseInvalidInputReturnsDefault()
            {
                var result = string.Empty.ConvertWithDefaultTo().Currency.Parse(10);
                result.Should().Be(10);
            }

            [Fact]
            public void BaseRoundsToCultureLength()
            {
                const string Number = "1 234,567 kr";

                using (new CultureInfoScope("sv-SE"))
                {
                    var result = Number.ConvertWithDefaultTo().Currency.Parse(0, true);

                    result.Should().Be(1234.57m);
                }
            }

            [Fact]
            public void PassedCulturePasses()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertWithDefaultTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"));

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void PassedCultureInvalidInputReturnsDefault()
            {
                var result = string.Empty.ConvertWithDefaultTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"), 10);
                result.Should().Be(10);
            }

            [Fact]
            public void PassedCultureRounds()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertWithDefaultTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"), 0, true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void InvariantPasses()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertWithDefaultTo().Currency.ParseInvariant();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void InvariantInvalidInputReturnsDefault()
            {
                var result = string.Empty.ConvertWithDefaultTo().Currency.ParseInvariant(10);
                result.Should().Be(10);
            }

            [Fact]
            public void InvariantRounds()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertWithDefaultTo().Currency.ParseInvariant(0, true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void CulturePasses()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertWithDefaultTo().Currency.ParseCulture();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void CultureInvalidInputReturnsDefault()
            {
                var result = string.Empty.ConvertWithDefaultTo().Currency.ParseCulture(10);
                result.Should().Be(10);
            }

            [Fact]
            public void CultureRounds()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertWithDefaultTo().Currency.ParseCulture(0, true);

                    result.Should().Be(1234.57m);
                }
            }
        }
    }
}
