// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardStringConversionTests.cs" company="Brennan A. Fee">
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

    public static class StandardStringConversionTests
    {
        public class ByteTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = byte.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Byte();

                result.Should().Be(byte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = byte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().ByteInvariant();

                result.Should().Be(byte.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)byte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().Byte());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().ByteInvariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "AB";

                var result = HexString.ConvertTo().ByteInvariant(NumberStyles.HexNumber);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertTo().Byte(NumberStyles.Integer);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().ByteCulture();

                    result.Should().Be(171);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().ByteCulture(NumberStyles.Integer);

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

                var result = lowestBoundString.ConvertTo().Decimal();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = decimal.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().DecimalInvariant();

                result.Should().Be(decimal.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Decimal());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().DecimalInvariant());
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertTo().DecimalInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertTo().Decimal(NumberStyles.Number);

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().DecimalCulture();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().DecimalCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertTo().Double();

                AlmostEqual2SComplement(result, -1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = 1e300.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().DoubleInvariant();

                AlmostEqual2SComplement(result, 1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "1.7E309";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Double());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().DoubleInvariant());
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertTo().DoubleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertTo().Double(NumberStyles.Number);

                result.Should().Be(1234.567);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().DoubleCulture();

                    result.Should().Be(1234.567);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().DoubleCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertTo().Int16();

                result.Should().Be(short.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = short.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int16Invariant();

                result.Should().Be(short.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)short.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().Int16());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().Int16Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().Int16Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().Int16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int16Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().Int32();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int32Invariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().Int32());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().Int32Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().Int32Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().Int32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int32Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().Int64();

                result.Should().Be(long.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = long.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int64Invariant();

                result.Should().Be(long.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "9223372036854775808";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Int64());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().Int64Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().Int64Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().Int64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int64Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().Int64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().SByte();

                result.Should().Be(sbyte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = sbyte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().SByteInvariant();

                result.Should().Be(sbyte.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)sbyte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().SByte());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().SByteInvariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "7F";

                var result = HexString.ConvertTo().SByteInvariant(NumberStyles.HexNumber);

                result.Should().Be(127);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertTo().SByte(NumberStyles.Integer);

                result.Should().Be(127);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().SByteCulture();

                    result.Should().Be(127);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().SByteCulture(NumberStyles.Integer);

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

                var result = lowestBoundString.ConvertTo().Single();

                AlmostEqual2SComplement(result, float.MinValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().SingleInvariant();

                AlmostEqual2SComplement(result, float.MaxValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "3.4e39";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Single());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().SingleInvariant());
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertTo().SingleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().Single(NumberStyles.Number);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().SingleCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().SingleCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertTo().UInt16();

                result.Should().Be(ushort.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ushort.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt16Invariant();

                result.Should().Be(ushort.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)ushort.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().UInt16());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().UInt16Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().UInt16Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().UInt16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt16Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().UInt32();

                result.Should().Be(uint.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = uint.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt32Invariant();

                result.Should().Be(uint.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)uint.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().UInt32());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().UInt32Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().UInt32Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().UInt32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt32Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().UInt64();

                result.Should().Be(ulong.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ulong.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt64Invariant();

                result.Should().Be(ulong.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "18446744073709551616";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().UInt64());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "ABC";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().UInt64Invariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().UInt64Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().UInt64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt64Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertTo().UInt64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.Should().Be(1234);
                }
            }
        }
    }
}
