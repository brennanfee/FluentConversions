// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoolConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class BoolConversionsDefault
    {
        private readonly string _input;

        internal BoolConversionsDefault(string input)
        {
            _input = input;
        }

        public bool Parse(bool defaultValue = default(bool))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, bool.TryParse);
        }
    }
}
