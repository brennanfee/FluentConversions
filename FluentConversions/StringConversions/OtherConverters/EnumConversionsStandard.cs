// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class EnumConversionsStandard
    {
        private readonly string _input;

        internal EnumConversionsStandard(string input)
        {
            _input = input;
        }

        public object ParseByType(Type enumType, bool ignoreCase = true)
        {
            var result = Enum.Parse(enumType, _input, ignoreCase);
            EnumTools.ValidateResult(enumType, result, _input);

            return result;
        }

        public T Parse<T>(bool ignoreCase = true) where T : struct
        {
            var result = (T)Enum.Parse(typeof(T), _input, ignoreCase);
            EnumTools.ValidateResult(typeof(T), result, _input);

            return result;
        }
    }
}
