// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringConversionExtensions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions
{
    using System.Linq;
    using FluentConversions.StringConversions;

    public static class StringConversionExtensions
    {
        public static StandardStringConversions ConvertTo(this string input)
        {
            return new StandardStringConversions(input);
        }

        public static NullableStringConversions ConvertToNullable(this string input)
        {
            return new NullableStringConversions(input);
        }

        public static DefaultStringConversions ConvertWithDefaultTo(this string input)
        {
            return new DefaultStringConversions(input);
        }
    }
}
