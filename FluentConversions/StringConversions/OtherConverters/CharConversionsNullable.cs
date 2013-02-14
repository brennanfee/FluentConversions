// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class CharConversionsNullable
    {
        private readonly string _input;

        internal CharConversionsNullable(string input)
        {
            _input = input;
        }

        public char? Parse()
        {
            return GenericStringParser.TryParseNullable<char>(_input, char.TryParse);
        }
    }
}
