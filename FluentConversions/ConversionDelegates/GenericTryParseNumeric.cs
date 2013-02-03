﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericTryParseNumeric.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace FluentConversions.ConversionDelegates
{
    using System;
    using System.Globalization;
    using System.Linq;

    internal delegate bool GenericTryParseNumeric<T>(string value, NumberStyles style, IFormatProvider provider, out T result);
}
