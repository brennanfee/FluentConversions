// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericTryParse.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.ConversionDelegates
{
    using System;
    using System.Linq;

    internal delegate bool GenericTryParse<T>(string value, out T result);
}
