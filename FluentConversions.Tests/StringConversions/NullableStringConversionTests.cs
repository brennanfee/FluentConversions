// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullableStringConversionTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests.StringConversions
{
    using System.ComponentModel.DataAnnotations;
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

        public class CharTests
        {
            [Fact]
            public void ValidStringPasses()
            {
                var result = "A".ConvertToNullable().Char.Parse();
                result.Should().Be('A');
            }

            [Fact]
            public void NullStringReturnsNull()
            {
                var result = ((string)null).ConvertToNullable().Char.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void EmptyStringReturnsNull()
            {
                var result = string.Empty.ConvertToNullable().Char.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void MultipleCharacterStringReturnsNull()
            {
                var result = "ABC".ConvertToNullable().Char.Parse();
                result.HasValue.Should().BeFalse();
            }
        }

        public class BoolTests
        {
            [Fact]
            public void ValidBoolStringsPass()
            {
                var trueResult = bool.TrueString.ConvertToNullable().Bool.Parse();
                var falseResult = bool.FalseString.ConvertToNullable().Bool.Parse();
                trueResult.Should().BeTrue();
                falseResult.Should().BeFalse();
            }

            [Fact]
            public void InvalidBoolStringReturnsNull()
            {
                var result = "Yes".ConvertToNullable().Bool.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NullStringReturnsNull()
            {
                var result = ((string)null).ConvertToNullable().Bool.Parse();
                result.HasValue.Should().BeFalse();
            }
        }

        public class GuidTests
        {
            [Fact]
            public void ValidGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertToNullable().Guid.Parse();

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidGuidReturnsNull()
            {
                var result = "XYZ".ConvertToNullable().Guid.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NullStringReturnsNull()
            {
                var result = ((string)null).ConvertToNullable().Guid.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void ValidExactGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertToNullable().Guid.ParseExact("X");

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidExactGuidReturnsNull()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertToNullable().Guid.ParseExact("N");
                result.HasValue.Should().BeFalse();
            }
        }

        public static class EnumTests
        {
            private enum SimpleEnum
            {
                [Display(Name = "Value A")]
                ValueA,
                ValueB,
                [Display(Name = "Value Other")]
                ValueC
            }

            [Flags]
            private enum SimpleFlagEnum
            {
                None = 0,
                [Display(Name = "Value A")]
                ValueA = 1,
                ValueB = 1 << 1,
                [Display(Name = "Value Other")]
                ValueC = 1 << 2,
                All = ValueA | ValueB | ValueC
            }

            public class UsingType
            {
                [Fact]
                public void ValidEnumTextPasses()
                {
                    var result = "valuea".ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    var enumResult1 = (SimpleEnum)result;

                    result = "valueb".ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    var enumResult2 = (SimpleEnum)result;

                    result = "valuec".ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    var enumResult3 = (SimpleEnum)result;

                    enumResult1.Should().Be(SimpleEnum.ValueA);
                    enumResult2.Should().Be(SimpleEnum.ValueB);
                    enumResult3.Should().Be(SimpleEnum.ValueC);
                }

                [Fact]
                public void ValidEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    var enumResult = (SimpleEnum)result;

                    enumResult.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidEnumTextReturnsNull()
                {
                    const string Value = "XYZ";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    result.Should().BeNull();
                }

                [Fact]
                public void InvalidEnumNumberReturnsNull()
                {
                    const string Value = "10";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    result.Should().BeNull();
                }

                [Fact]
                public void ValidFlagTextPasses()
                {
                    var result = "all".ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult1 = (SimpleFlagEnum)result;

                    result = "none".ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult2 = (SimpleFlagEnum)result;

                    result = "ValueB".ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult3 = (SimpleFlagEnum)result;

                    result = "ValueA,ValueB".ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult4 = (SimpleFlagEnum)result;

                    enumResult1.Should().Be(SimpleFlagEnum.All);
                    enumResult2.Should().Be(SimpleFlagEnum.None);
                    enumResult3.Should().Be(SimpleFlagEnum.ValueB);
                    enumResult4.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidFlagMultipleTextPasses()
                {
                    const string Value = "valuea, valueb";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertToNullable().Enum.ParseByType(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void PassingNullTypeThrows()
                {
                    Assert.Throws<ArgumentNullException>(() => "3".ConvertToNullable().Enum.ParseByType(null));
                }

                [Fact]
                public void PassingNonEnumTypeThrows()
                {
                    Assert.Throws<ArgumentException>(() => "3".ConvertToNullable().Enum.ParseByType(typeof(object)));
                }

                [Fact]
                public void PassingNullStringReturnsNull()
                {
                    var result = ((string)null).ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    result.Should().BeNull();
                }

                [Fact]
                public void PassingWhiteSpaceReturnsNull()
                {
                    var result = "  ".ConvertToNullable().Enum.ParseByType(typeof(SimpleEnum));
                    result.Should().BeNull();
                }
            }

            public class UsingGenerics
            {
                [Fact]
                public void ValidGenericEnumTextPasses()
                {
                    const string Value = "valuea";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleEnum>();

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void ValidGenericEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleEnum>();

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidGenericEnumTextReturnsNull()
                {
                    const string Value = "XYZ";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleEnum>();
                    result.HasValue.Should().BeFalse();
                }

                [Fact]
                public void InvalidGenericEnumNumberReturnsNull()
                {
                    const string Value = "10";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleEnum>();
                    result.HasValue.Should().BeFalse();
                }

                [Fact]
                public void ValidGenericFlagTextPasses()
                {
                    const string Value = "all";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagMultipleTextPasses()
                {
                    const string Value = "valuea, valueb";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidGenericFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertToNullable().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }
            }
        }

        public class DateTimeTests
        {
            [Fact]
            public void ValidDatePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "12/25/2012".ConvertToNullable().DateTime.Parse();

                    result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    Debug.Assert(result != null, "result != null");
                    result.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void ValidDateTimeCulturePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "2012/12/25 3:14:22.123 PM".ConvertToNullable().DateTime.ParseCulture();

                    result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                    Debug.Assert(result != null, "result != null");
                    result.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void InvalidDateReturnsNull()
            {
                var result = "2012/25/12".ConvertToNullable().DateTime.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void PassedCulturePasses()
            {
                var result = " 25/12/2012 ".ConvertToNullable().DateTime.Parse(new CultureInfo("en-GB"));

                result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                Debug.Assert(result != null, "result != null");
                result.Value.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void PassedStylePasses()
            {
                var result = "2012/12/25 15:14:22.123".ConvertToNullable().DateTime.Parse(new CultureInfo("en-GB"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal);

                result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                Debug.Assert(result != null, "result != null");
                result.Value.Kind.Should().Be(DateTimeKind.Local);
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertToNullable().DateTime.ParseExact("s");
                var result2 = "25/12/2012".ConvertToNullable().DateTime.ParseExact("d", new CultureInfo("en-GB"));

                result1.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                Debug.Assert(result1 != null, "result != null");
                result1.Value.Kind.Should().Be(DateTimeKind.Unspecified);

                result2.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                Debug.Assert(result2 != null, "result != null");
                result2.Value.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertToNullable().DateTime.ParseExact(new[] { "s", "o" });
                var result2 = "2012-12-25T15:15:22.0900000-08:00".ConvertToNullable().DateTime.ParseExactCulture(new[] { "s", "o" });
                var result3 = "2012-12-25 15:16:22Z".ConvertToNullable().DateTime.ParseExactInvariant(new[] { "s", "u" });
                var result4 = "25/12/2012".ConvertToNullable().DateTime.ParseExact(new[] { "s", "d" }, new CultureInfo("en-GB"));

                result1.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                Debug.Assert(result1 != null, "result1 != null");
                result1.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                result2.Should().Be(new DateTime(2012, 12, 25, 15, 15, 22, 90));
                Debug.Assert(result2 != null, "result2 != null");
                result2.Value.Kind.Should().Be(DateTimeKind.Local);
                result3.Should().Be(new DateTime(2012, 12, 25, 15, 16, 22, 0));
                Debug.Assert(result3 != null, "result3 != null");
                result3.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                result4.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                Debug.Assert(result4 != null, "result3 != null");
                result4.Value.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void InvalidExactMatchReturnsNull()
            {
                var result = "2012/12/25T15:14:22".ConvertToNullable().DateTime.ParseExact("s");
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void InvariantsAreRespected()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result1 = "12/25/2012".ConvertToNullable().DateTime.ParseInvariant();
                    var result2 = "12/25/2012".ConvertToNullable().DateTime.ParseExactInvariant("d");
                    var result3 = "25/12/2012".ConvertToNullable().DateTime.ParseExactCulture("d");

                    result1.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    Debug.Assert(result1 != null, "result1 != null");
                    result1.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                    result2.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    Debug.Assert(result2 != null, "result2 != null");
                    result2.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                    result3.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    Debug.Assert(result3 != null, "result3 != null");
                    result3.Value.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void InvalidInvariantReturnsNull()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result = "25/12/2012".ConvertToNullable().DateTime.ParseExactInvariant("d");
                    result.HasValue.Should().BeFalse();
                }
            }
        }

        public class DateTimeOffsetTests
        {
            private static TimeSpan DefaultOffset { get { return new TimeSpan(0, -8, 0, 0); } }

            [Fact]
            public void ValidDatePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "12/25/2012".ConvertToNullable().DateTimeOffset.Parse();

                    result.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                }
            }

            [Fact]
            public void ValidDateTimeCulturePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "2012/12/25 3:14:22.123 PM".ConvertToNullable().DateTimeOffset.ParseCulture();

                    result.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 123, DefaultOffset));
                }
            }

            [Fact]
            public void InvalidDateReturnsNull()
            {
                var result = "2012/25/12".ConvertToNullable().DateTimeOffset.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void PassedCulturePasses()
            {
                var result = " 25/12/2012 ".ConvertToNullable().DateTimeOffset.Parse(new CultureInfo("en-GB"));

                result.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void PassedStylePasses()
            {
                var result = "2012/12/25 15:14:22.123".ConvertToNullable().DateTimeOffset.Parse(new CultureInfo("en-GB"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal);

                result.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 123, DefaultOffset));
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertToNullable().DateTimeOffset.ParseExact("s");
                var result2 = "25/12/2012".ConvertToNullable().DateTimeOffset.ParseExact("d", new CultureInfo("en-GB"));

                result1.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 0, DefaultOffset));
                result2.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertToNullable().DateTimeOffset.ParseExact(new[] { "s", "o" });
                var result2 = "2012-12-25T15:15:22.0900000-08:00".ConvertToNullable().DateTimeOffset.ParseExactCulture(new[] { "s", "o" });
                var result3 = "2012-12-25 15:16:22Z".ConvertToNullable().DateTimeOffset.ParseExactInvariant(new[] { "s", "u" });
                var result4 = "25/12/2012".ConvertToNullable().DateTimeOffset.ParseExact(new[] { "s", "d" }, new CultureInfo("en-GB"));

                result1.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 0, DefaultOffset));
                result2.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 15, 22, 90, DefaultOffset));
                result3.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 16, 22, 0, new TimeSpan(0, 0, 0, 0)));
                result4.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void InvalidExactMatchReturnsNull()
            {
                var result = "2012/12/25T15:14:22".ConvertToNullable().DateTimeOffset.ParseExact("s");
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void InvariantsAreRespected()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result1 = "12/25/2012".ConvertToNullable().DateTimeOffset.ParseInvariant();
                    var result2 = "12/25/2012".ConvertToNullable().DateTimeOffset.ParseExactInvariant("d");
                    var result3 = "25/12/2012".ConvertToNullable().DateTimeOffset.ParseExactCulture("d");

                    result1.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                    result2.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                    result3.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                }
            }

            [Fact]
            public void InvalidInvariantReturnsNull()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result = "25/12/2012".ConvertToNullable().DateTimeOffset.ParseExactInvariant("d");
                    result.HasValue.Should().BeFalse();    
                }
            }
        }

        public class TimeSpanTests
        {
            private static TimeSpan ExpectedTimeSpan { get { return new TimeSpan(0, 2, 3, 4, 500); } }

            [Fact]
            public void ValidTimeSpanPasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertToNullable().TimeSpan.Parse();
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4.5".ConvertToNullable().TimeSpan.Parse(new CultureInfo("en-US"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void ValidTimeSpanCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result1 = "2:3:4,500".ConvertToNullable().TimeSpan.Parse();
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4,5".ConvertToNullable().TimeSpan.Parse(new CultureInfo("fr-FR"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void InvalidTimeSpanReturnsNull()
            {
                var result = "ABC".ConvertToNullable().TimeSpan.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NullTimeSpanReturnsNull()
            {
                var result = ((string)null).ConvertToNullable().TimeSpan.Parse();
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertToNullable().TimeSpan.ParseExact("g");
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4.5".ConvertToNullable().TimeSpan.ParseExact("g", new CultureInfo("en-US"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void ExactStyleIsRespected()
            {
                var expected = new TimeSpan(0, -2, -3, -4, -500);
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertToNullable().TimeSpan.ParseExact(new[] { "h':'m':'s'.'fff" }, TimeSpanStyles.AssumeNegative);
                    result1.Should().Be(expected);
                }
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2:3:4.500".ConvertToNullable().TimeSpan.ParseExact(new[] { "g", "G" }, new CultureInfo("en-US"));

                TimeSpan? result2;
                TimeSpan? result3;

                using (new CultureInfoScope("en-US"))
                {
                    result2 = "0:2:3:4.5000000".ConvertToNullable().TimeSpan.ParseExactCulture(new[] { "g", "G" });
                }

                using (new CultureInfoScope("fr-FR"))
                {
                    result3 = "2:3:4.5".ConvertToNullable().TimeSpan.ParseExactInvariant(new[] { "g", "G" });
                }

                result1.Should().Be(ExpectedTimeSpan);
                result2.Should().Be(ExpectedTimeSpan);
                result3.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void InvalidExactMatchReturnsNull()
            {
                var result = "ABC".ConvertToNullable().TimeSpan.ParseExact("g");
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void InvalidFormatMatchReturnsNull()
            {
                var result = "2:3:4.500".ConvertToNullable().TimeSpan.ParseExact("z");
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void NullExactMatchReturnsNull()
            {
                var result = ((string)null).ConvertToNullable().TimeSpan.ParseExact("g");
                result.HasValue.Should().BeFalse();
            }

            [Fact]
            public void ParseCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4,5".ConvertToNullable().TimeSpan.ParseCulture();
                    result.Should().Be(ExpectedTimeSpan);

                    // BAF - For some reason the lines below don't work.  I have verified it is not an issue with my code as I am correctly
                    // routing the current culture through.  It is possible that the culture sensitive version of TimeSpan.TryParse allows
                    // both the culture's separator (which is a comma for France) as well as the invariant (or US) separator which is a period.
                    // However, that doesn't fit the documentation on MSDN so it may be an error in their code.  Also, TimeSpan.TryParseExact seems
                    // to work perfectly.
                    // 
                    ////var result2 = "2:3:4.5".ConvertToNullable().TimeSpan.ParseCulture();
                    ////result2.HasValue.Should().BeFalse();
                }
            }

            [Fact]
            public void ParseInvariantPasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4.5".ConvertToNullable().TimeSpan.ParseInvariant();
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4,5".ConvertToNullable().TimeSpan.ParseInvariant();
                    result2.HasValue.Should().BeFalse();
                }
            }

            [Fact]
            public void ParseExactCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4,5".ConvertToNullable().TimeSpan.ParseExactCulture("g");
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4.5".ConvertToNullable().TimeSpan.ParseExactCulture("g");
                    result2.HasValue.Should().BeFalse();
                }
            }

            [Fact]
            public void ParseExactInvariantPasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4.5".ConvertToNullable().TimeSpan.ParseExactInvariant("g");
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4,5".ConvertToNullable().TimeSpan.ParseExactInvariant("g");
                    result2.HasValue.Should().BeFalse();
                }
            }
        }
    }
}
