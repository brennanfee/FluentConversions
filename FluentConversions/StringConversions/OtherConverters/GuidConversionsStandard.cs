// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidConversionsStandard.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class GuidConversionsStandard
    {
        private readonly string _input;

        internal GuidConversionsStandard(string input)
        {
            _input = input;
        }

        public Guid Parse()
        {
            return GenericStringParser.Parse(_input, Guid.Parse);
        }

        public Guid ParseExact(string format = "D")
        {
            return Guid.ParseExact(_input, format);
        }
    }
}
