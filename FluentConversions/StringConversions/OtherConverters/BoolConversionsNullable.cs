// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoolConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class BoolConversionsNullable
    {
        private readonly string _input;

        internal BoolConversionsNullable(string input)
        {
            _input = input;
        }

        public bool? Parse()
        {
            return GenericStringParser.TryParseNullable<bool>(_input, bool.TryParse);
        }
    }
}
