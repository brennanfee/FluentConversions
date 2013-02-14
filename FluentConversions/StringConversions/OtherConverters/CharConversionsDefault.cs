// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class CharConversionsDefault
    {
        private readonly string _input;

        internal CharConversionsDefault(string input)
        {
            _input = input;
        }

        public char Parse(char defaultValue = default(char))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, char.TryParse);
        }
    }
}
