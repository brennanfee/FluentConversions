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
            public void LowestBoundPasses()
            {
                var lowestBoundString = byte.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Byte();

                result.Should().Be(byte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = byte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().ByteInvariant();

                result.Should().Be(byte.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)byte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().Byte();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().ByteInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "AB";

                var result = HexString.ConvertToNullable().ByteInvariant(NumberStyles.HexNumber);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertToNullable().Byte(NumberStyles.Integer);

                result.Should().Be(171);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().ByteCulture();

                    result.Should().Be(171);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "171";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().ByteCulture(NumberStyles.Integer);

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

                var result = lowestBoundString.ConvertToNullable().Decimal();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = decimal.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().DecimalInvariant();

                result.Should().Be(decimal.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";

                var result = OutOfBoundString.ConvertToNullable().Decimal();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().DecimalInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertToNullable().DecimalInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertToNullable().Decimal(NumberStyles.Number);

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().DecimalCulture();

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().DecimalCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertToNullable().Double();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                AlmostEqual2SComplement(result.Value, -1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = 1e300.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().DoubleInvariant();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                AlmostEqual2SComplement(result.Value, 1e300, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "1.7E309";

                var result = OutOfBoundString.ConvertToNullable().Double();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().DoubleInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertToNullable().DoubleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertToNullable().Double(NumberStyles.Number);

                result.Should().Be(1234.567);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().DoubleCulture();

                    result.Should().Be(1234.567);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().DoubleCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertToNullable().Int16();

                result.Should().Be(short.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = short.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int16Invariant();

                result.Should().Be(short.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)short.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().Int16();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().Int16Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().Int16Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Int16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int16Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertToNullable().Int32();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int32Invariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().Int32();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().Int32Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().Int32Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Int32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int32Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertToNullable().Int64();

                result.Should().Be(long.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = long.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Int64Invariant();

                result.Should().Be(long.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "9223372036854775808";

                var result = OutOfBoundString.ConvertToNullable().Int64();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().Int64Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().Int64Invariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Int64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int64Culture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().Int64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertToNullable().SByte();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(sbyte.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = sbyte.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().SByteInvariant();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(sbyte.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)sbyte.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().SByte();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().SByteInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "7F";

                var result = HexString.ConvertToNullable().SByteInvariant(NumberStyles.HexNumber);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(127);
            }

            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertToNullable().SByte(NumberStyles.Integer);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(127);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().SByteCulture();

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(127);
                }
            }

            [Fact]
            public void StylePassedFrenchCulturePasses()
            {
                const string Number = "127";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().SByteCulture(NumberStyles.Integer);

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(127);
                }
            }
        }

        public class SingleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = float.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().Single();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                AlmostEqual2SComplement(result.Value, float.MinValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().SingleInvariant();

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                AlmostEqual2SComplement(result.Value, float.MaxValue, 1000).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "3.4e39";

                var result = OutOfBoundString.ConvertToNullable().Single();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().SingleInvariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertToNullable().SingleInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().Single(NumberStyles.Number);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().SingleCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().SingleCulture(NumberStyles.Number);

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

                var result = lowestBoundString.ConvertToNullable().UInt16();

                result.Should().Be(ushort.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ushort.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt16Invariant();

                result.Should().Be(ushort.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)ushort.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().UInt16();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().UInt16Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().UInt16Invariant(NumberStyles.HexNumber);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().UInt16(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt16Culture();

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt16Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }
        }

        public class UInt32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = uint.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt32();

                result.Should().Be(uint.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = uint.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt32Invariant();

                result.Should().Be(uint.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                var outOfBoundString = ((long)uint.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                var result = outOfBoundString.ConvertToNullable().UInt32();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().UInt32Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().UInt32Invariant(NumberStyles.HexNumber);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().UInt32(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt32Culture();

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt32Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }
        }

        public class UInt64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ulong.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt64();

                result.Should().Be(ulong.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = ulong.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertToNullable().UInt64Invariant();

                result.Should().Be(ulong.MaxValue);
            }

            [Fact]
            public void OutOfBoundReturnsNull()
            {
                const string OutOfBoundString = "18446744073709551616";

                var result = OutOfBoundString.ConvertToNullable().UInt64();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NonnumericStringReturnsNull()
            {
                const string NonnumericString = "ABC";

                var result = NonnumericString.ConvertToNullable().UInt64Invariant();

                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertToNullable().UInt64Invariant(NumberStyles.HexNumber);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertToNullable().UInt64(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.HasValue.Should().BeTrue();
                Debug.Assert(result != null, "result != null");
                result.Value.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt64Culture();

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope(CultureInfo.GetCultureInfo("fr-FR")))
                {
                    var result = Number.ConvertToNullable().UInt64Culture(NumberStyles.Integer | NumberStyles.AllowThousands);

                    result.HasValue.Should().BeTrue();
                    Debug.Assert(result != null, "result != null");
                    result.Value.Should().Be(1234);
                }
            }
        }
    }
}
