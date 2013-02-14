// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardStringConversionTests.cs" company="Brennan A. Fee">
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

    public static class StandardStringConversionTests
    {
        public class ByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "171";

                var result = Number.ConvertTo().Byte.Parse();

                result.Should().Be(171);
            }
        }

        public class Int16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = short.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int16.Parse();

                result.Should().Be(short.MinValue);
            }
        }

        public class Int32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = int.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int32.Parse();

                result.Should().Be(int.MinValue);
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = int.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Int32.ParseInvariant();

                result.Should().Be(int.MaxValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                var outOfBoundString = ((long)int.MaxValue + 1).ToString(CultureInfo.InvariantCulture);

                Assert.Throws<OverflowException>(() => outOfBoundString.ConvertTo().Int32.Parse());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "XYZ";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().Int32.ParseInvariant());
            }

            [Fact]
            public void HexStringPasses()
            {
                const string HexString = "ABC";

                var result = HexString.ConvertTo().Int32.ParseInvariant(NumberStyles.HexNumber);

                result.Should().Be(2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = " 1,234 ";

                var result = Number.ConvertTo().Int32.Parse(NumberStyles.Integer | NumberStyles.AllowThousands);

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Int32.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Int32.ParseCulture(NumberStyles.Integer | NumberStyles.AllowThousands);

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

                var result = lowestBoundString.ConvertTo().Int64.Parse();

                result.Should().Be(long.MinValue);
            }
        }

        public class SByteTests
        {
            [Fact]
            public void SimpleNumericPasses()
            {
                const string Number = "127";

                var result = Number.ConvertTo().SByte.Parse(NumberStyles.Integer);

                result.Should().Be(127);
            }
        }

        public class UInt16Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ushort.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt16.Parse();

                result.Should().Be(ushort.MinValue);
            }
        }

        public class UInt32Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = uint.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt32.Parse();

                result.Should().Be(uint.MinValue);
            }
        }

        public class UInt64Tests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = ulong.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().UInt64.Parse();

                result.Should().Be(ulong.MinValue);
            }
        }

        public class SingleTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = float.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Single.Parse();

                FloatAssertions.AlmostEqual(result, float.MinValue).Should().BeTrue();
            }

            [Fact]
            public void HighestBoundPasses()
            {
                var lowestBoundString = float.MaxValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Single.ParseInvariant();

                FloatAssertions.AlmostEqual(result, float.MaxValue).Should().BeTrue();
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "3.4e39";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Single.Parse());
            }

            [Fact]
            public void NonnumericStringThrows()
            {
                const string NonnumericString = "XYZ";

                Assert.Throws<FormatException>(() => NonnumericString.ConvertTo().Single.ParseInvariant());
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertTo().Single.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234";

                var result = Number.ConvertTo().Single.Parse();

                result.Should().Be(1234);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Single.ParseCulture();

                    result.Should().Be(1234);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Single.ParseCulture();

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

                var result = lowestBoundString.ConvertTo().Double.Parse();

                FloatAssertions.AlmostEqual(result, -1e300).Should().BeTrue();
            }
        }

        public class DecimalTests
        {
            [Fact]
            public void LowestBoundPasses()
            {
                var lowestBoundString = decimal.MinValue.ToString(CultureInfo.InvariantCulture);

                var result = lowestBoundString.ConvertTo().Decimal.Parse();

                result.Should().Be(decimal.MinValue);
            }

            [Fact]
            public void OutOfBoundThrows()
            {
                const string OutOfBoundString = "79000000000000000000000000000000";

                Assert.Throws<OverflowException>(() => OutOfBoundString.ConvertTo().Decimal.Parse());
            }

            [Fact]
            public void NegativeParenthesesPasses()
            {
                const string Number = "(2748)";

                var result = Number.ConvertTo().Decimal.ParseInvariant(NumberStyles.Any);

                result.Should().Be(-2748);
            }

            [Fact]
            public void ThousandsNumericPasses()
            {
                const string Number = "1,234.567";

                var result = Number.ConvertTo().Decimal.Parse();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void SimpleFrenchCulturePasses()
            {
                const string Number = "1234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Decimal.ParseCulture(NumberStyles.Number & ~NumberStyles.AllowThousands);

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void ThousandsFrenchCulturePasses()
            {
                const string Number = "1 234,567";

                using (new CultureInfoScope("fr-FR"))
                {
                    var result = Number.ConvertTo().Decimal.ParseCulture();

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
                    var result = Number.ConvertTo().Currency.Parse();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void BaseInvalidInputThrows()
            {
                Assert.Throws<FormatException>(() => string.Empty.ConvertTo().Currency.Parse());
            }

            [Fact]
            public void BaseRoundsToCultureLength()
            {
                const string Number = "1 234,567 kr";

                using (new CultureInfoScope("sv-SE"))
                {
                    var result = Number.ConvertTo().Currency.Parse(true);

                    result.Should().Be(1234.57m);
                }
            }

            [Fact]
            public void PassedCulturePasses()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"));

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void PassedCultureInvalidInputThrows()
            {
                Assert.Throws<FormatException>(() => string.Empty.ConvertTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE")));
            }

            [Fact]
            public void PassedCultureRounds()
            {
                const string Number = "1 234,567 kr";

                var result = Number.ConvertTo().Currency.Parse(CultureInfo.GetCultureInfo("sv-SE"), true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void InvariantPasses()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertTo().Currency.ParseInvariant();

                result.Should().Be(1234.567m);
            }

            [Fact]
            public void InvariantInvalidInputThrows()
            {
                Assert.Throws<FormatException>(() => string.Empty.ConvertTo().Currency.ParseInvariant());
            }

            [Fact]
            public void InvariantRounds()
            {
                const string Number = "¤ 1,234.567";

                var result = Number.ConvertTo().Currency.ParseInvariant(true);

                result.Should().Be(1234.57m);
            }

            [Fact]
            public void CulturePasses()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertTo().Currency.ParseCulture();

                    result.Should().Be(1234.567m);
                }
            }

            [Fact]
            public void CultureInvalidInputThrows()
            {
                Assert.Throws<FormatException>(() => string.Empty.ConvertTo().Currency.ParseCulture());
            }

            [Fact]
            public void CultureRounds()
            {
                const string Number = "$ 1,234.567";

                using (new CultureInfoScope("en-US"))
                {
                    var result = Number.ConvertTo().Currency.ParseCulture(true);

                    result.Should().Be(1234.57m);
                }
            }
        }

        public class CharTests
        {
            [Fact]
            public void ValidStringPasses()
            {
                var result = "A".ConvertTo().Char.Parse();
                result.Should().Be('A');
            }

            [Fact]
            public void NullStringThrows()
            {
                Assert.Throws<ArgumentNullException>(() => ((string)null).ConvertTo().Char.Parse());
            }

            [Fact]
            public void EmptyStringThrows()
            {
                Assert.Throws<FormatException>(() => string.Empty.ConvertTo().Char.Parse());
            }

            [Fact]
            public void MultipleCharacterStringThrows()
            {
                Assert.Throws<FormatException>(() => "ABC".ConvertTo().Char.Parse());
            }
        }

        public class BoolTests
        {
            [Fact]
            public void ValidBoolStringsPass()
            {
                var trueResult = bool.TrueString.ConvertTo().Bool.Parse();
                var falseResult = bool.FalseString.ConvertTo().Bool.Parse();
                trueResult.Should().BeTrue();
                falseResult.Should().BeFalse();
            }

            [Fact]
            public void InvalidBoolStringThrows()
            {
                Assert.Throws<FormatException>(() => "Yes".ConvertTo().Bool.Parse());
            }

            [Fact]
            public void NullStringThrows()
            {
                Assert.Throws<ArgumentNullException>(() => ((string)null).ConvertTo().Bool.Parse());
            }
        }

        public class GuidTests
        {
            [Fact]
            public void ValidGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertTo().Guid.Parse();

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidGuidThrows()
            {
                Assert.Throws<FormatException>(() => "XYZ".ConvertTo().Guid.Parse());
            }

            [Fact]
            public void NullStringThrows()
            {
                Assert.Throws<ArgumentNullException>(() => ((string)null).ConvertTo().Guid.Parse());
            }

            [Fact]
            public void ValidExactGuidPasses()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                var result = valueString.ConvertTo().Guid.ParseExact("X");

                result.Should().Be(value);
            }

            [Fact]
            public void InvalidExactGuidThrows()
            {
                var value = Guid.NewGuid();
                var valueString = value.ToString("X");

                Assert.Throws<FormatException>(() => valueString.ConvertTo().Guid.ParseExact("N"));
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
                    const string Value = "valuea";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleEnum));
                    var enumResult = (SimpleEnum)result;

                    enumResult.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void ValidEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleEnum));
                    var enumResult = (SimpleEnum)result;

                    enumResult.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidEnumTextThrows()
                {
                    const string Value = "XYZ";
                    Assert.Throws<ArgumentException>(() => Value.ConvertTo().Enum.Parse(typeof(SimpleEnum)));
                }

                [Fact]
                public void InvalidEnumNumberThrows()
                {
                    const string Value = "10";
                    Assert.Throws<ArgumentException>(() => Value.ConvertTo().Enum.Parse(typeof(SimpleEnum)));
                }

                [Fact]
                public void ValidFlagTextPasses()
                {
                    const string Value = "all";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidFlagMultipleTextPasses()
                {
                    const string Value = "valuea, valueb";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertTo().Enum.Parse(typeof(SimpleFlagEnum));
                    var enumResult = (SimpleFlagEnum)result;

                    enumResult.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }
            }

            public class UsingGenerics
            {
                [Fact]
                public void ValidGenericEnumTextPasses()
                {
                    const string Value = "valuea";
                    var result = Value.ConvertTo().Enum.Parse<SimpleEnum>();

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void ValidGenericEnumNumberPasses()
                {
                    const string Value = "0";
                    var result = Value.ConvertTo().Enum.Parse<SimpleEnum>();

                    result.Should().Be(SimpleEnum.ValueA);
                }

                [Fact]
                public void InvalidGenericEnumTextThrows()
                {
                    const string Value = "XYZ";
                    Assert.Throws<ArgumentException>(() => Value.ConvertTo().Enum.Parse<SimpleEnum>());
                }

                [Fact]
                public void InvalidGenericEnumNumberThrows()
                {
                    const string Value = "10";
                    Assert.Throws<ArgumentException>(() => Value.ConvertTo().Enum.Parse<SimpleEnum>());
                }

                [Fact]
                public void ValidGenericFlagTextPasses()
                {
                    const string Value = "all";
                    var result = Value.ConvertTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagMultipleTextPasses()
                {
                    const string Value = "valuea, valueb";
                    var result = Value.ConvertTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.ValueA | SimpleFlagEnum.ValueB);
                }

                [Fact]
                public void ValidGenericFlagNumberPasses()
                {
                    const string Value = "7";
                    var result = Value.ConvertTo().Enum.Parse<SimpleFlagEnum>();

                    result.Should().Be(SimpleFlagEnum.All);
                }

                [Fact]
                public void ValidGenericFlagNumberWithoutLabelPasses()
                {
                    const string Value = "3";
                    var result = Value.ConvertTo().Enum.Parse<SimpleFlagEnum>();

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
                    var result = "12/25/2012".ConvertTo().DateTime.Parse();

                    result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void ValidDateTimeCulturePasses()
            {
                using (new CultureInfoScope("en-US"))
                {
                    var result = "2012/12/25 3:14:22.123 PM".ConvertTo().DateTime.ParseCulture();

                    result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                    result.Kind.Should().Be(DateTimeKind.Unspecified);
                }
            }

            [Fact]
            public void InvalidDateThrows()
            {
                Assert.Throws<FormatException>(() => "2012/25/12".ConvertTo().DateTime.Parse());
            }

            [Fact]
            public void PassedCulturePasses()
            {
                var result = " 25/12/2012 ".ConvertTo().DateTime.Parse(new CultureInfo("en-GB"));

                result.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                result.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void PassedStylePasses()
            {
                var result = "2012/12/25 15:14:22.123".ConvertTo().DateTime.Parse(new CultureInfo("en-GB"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal);

                result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 123));
                result.Kind.Should().Be(DateTimeKind.Local);
            }

            [Fact]
            public void ValidExactMatchPasses()
            {
                var result = "2012-12-25T15:14:22".ConvertTo().DateTime.ParseExact("s");

                result.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                result.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void ValidExactMatchArrayPasses()
            {
                var result1 = "2012-12-25T15:14:22".ConvertTo().DateTime.ParseExact(new[] { "s", "o" });
                var result2 = "2012-12-25T15:14:22.0900000-08:00".ConvertTo().DateTime.ParseExactCulture(new[] { "s", "o" });
                var result3 = "2012-12-25 15:14:22Z".ConvertTo().DateTime.ParseExactInvariant(new[] { "s", "u" });

                result1.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                result1.Kind.Should().Be(DateTimeKind.Unspecified);
                result2.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 90));
                result2.Kind.Should().Be(DateTimeKind.Local);
                result3.Should().Be(new DateTime(2012, 12, 25, 15, 14, 22, 0));
                result3.Kind.Should().Be(DateTimeKind.Unspecified);
            }

            [Fact]
            public void InvalidExactMatchThrows()
            {
                Assert.Throws<FormatException>(() => "2012/12/25T15:14:22".ConvertTo().DateTime.ParseExact("s"));
            }

            [Fact]
            public void InvariantsAreRespected()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    var result1 = "12/25/2012".ConvertTo().DateTime.ParseInvariant();
                    var result2 = "12/25/2012".ConvertTo().DateTime.ParseExactInvariant("d");
                    var result3 = "25/12/2012".ConvertTo().DateTime.ParseExactCulture("d");

                    result1.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result1.Kind.Should().Be(DateTimeKind.Unspecified);
                    result2.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result2.Kind.Should().Be(DateTimeKind.Unspecified);
                    result3.Should().Be(new DateTime(2012, 12, 25, 0, 0, 0, 0));
                    result3.Kind.Should().Be(DateTimeKind.Unspecified);                    
                }
            }

            [Fact]
            public void InvalidInvariantThrows()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    Assert.Throws<FormatException>(() => "25/12/2012".ConvertTo().DateTime.ParseExactInvariant("d"));
                }
            }
        }
    }
}
