// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly",
        Justification = "Rule shouldn't fire for the AssemblyInformationalVersionAttribute.")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "FluentConversions.StringConversions.NullableStringConversions.Decimal(System.Globalization.NumberStyles)", Scope = "member",
        Target = "FluentConversions.StringConversions.NullableStringConversions.#Currency(System.Boolean)",
        Justification = "We specifically want the default culture info behavior provided by the framework.")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "FluentConversions.StringConversions.StandardStringConversions.Decimal(System.Globalization.NumberStyles)", Scope = "member",
        Target = "FluentConversions.StringConversions.StandardStringConversions.#Currency(System.Boolean)",
        Justification = "We specifically want the default culture info behavior provided by the framework.")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "FluentConversions.StringConversions.DateTimeConverters.DateTimeConversionsDefault.Parse(System.Globalization.DateTimeStyles,System.DateTime)",
        Scope = "member", Target = "FluentConversions.StringConversions.DateTimeConverters.DateTimeConversionsDefault.#Parse(System.DateTime)",
        Justification = "We want to call an overload that takes care of culture.")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "FluentConversions.StringConversions.DateTimeConverters.DateTimeOffsetConversionsDefault.Parse(System.Globalization.DateTimeStyles,System.DateTimeOffset)",
        Scope = "member", Target = "FluentConversions.StringConversions.DateTimeConverters.DateTimeOffsetConversionsDefault.#Parse(System.DateTimeOffset)",
        Justification = "We want to call an overload that takes care of culture.")]
