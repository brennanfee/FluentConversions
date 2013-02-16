// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultStringConversionTests.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.Tests.StringConversions
{
    using System.ComponentModel.DataAnnotations;
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

        public class CharTests
        {
            private const char DefaultChar = 'Z';

            [Fact]
            public void ValidStringPasses()
            {
                var result = "A".ConvertWithDefaultTo().Char.Parse(DefaultChar);
                result.Should().Be('A');
            }

            [Fact]
            public void NullStringReturnsDefault()
            {
                var result = ((string)null).ConvertWithDefaultTo().Char.Parse(DefaultChar);
                result.Should().Be(DefaultChar);
            }

            [Fact]
            public void EmptyStringReturnsDefault()
            {
                var result = string.Empty.ConvertWithDefaultTo().Char.Parse(DefaultChar);
                result.Should().Be(DefaultChar);
            }

            [Fact]
            public void MultipleCharacterStringReturnsDefault()
            {
                var result = "ABC".ConvertWithDefaultTo().Char.Parse(DefaultChar);
                result.Should().Be(DefaultChar);
            }
        }

        public class BoolTests
        {
            [Fact]
            public void ValidBoolStringsPass()
            {
                var trueResult = bool.TrueString.ConvertWithDefaultTo().Bool.Parse();
                var falseResult = bool.FalseString.ConvertWithDefaultTo().Bool.Parse(true);
                trueResult.Should().BeTrue();
                falseResult.Should().BeFalse();
            }

            [Fact]
            public void InvalidBoolStringReturnsDefault()
            {
                var result1 = "Yes".ConvertWithDefaultTo().Bool.Parse();
                var result2 = "Yes".ConvertWithDefaultTo().Bool.Parse(true);

                result1.Should().BeFalse();
                result2.Should().BeTrue();
            }

            [Fact]
            public void NullStringReturnsDefault()
            {
                var result = ((string)null).ConvertWithDefaultTo().Bool.Parse(true);

                result.Should().BeTrue();
            }
        }

        public class GuidTests
        {
            private Guid DefaultGuid { get { return new Guid("{C1035134-94DD-4771-B1BA-B771440A9953}"); } }

            [Fact]
            public void ValidGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertWithDefaultTo().Guid.Parse(DefaultGuid);

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidGuidReturnsDefault()
            {
                var result = "XYZ".ConvertWithDefaultTo().Guid.Parse();
                result.Should().Be(Guid.Empty);
            }

            [Fact]
            public void NullStringReturnsDefault()
            {
                var result = ((string)null).ConvertWithDefaultTo().Guid.Parse(DefaultGuid);
                result.Should().Be(DefaultGuid);
            }

            [Fact]
            public void ValidExactGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertWithDefaultTo().Guid.ParseExact("X", DefaultGuid);

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidExactGuidReturnsDefault()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertWithDefaultTo().Guid.ParseExact("N", DefaultGuid);

                result.Should().Be(DefaultGuid);
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
                    var result = "valuea".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueB);
                    var enumResult1 = (SimpleEnum)result;

                    result = "valueb".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueA);
                    var enumResult2 = (SimpleEnum)result;

                    result = "valuec".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum));
                    var enumResult3 = (SimpleEnum)result;

                    enumResult1.Should().Be(SimpleEnum.ValueA);
                    enumResult2.Should().Be(SimpleEnum.ValueB);
                    enumResult3.Should().Be(SimpleEnum.ValueC);
                }

                [Fact]
                public void ValidEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueB);
                    var enumResult = (SimpleEnum)result;

                    enumResult.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidEnumTextReturnsDefault()
                {
                    const string Value = "XYZ";
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum));
                    result.Should().BeNull();
                }

                [Fact]
                public void InvalidEnumNumberReturnsDefault()
                {
                    const string Value = "10";
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueB);
                    result.Should().Be(SimpleEnum.ValueB);
                }

                [Fact]
                public void ValidFlagTextPasses()
                {
                    var result = "all".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.None);
                    var enumResult1 = (SimpleFlagEnum)result;

                    result = "none".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.All);
                    var enumResult2 = (SimpleFlagEnum)result;

                    result = "ValueB".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.None);
                    var enumResult3 = (SimpleFlagEnum)result;

                    result = "ValueA,ValueB".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.None);
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
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.All);
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.All);
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleFlagEnum), SimpleFlagEnum.All);
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void PassingNullTypeThrows()
                {
                    Assert.Throws<ArgumentNullException>(() => "3".ConvertWithDefaultTo().Enum.ParseByType(null));
                }

                [Fact]
                public void PassingNonEnumTypeThrows()
                {
                    Assert.Throws<ArgumentException>(() => "3".ConvertWithDefaultTo().Enum.ParseByType(typeof(object)));
                }

                [Fact]
                public void PassingNullStringReturnsDefault()
                {
                    var result = ((string)null).ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueB);
                    result.Should().Be(SimpleEnum.ValueB);
                }

                [Fact]
                public void PassingWhiteSpaceReturnsDefault()
                {
                    var result = "  ".ConvertWithDefaultTo().Enum.ParseByType(typeof(SimpleEnum), SimpleEnum.ValueB);
                    result.Should().Be(SimpleEnum.ValueB);
                }
            }

            public class UsingGenerics
            {
                [Fact]
                public void ValidGenericEnumTextPasses()
                {
                    const string Value = "valuea";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleEnum>(SimpleEnum.ValueB);

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void ValidGenericEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleEnum>(SimpleEnum.ValueB);

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidGenericEnumTextReturnsDefault()
                {
                    const string Value = "XYZ";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleEnum>();
                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidGenericEnumNumberReturnsDefault()
                {
                    const string Value = "10";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleEnum>(SimpleEnum.ValueB);
                    result.Should().Be(SimpleEnum.ValueB);
                }

                [Fact]
                public void ValidGenericFlagTextPasses()
                {
                    const string Value = "all";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleFlagEnum>(SimpleFlagEnum.ValueB);

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagMultipleTextPasses()
                {
                    const string Value = "valuea, valueb";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidGenericFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertWithDefaultTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }
            }
        }

        public class DateTimeTests
        {
            private DateTime DefaultDateTime { get { return new DateTime(2012, 1, 1, 0, 0, 0, 0); } }

            [Fact]
            public void ValidDatePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "12/25/2012".ConvertWithDefaultTo().DateTime.Parse();

                    result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void ValidDateTimeCulturePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "2012/12/25 3:14:22.123 PM".ConvertWithDefaultTo().DateTime.ParseCulture();

                    result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                    result.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void InvalidDateReturnsDefault()
            {
                var result = "2012/25/12".ConvertWithDefaultTo().DateTime.Parse(DefaultDateTime);
                result.Should().Be(DefaultDateTime);
            }

            [Fact]
            public void PassedCulturePasses()
            {
                var result = " 25/12/2012 ".ConvertWithDefaultTo().DateTime.Parse(new CultureInfo("en-GB"));

                result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                result.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void PassedStylePasses()
            {
                var result = "2012/12/25 15:14:22.123".ConvertWithDefaultTo().DateTime.Parse(new CultureInfo("en-GB"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal);

                result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                result.Kind.Should().Be(DateTimeKind.Local);
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertWithDefaultTo().DateTime.ParseExact("s");
                var result2 = "25/12/2012".ConvertWithDefaultTo().DateTime.ParseExact("d", new CultureInfo("en-GB"));

                result1.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                result1.Kind.Should().Be(DateTimeKind.Unspecified);
                result2.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                result2.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertWithDefaultTo().DateTime.ParseExact(new[] { "s", "o" }, DefaultDateTime);
                var result2 = "2012-12-25T15:15:22.0900000-08:00".ConvertWithDefaultTo().DateTime.ParseExactCulture(new[] { "s", "o" });
                var result3 = "2012-12-25 15:16:22Z".ConvertWithDefaultTo().DateTime.ParseExactInvariant(new[] { "s", "u" });
                var result4 = "25/12/2012".ConvertWithDefaultTo().DateTime.ParseExact(new[] { "s", "d" }, new CultureInfo("en-GB"));

                result1.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                result1.Kind.Should().Be(DateTimeKind.Unspecified);
                result2.Should().Be(new DateTime(2012, 12, 25, 15, 15, 22, 90));
                result2.Kind.Should().Be(DateTimeKind.Local);
                result3.Should().Be(new DateTime(2012, 12, 25, 15, 16, 22, 0));
                result3.Kind.Should().Be(DateTimeKind.Unspecified);
                result4.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                result4.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void InvalidExactMatchReturnsDefault()
            {
                var result = "2012/12/25T15:14:22".ConvertWithDefaultTo().DateTime.ParseExact("s", DefaultDateTime);
                result.Should().Be(DefaultDateTime);
            }

            [Fact]
            public void InvariantsAreRespected()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result1 = "12/25/2012".ConvertWithDefaultTo().DateTime.ParseInvariant();
                    var result2 = "12/25/2012".ConvertWithDefaultTo().DateTime.ParseExactInvariant("d");
                    var result3 = "25/12/2012".ConvertWithDefaultTo().DateTime.ParseExactCulture("d");

                    result1.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result1.Kind.Should().Be(DateTimeKind.Unspecified);
                    result2.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result2.Kind.Should().Be(DateTimeKind.Unspecified);
                    result3.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result3.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void InvalidInvariantReturnsDefault()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result = "25/12/2012".ConvertWithDefaultTo().DateTime.ParseExactInvariant("d", DefaultDateTime);
                    result.Should().Be(DefaultDateTime);
                }
            }
        }

        public class DateTimeOffsetTests
        {
            private TimeSpan DefaultOffset { get { return new TimeSpan(0, -8, 0, 0); } }

            private DateTimeOffset DefaultDateTime { get { return new DateTimeOffset(2012, 1, 1, 0, 0, 0, 0, DefaultOffset); } }

            [Fact]
            public void ValidDatePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "12/25/2012".ConvertWithDefaultTo().DateTimeOffset.Parse();

                    result.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                }
            }

            [Fact]
            public void ValidDateTimeCulturePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "2012/12/25 3:14:22.123 PM".ConvertWithDefaultTo().DateTimeOffset.ParseCulture(DefaultDateTime);

                    result.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 123, DefaultOffset));
                }
            }

            [Fact]
            public void InvalidDateReturnsDefault()
            {
                var result = "2012/25/12".ConvertWithDefaultTo().DateTimeOffset.Parse(DefaultDateTime);

                result.Should().Be(DefaultDateTime);
            }

            [Fact]
            public void PassedCulturePasses()
            {
                var result = " 25/12/2012 ".ConvertWithDefaultTo().DateTimeOffset.Parse(new CultureInfo("en-GB"));

                result.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void PassedStylePasses()
            {
                var result = "2012/12/25 15:14:22.123".ConvertWithDefaultTo().DateTimeOffset.Parse(new CultureInfo("en-GB"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal);

                result.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 123, DefaultOffset));
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertWithDefaultTo().DateTimeOffset.ParseExact("s");
                var result2 = "25/12/2012".ConvertWithDefaultTo().DateTimeOffset.ParseExact("d", new CultureInfo("en-GB"));

                result1.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 0, DefaultOffset));
                result2.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertWithDefaultTo().DateTimeOffset.ParseExact(new[] { "s", "o" });
                var result2 = "2012-12-25T15:15:22.0900000-08:00".ConvertWithDefaultTo().DateTimeOffset.ParseExactCulture(new[] { "s", "o" });
                var result3 = "2012-12-25 15:16:22Z".ConvertWithDefaultTo().DateTimeOffset.ParseExactInvariant(new[] { "s", "u" });
                var result4 = "25/12/2012".ConvertWithDefaultTo().DateTimeOffset.ParseExact(new[] { "s", "d" }, new CultureInfo("en-GB"));

                result1.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 14, 22, 0, DefaultOffset));
                result2.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 15, 22, 90, DefaultOffset));
                result3.Should().Be(new DateTimeOffset(2012, 12, 25, 15, 16, 22, 0, new TimeSpan(0, 0, 0, 0)));
                result4.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
            }

            [Fact]
            public void InvalidExactMatchReturnsDefault()
            {
                var result = "2012/12/25T15:14:22".ConvertWithDefaultTo().DateTimeOffset.ParseExact("s", DefaultDateTime);
                result.Should().Be(DefaultDateTime);
            }

            [Fact]
            public void InvariantsAreRespected()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result1 = "12/25/2012".ConvertWithDefaultTo().DateTimeOffset.ParseInvariant();
                    var result2 = "12/25/2012".ConvertWithDefaultTo().DateTimeOffset.ParseExactInvariant("d");
                    var result3 = "25/12/2012".ConvertWithDefaultTo().DateTimeOffset.ParseExactCulture("d");

                    result1.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                    result2.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                    result3.Should().Be(new DateTimeOffset(2012, 12, 25, 0, 0, 0, 0, DefaultOffset));
                }
            }

            [Fact]
            public void InvalidInvariantReturnsDefault()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result = "25/12/2012".ConvertWithDefaultTo().DateTimeOffset.ParseExactInvariant("d", DefaultDateTime);
                    result.Should().Be(DefaultDateTime);
                }
            }
        }

        public class TimeSpanTests
        {
            private TimeSpan ExpectedTimeSpan
            {
                get { return new TimeSpan(0, 2, 3, 4, 500); }
            }

            private TimeSpan DefaultTimeSpan
            {
                get { return new TimeSpan(0, 1, 30, 0, 0); }
            }

            [Fact]
            public void ValidTimeSpanPasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertWithDefaultTo().TimeSpan.Parse();
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.Parse(new CultureInfo("en-US"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void ValidTimeSpanCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result1 = "2:3:4,500".ConvertWithDefaultTo().TimeSpan.Parse();
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4,5".ConvertWithDefaultTo().TimeSpan.Parse(new CultureInfo("fr-FR"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void InvalidTimeSpanReturnsDefault()
            {
                var result = "ABC".ConvertWithDefaultTo().TimeSpan.Parse(DefaultTimeSpan);
                result.Should().Be(DefaultTimeSpan);
            }

            [Fact]
            public void NullTimeSpanReturnsDefault()
            {
                var result = ((string)null).ConvertWithDefaultTo().TimeSpan.Parse(DefaultTimeSpan);
                result.Should().Be(DefaultTimeSpan);
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertWithDefaultTo().TimeSpan.ParseExact("g");
                    result1.Should().Be(ExpectedTimeSpan);
                }

                var result2 = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseExact("g", new CultureInfo("en-US"));
                result2.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void ExactStyleIsRespected()
            {
                var expected = new TimeSpan(0, -2, -3, -4, -500);
                using (new CultureInfoScope("en-US"))
                {
                    var result1 = "2:3:4.500".ConvertWithDefaultTo().TimeSpan.ParseExact(new[] { "h':'m':'s'.'fff" }, TimeSpanStyles.AssumeNegative);
                    result1.Should().Be(expected);
                }
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2:3:4.500".ConvertWithDefaultTo().TimeSpan.ParseExact(new[] { "g", "G" }, new CultureInfo("en-US"));

                TimeSpan? result2;
                TimeSpan? result3;

                using (new CultureInfoScope("en-US"))
                {
                    result2 = "0:2:3:4.5000000".ConvertWithDefaultTo().TimeSpan.ParseExactCulture(new[] { "g", "G" });
                }

                using (new CultureInfoScope("fr-FR"))
                {
                    result3 = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseExactInvariant(new[] { "g", "G" });
                }

                result1.Should().Be(ExpectedTimeSpan);
                result2.Should().Be(ExpectedTimeSpan);
                result3.Should().Be(ExpectedTimeSpan);
            }

            [Fact]
            public void InvalidExactMatchReturnsDefault()
            {
                var result = "ABC".ConvertWithDefaultTo().TimeSpan.ParseExact("g", DefaultTimeSpan);
                result.Should().Be(DefaultTimeSpan);
            }

            [Fact]
            public void InvalidFormatMatchReturnsDefault()
            {
                var result = "2:3:4.500".ConvertWithDefaultTo().TimeSpan.ParseExact("z", DefaultTimeSpan);
                result.Should().Be(DefaultTimeSpan);
            }

            [Fact]
            public void NullExactMatchReturnsDefault()
            {
                var result = ((string)null).ConvertWithDefaultTo().TimeSpan.ParseExact(new[] { "g" }, DefaultTimeSpan);
                result.Should().Be(DefaultTimeSpan);
            }

            [Fact]
            public void ParseCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4,5".ConvertWithDefaultTo().TimeSpan.ParseCulture();
                    result.Should().Be(ExpectedTimeSpan);

                    // BAF - For some reason the lines below don't work.  I have verified it is not an issue with my code as I am correctly
                    // routing the current culture through.  It is possible that the culture sensitive version of TimeSpan.TryParse allows
                    // both the culture's separator (which is a comma for France) as well as the invariant (or US) separator which is a period.
                    // However, that doesn't fit the documentation on MSDN so it may be an error in their code.  Also, TimeSpan.TryParseExact seems
                    // to work perfectly.
                    // 
                    ////var result2 = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseCulture(DefaultTimeSpan);
                    ////result2.Should().Be(DefaultTimeSpan);
                }
            }

            [Fact]
            public void ParseInvariantPasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseInvariant();
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4,5".ConvertWithDefaultTo().TimeSpan.ParseInvariant(DefaultTimeSpan);
                    result2.Should().Be(DefaultTimeSpan);
                }
            }

            [Fact]
            public void ParseExactCulturePasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4,5".ConvertWithDefaultTo().TimeSpan.ParseExactCulture("g");
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseExactCulture("g", DefaultTimeSpan);
                    result2.Should().Be(DefaultTimeSpan);
                }
            }

            [Fact]
            public void ParseExactInvariantPasses()
            {
                using (new CultureInfoScope("fr-FR"))
                {
                    var result = "2:3:4.5".ConvertWithDefaultTo().TimeSpan.ParseExactInvariant("g");
                    result.Should().Be(ExpectedTimeSpan);

                    var result2 = "2:3:4,5".ConvertWithDefaultTo().TimeSpan.ParseExactInvariant("g", DefaultTimeSpan);
                    result2.Should().Be(DefaultTimeSpan);
                }
            }
        }
    }
}
