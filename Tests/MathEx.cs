/*
* Complex.NET
* https://github.com/ZenLulz/Complex.NET
*
* Copyright 2013 ZenLulz ~ Jämes Ménétrey
* Released under the MIT license
*
* Date: 2013-05-29
*/

using System;

namespace Tests
{
    public static class MathEx
    {
        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }
    }
}
