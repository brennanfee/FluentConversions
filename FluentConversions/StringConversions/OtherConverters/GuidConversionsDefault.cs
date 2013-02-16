// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidConversionsDefault.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class GuidConversionsDefault
    {
        private readonly string _input;

        internal GuidConversionsDefault(string input)
        {
            _input = input;
        }

        public Guid Parse(Guid defaultValue = default(Guid))
        {
            return GenericStringParser.TryParseDefault(_input, defaultValue, Guid.TryParse);
        }

        public Guid ParseExact(string format = "D", Guid defaultValue = default(Guid))
        {
            Guid result;
            return !Guid.TryParseExact(_input, format, out result) ? defaultValue : result;
        }
    }
}
