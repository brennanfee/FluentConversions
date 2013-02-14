// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class EnumConversionsDefault
    {
        private readonly string _input;

        internal EnumConversionsDefault(string input)
        {
            _input = input;
        }

        public object Parse(Type enumType, object defaultValue = default(object), bool ignoreCase = true)
        {
            // TODO: Localize
            if (enumType == null)
                throw new ArgumentNullException("enumType");
            if (!enumType.IsEnum)
                throw new ArgumentException("Type passed must be an enum.", "enumType");
            if (_input == null)
                throw new ArgumentNullException("String is null.", (Exception)null);
            if (string.IsNullOrWhiteSpace(_input))
                throw new ArgumentException("String is empty or only contains white space.");

            try
            {
                var result = Enum.Parse(enumType, _input, ignoreCase);
                return !EnumTools.ResultIsValid(enumType, result) ? defaultValue : result;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public T Parse<T>(T defaultValue = default(T), bool ignoreCase = true) where T : struct
        {
            T result;
            if (!Enum.TryParse(_input, ignoreCase, out result))
                return defaultValue;

            return !EnumTools.ResultIsValid(typeof(T), result) ? defaultValue : result;
        }
    }
}
