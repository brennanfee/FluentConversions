// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableStringConversionTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests.StringConversions
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class NullableStringConversionTests
    {
        public class ByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertToNullable().Byte.Parse(NumberStyles.Integer);

                result.Should().Be(171);
            }
        }

        public class Int16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = short.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int16.Parse();

                result.Should().Be(short.MinValue);
            }
        }

        public class Int32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = int.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int32.Parse();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int32.ParseInvariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().Int32.Parse();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "XYZ";

                var result = NonnumericString.ConvertToNullable().Int32.ParseInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().Int32.ParseInvariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Int32.Parse(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Int32.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Int32.ParseCulture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertToNullable().Int64.Parse();

                result.Should().Be(long.MinValue);
            }
        }

        public class SByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertToNullable().SByte.Parse(NumberStyles.Integer);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(127);
            }
        }

        public class UInt16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ushort.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt16.Parse();

                result.Should().Be(ushort.MinValue);
            }
        }

        public class UInt32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = uint.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt32.Parse();

                result.Should().Be(uint.MinValue);
            }
        }

        public class UInt64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ulong.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt64.Parse();

                result.Should().Be(ulong.MinValue);
            }
        }

        public class SingleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = float.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Single.Parse();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                FloatAssertions.AlmostEqual(result.Value, float.MinValue).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Single.ParseInvariant();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                FloatAssertions.AlmostEqual(result.Value, float.MaxValue).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "3.4e39";

                var result = OutOfBoundString.ConvertToNullable().Single.Parse();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "XYZ";

                var result = NonnumericString.ConvertToNullable().Single.ParseInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertToNullable().Single.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Single.Parse();

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Single.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Single.ParseCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertToNullable().Double.Parse();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                FloatAssertions.AlmostEqual(result.Value, -1e300).Should().BeTrue();
            }
        }

        public class DecimalTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = decimal.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Decimal.Parse();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";

                var result = OutOfBoundString.ConvertToNullable().Decimal.Parse();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertToNullable().Decimal.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertToNullable().Decimal.Parse();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Decimal.ParseCulture(NumberStyles.Number & ~NumberStyles.AllowThousands);

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertToNullable().Decimal.ParseCulture();

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
                    var result = Number.ConvertToNullable().Currency.Parse();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void BaseInvalidInputReturnsNull()
            {
                var result = string.Empty.ConvertToNullable().Currency.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void BaseRoundsToCultureLength()
            {
                const string Number = "1 234,567 kr";

                using (new CultureInfoScope("sv-SE"))
                {
                    var result = Number.ConvertToNullable().Currency.Parse(true);

                    result.Should().Be(1234.57m);
                }
            }

            [Fact]
            public void PassedCulturePasses()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertToNullable().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"));

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void PassedCultureInvalidInputReturnsNull()
            {
                var result = string.Empty.ConvertToNullable().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"));
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void PassedCultureRounds()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertToNullable().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"), true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void InvariantPasses()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertToNullable().Currency.ParseInvariant();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void InvariantInvalidInputReturnsNull()
            {
                var result = string.Empty.ConvertToNullable().Currency.ParseInvariant();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void InvariantRounds()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertToNullable().Currency.ParseInvariant(true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void CulturePasses()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertToNullable().Currency.ParseCulture();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void CultureInvalidInputReturnsNull()
            {
                var result = string.Empty.ConvertToNullable().Currency.ParseCulture();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void CultureRounds()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertToNullable().Currency.ParseCulture(true);

                    result.Should().Be(1234.57m);
                }
            }
        }
    }
}
