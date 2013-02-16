// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class EnumConversionsNullable
    {
        private readonly string _input;

        internal EnumConversionsNullable(string input)
        {
            _input = input;
        }

        public object ParseByType(Type enumType, bool ignoreCase = true)
        {
            // TODO: Localize
            if (enumType == null)
                throw new ArgumentNullException("enumType");
            if (!enumType.IsEnum)
                throw new ArgumentException("Type passed must be an enum.", "enumType");

            try
            {
                var result = Enum.Parse(enumType, _input, ignoreCase);
                return !EnumTools.ResultIsValid(enumType, result) ? null : result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T? Parse<T>(bool ignoreCase = true) where T : struct
        {
            T result;
            if (!Enum.TryParse(_input, ignoreCase, out result))
                return null;
            if (!EnumTools.ResultIsValid(typeof(T), result))
                return null;

            return result;
        }
    }
}
