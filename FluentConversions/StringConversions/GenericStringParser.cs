// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericStringParser.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.StringConversions
{
    using System.Globalization;
    using System.Linq;
    using FluentConversions.ConversionDelegates;

    internal static class GenericStringParser
    {
        public static T Parse<T>(string input, GenericParse<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            return method(input);
        }

        public static T ParseCulture<T>(string input, IFormatProvider provider, GenericParseCulture<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            return method(input, provider);
        }

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

        public static T? TryParseNullable<T>(string value, GenericTryParse<T> method) where T : struct
        {
            if (method == null)
                throw new ArgumentNullException("method");

            T result;
            if (!method(value, out result))
                return null;

            return result;
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

        public static T TryParseDefault<T>(string value, T defaultValue, GenericTryParse<T> method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            T result;
            return method(value, out result) ? result : defaultValue;
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
