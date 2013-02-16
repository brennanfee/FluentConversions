// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericTryParse.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.ConversionDelegates
{
    internal delegate bool GenericTryParse<T>(string value, out T result);
}
