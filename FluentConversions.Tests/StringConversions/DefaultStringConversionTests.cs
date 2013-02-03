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
            public void LowestBoundPasses()
            {
                var lowestBoundString = byte.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Byte();

                result.Should().Be(byte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = byte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().ByteInvariant();

                result.Should().Be(byte.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)byte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const byte DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().Byte(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const byte DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().ByteInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "AB";

                var result = HexString.ConvertWithDefaultTo().ByteInvariant(NumberStyles.HexNumber);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertWithDefaultTo().Byte(NumberStyles.Integer);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().ByteCulture();

                    result.Should().Be(171);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().ByteCulture(NumberStyles.Integer);

                    result.Should().Be(171);
                }
            }
        }

        public class DecimalTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = decimal.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Decimal();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = decimal.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().DecimalInvariant();

                result.Should().Be(decimal.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";
                const decimal DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Decimal(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const decimal DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().DecimalInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertWithDefaultTo().DecimalInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertWithDefaultTo().Decimal(NumberStyles.Number);

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().DecimalCulture();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().DecimalCulture(NumberStyles.Number);

                    result.Should().Be(1234.567m);
                }
            }
        }

        public class DoubleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = (-1e300).ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Double();

                AlmostEqual2SComplement(result, -1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = 1e300.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().DoubleInvariant();

                AlmostEqual2SComplement(result, 1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "1.7E309";
                const double DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Double(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const double DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().DoubleInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertWithDefaultTo().DoubleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertWithDefaultTo().Double(NumberStyles.Number);

                result.Should().Be(1234.567);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().DoubleCulture();

                    result.Should().Be(1234.567);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().DoubleCulture(NumberStyles.Number);

                    result.Should().Be(1234.567);
                }
            }

            private static bool AlmostEqual2SComplement(double first, double second, int maxDeltaBits)
            {
                var firstAsInt = BitConverter.ToInt32(BitConverter.GetBytes(first), 0);
                if (firstAsInt < 0)
                    firstAsInt = int.MinValue - firstAsInt;

                var secondAsInt = BitConverter.ToInt32(BitConverter.GetBytes(second), 0);
                if (secondAsInt < 0)
                    secondAsInt = int.MinValue - secondAsInt;

                var intDiff = Math.Abs(firstAsInt - secondAsInt);
                return intDiff <= (1 << maxDeltaBits);
            }
        }

        public class Int16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = short.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int16();

                result.Should().Be(short.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = short.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int16Invariant();

                result.Should().Be(short.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)short.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const short DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().Int16(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const short DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().Int16Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().Int16Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Int16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int16Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }

        public class Int32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = int.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int32();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int32Invariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const int DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().Int32(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const int DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().Int32Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().Int32Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Int32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int32Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertWithDefaultTo().Int64();

                result.Should().Be(long.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = long.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Int64Invariant();

                result.Should().Be(long.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "9223372036854775808";
                const long DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Int64(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const long DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().Int64Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().Int64Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Int64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int64Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().Int64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }

        public class SByteTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = sbyte.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().SByte();

                result.Should().Be(sbyte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = sbyte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().SByteInvariant();

                result.Should().Be(sbyte.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)sbyte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const sbyte DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().SByte(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const sbyte DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().SByteInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "7F";

                var result = HexString.ConvertWithDefaultTo().SByteInvariant(NumberStyles.HexNumber);

                result.Should().Be(127);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertWithDefaultTo().SByte(NumberStyles.Integer);

                result.Should().Be(127);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().SByteCulture();

                    result.Should().Be(127);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().SByteCulture(NumberStyles.Integer);

                    result.Should().Be(127);
                }
            }
        }

        public class SingleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = float.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().Single();

                AlmostEqual2SComplement(result, float.MinValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().SingleInvariant();

                AlmostEqual2SComplement(result, float.MaxValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "3.4e39";
                const float DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().Single(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const float DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().SingleInvariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertWithDefaultTo().SingleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().Single(NumberStyles.Number);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().SingleCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().SingleCulture(NumberStyles.Number);

                    result.Should().Be(1234);
                }
            }

            private static bool AlmostEqual2SComplement(float first, float second, int maxDeltaBits)
            {
                var firstAsInt = BitConverter.ToInt32(BitConverter.GetBytes(first), 0);
                if (firstAsInt < 0)
                    firstAsInt = int.MinValue - firstAsInt;

                var secondAsInt = BitConverter.ToInt32(BitConverter.GetBytes(second), 0);
                if (secondAsInt < 0)
                    secondAsInt = int.MinValue - secondAsInt;

                var intDiff = Math.Abs(firstAsInt - secondAsInt);
                return intDiff <= (1 << maxDeltaBits);
            }
        }

        public class UInt16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ushort.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt16();

                result.Should().Be(ushort.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ushort.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt16Invariant();

                result.Should().Be(ushort.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)ushort.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const ushort DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().UInt16(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const ushort DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().UInt16Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().UInt16Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().UInt16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt16Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }

        public class UInt32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = uint.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt32();

                result.Should().Be(uint.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = uint.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt32Invariant();

                result.Should().Be(uint.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                var outOfBoundString = ((long)uint.MaxValue + 1).ToString(CultureInfo.InvariantCulture);
                const uint DefaultValue = 5;

                var result = outOfBoundString.ConvertWithDefaultTo().UInt32(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const uint DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().UInt32Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().UInt32Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().UInt32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt32Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }

        public class UInt64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ulong.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt64();

                result.Should().Be(ulong.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ulong.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertWithDefaultTo().UInt64Invariant();

                result.Should().Be(ulong.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsDefault()
            {
                const string OutOfBoundString = "18446744073709551616";
                const ulong DefaultValue = 5;

                var result = OutOfBoundString.ConvertWithDefaultTo().UInt64(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void NonnumericStringReturnsDefault()
            {
                const string NonnumericString = "ABC";
                const ulong DefaultValue = 5;

                var result = NonnumericString.ConvertWithDefaultTo().UInt64Invariant(DefaultValue);

                result.Should().Be(DefaultValue);
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertWithDefaultTo().UInt64Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertWithDefaultTo().UInt64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt64Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertWithDefaultTo().UInt64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }
    }
}
