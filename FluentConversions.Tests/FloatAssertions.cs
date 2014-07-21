// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloatAssertions.cs" company="Brennan A. Fee">
//   Copyright (c) 2013 Brennan A. Fee. All Rights Reserved.  See License.txt in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace FluentConversions.Tests
{
    public static class FloatAssertions
    {
        public static bool AlmostEqual(float first, float second, int maxDeltaBits = 1000)
        {
            // Uses 2s compliment method
            var firstAsInt = BitConverter.ToInt32(BitConverter.GetBytes(first), 0);
            if (firstAsInt < 0)
                firstAsInt = int.MinValue - firstAsInt;

            var secondAsInt = BitConverter.ToInt32(BitConverter.GetBytes(second), 0);
            if (secondAsInt < 0)
                secondAsInt = int.MinValue - secondAsInt;

            var intDiff = Math.Abs(firstAsInt - secondAsInt);
            return intDiff <= (1 << maxDeltaBits);
        }

        public static bool AlmostEqual(double first, double second, int maxDeltaBits = 1000)
        {
            // Uses 2s compliment method
            var firstAsInt = BitConverter.ToInt32(BitConverter.GetBytes(first), 0);
            if (firstAsInt < 0)
                firstAsInt = int.MinValue - firstAsInt;

            var secondAsInt = BitConverter.ToInt32(BitConverter.GetBytes(second), 0);
            if (secondAsInt < 0)
                secondAsInt = int.MinValue - secondAsInt;

            var intDiff = Math.Abs(firstAsInt - secondAsInt);
            return intDiff <= (1 << maxDeltaBits);
        }
    }
}
