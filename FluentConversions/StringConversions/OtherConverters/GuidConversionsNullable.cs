// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidConversionsNullable.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.StringConversions.OtherConverters
{
    public class GuidConversionsNullable
    {
        private readonly string _input;

        internal GuidConversionsNullable(string input)
        {
            _input = input;
        }

        public Guid? Parse()
        {
            return GenericStringParser.TryParseNullable<Guid>(_input, Guid.TryParse);
        }

        public Guid? ParseExact(string format = "D")
        {
            Guid result;
            if (!Guid.TryParseExact(_input, format, out result))
                return null;

            return result;
        }
    }
}
