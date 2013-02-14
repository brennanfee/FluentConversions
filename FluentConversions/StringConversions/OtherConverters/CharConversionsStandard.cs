// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class CharConversionsStandard
    {
        private readonly string _input;

        internal CharConversionsStandard(string input)
        {
            _input = input;
        }

        public char Parse()
        {
            if (_input == null)
            {
                // TODO: Localize
                throw new ArgumentNullException("String is null.", (Exception)null);
            }

            if (_input.Length != 1)
            {
                // TODO: Localize
                throw new FormatException("The length of the string is not 1.");
            }

            return _input[0];
        }
    }
}
