// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumTools.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    using System.Globalization;

    internal static class EnumTools
    {
        // TODO: Localize

        public static void ValidateResult(Type enumType, object value, string input)
        {
            if (!ResultIsValid(enumType, value))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Requested value '{0}' was not found.", input));
        }

        public static bool ResultIsValid(Type enumType, object value)
        {
            return Attribute.IsDefined(enumType, typeof(FlagsAttribute)) || Enum.IsDefined(enumType, value);
        }
    }
}
