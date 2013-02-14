// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericNumericStringParser.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.NumericConverters
{
    using System.Globalization;
    using FluentConversions.ConversionDelegates;

    internal class GenericNumericStringParser
    {
        public static T ParseNumeric<T>(string input, NumberStyles style, GenericParseNumeric<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            return method(input, style);
        }

        public static T ParseNumericCulture<T>(string input, NumberStyles style, IFormatProvider provider, GenericParseNumericCulture<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            return method(input, style, provider);
        }

        public static T? TryParseNullableNumeric<T>(string value, NumberStyles style, IFormatProvider provider, GenericTryParseNumeric<T> method)
            where T : struct
        {
            if (method == null)
                throw new ArgumentNullException("method");

            T result;
            if (!method(value, style, provider, out result))
                return null;

            return result;
        }

        public static T TryParseDefaultNumeric<T>(
            string value, NumberStyles style, IFormatProvider provider, T defaultValue, GenericTryParseNumeric<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            T result;
            return method(value, style, provider, out result) ? result : defaultValue;
        }
    }
}
