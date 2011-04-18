#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:
Olivier Dufour (Duff)

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
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tests.Microsoft.Xna.Framework.Graphics
{
    [TestFixture]
    public class ViewportTest
    {
        Viewport v;
        [SetUp]
        public void Setup()
        {
            v.Height = 1;
            v.Width = 1;
            v.X = 0;
            v.Y = 0;
            v.MinDepth = 0;
            v.MaxDepth = 0;
        }

        [Test]
        public void Project()
        {
            Vector3 result = v.Project(new Vector3(1f, 1f, 1f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.AreEqual(new Vector3(1f, 0f, 0f), result, "#1");

            result = v.Project(new Vector3(1f, 2f, 3f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.AreEqual(new Vector3(1f, -0.5f, 0f), result, "#2");

            v.Height = 10;
            v.Width = 20;
            v.X = 30;
            v.Y = 40;
            v.MinDepth = 50;
            v.MaxDepth = 300;

            result = v.Project(new Vector3(1f, 2f, 3f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.AreEqual(new Vector3(50f, 35f, 800f), result, "#3");

            result = v.Project(new Vector3(1f, 2f, 3f), new Matrix(1f,2f,3f,4f,5f,6f,7f,8f,9f,10,11f,12f,13f,14f,15f,16f), Matrix.Identity, Matrix.Identity);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(47.083333814697f,result.X) 
                && TestHelper.ApproximatelyEquals(40.97222f,result.Y)
                && TestHelper.ApproximatelyEquals(275.69446948242f,result.Z), "#4");
        }

        [Test]
        public void UnProject()
        {
            Vector3 result = v.Unproject(new Vector3(1f, 1f, 1f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.AreEqual(new Vector3(1f, -1f, 0f), result, "#1");

            result = v.Unproject(new Vector3(1f, 2f, 3f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.AreEqual(new Vector3(1f, -3f, 0f), result, "#2");

            v.Height = 10;
            v.Width = 20;
            v.X = 30;
            v.Y = 40;
            v.MinDepth = 50;
            v.MaxDepth = 300;

            result = v.Unproject(new Vector3(1f, 2f, 3f), Matrix.Identity, Matrix.Identity, Matrix.Identity);
            Assert.IsTrue(result.X == -3.9f && result.Y == 8.6f && TestHelper.ApproximatelyEquals(-0.18800001490116f, result.Z), "#3");

            //take to have an invertible matrix
            result = v.Unproject(new Vector3(1f, 2f, 3f), new Matrix(10f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10, 11f, 12f, 13f, 14f, 15f, 18f), Matrix.Identity, Matrix.Identity);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(-0.47420474039536f, result.X)
                && TestHelper.ApproximatelyEquals(-2.8871955231628f, result.Y)
                && TestHelper.ApproximatelyEquals(0.5995724f, result.Z), "#4");
        }
	}
}
