#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework
{
    public static class MathHelper
    {
        public const float E = (float)Math.E;
        public const float Log10E = 0.4342945f;
        public const float Log2E = 1.442695f;
        public const float Pi = (float)Math.PI;
        public const float PiOver2 = (float)(Math.PI / 2.0);
        public const float PiOver4 = (float)(Math.PI / 4.0);
        public const float TwoPi = (float)(Math.PI * 2.0);
        
        public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }

        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            throw new NotImplementedException();
        }

        public static float Clamp(float value, float min, float max)
        {
            // First we check to see if we're greater than the max
            value = (value > max) ? max : value;

            // Then we check to see if we're less than the min.
            value = (value < min) ? min : value;

            // There's no check to see if min > max.
            return value;
        }
        
        public static float Distance(float value1, float value2)
        {
            return Math.Abs(value1 - value2);
        }
        
        public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            throw new NotImplementedException();
        }
        
        
        public static float Lerp(float value1, float value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static float Max(float value1, float value2)
        {
            return Math.Max(value1, value2);
        }
        
        public static float Min(float value1, float value2)
        {
            return Math.Min(value1, value2);
        }
        
        public static float SmoothStep(float value1, float value2, float amount)
        {
            throw new NotImplementedException();
        }
        
        public static float ToDegrees(float radians)
        {
            return (radians * 57.29578f);
        }
        
        public static float ToRadians(float degrees)
        {
            return (degrees * 0.01745329f);
        }
    }
}
