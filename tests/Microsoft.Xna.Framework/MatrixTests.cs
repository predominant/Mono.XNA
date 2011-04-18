#region License
/*
MIT License
Copyright © 2010 The MonoXNA Team

All rights reserved.

Authors: 
	* Alan McGovern
	* Lars Magnusson
		

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
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class MatrixTests
    {
		#region Static methods
		
		[Test]
		public void CreateWorld()
		{
			Matrix m1, m2; 
			Vector3 position = Vector3.Zero;
			Vector3 forward = Vector3.Forward;
			Vector3 up = Vector3.Up;
			
			m1 = Matrix.CreateWorld(position, forward, up);
			Matrix.CreateWorld(ref position, ref forward, ref up, out m2);
			
			Assert.AreEqual(TestHelper.Approximate(m1), TestHelper.Approximate(m2), "#1");
			Assert.AreEqual(TestHelper.Approximate(Matrix.Identity), TestHelper.Approximate(m1), "#2");
			
			position = new Vector3(1f, 2f, 3f);
			forward = new Vector3(1f, 1f, 1f);
			up = new Vector3(1f, 1f, 0f);
			
			m1 = Matrix.CreateWorld(position, forward, up);
			Matrix.CreateWorld(ref position, ref forward, ref up, out m2);
			
			Matrix result = new Matrix(-0.7071068f, 0.7071068f, 0f, 0f, 
			                           0.4082483f, 0.4082483f, -0.8164966f, 0f, 
			                           -0.5773503f, -0.5773503f, -0.5773503f, 0f, 
			                           1f, 2f, 3f, 1f);
			
			Assert.AreEqual(TestHelper.Approximate(m1), TestHelper.Approximate(m2), "#3");
			Assert.AreEqual(TestHelper.Approximate(result), TestHelper.Approximate(m1), "#4");			
		}
		
		[Test]
		public void CreateReflection()
		{
			Plane p1 = new Plane(1.0f, 1.0f, 0.75f, -2.0f);
			Matrix m1 = Matrix.CreateReflection(p1);
			Matrix r1 = new Matrix(0.2195122f, -0.7804878f, -0.5853659f, 0f,
     			-0.7804878f, 0.2195122f, -0.5853659f, 0f,
           		-0.5853659f, -0.5853659f, 0.5609756f, 0f,
            	1.560976f, 1.560976f, 1.170732f, 1f);
			
			Plane p2 = new Plane(-0.6667f, 1.225f, -2.3334f, 5.0f);
			Matrix m2 = new Matrix();
			Matrix.CreateReflection(ref p2, out m2);
			Matrix r2 = new Matrix(0.8797032f, 0.2210343f, -0.4210298f, 0f,
            	0.2210343f, 0.5938697f, 0.7736036f, 0f,
            	-0.4210298f, 0.7736036f, -0.4735728f, 0f,
            	0.9021809f, -1.657675f, 3.157566f, 1f);

			Assert.AreEqual(TestHelper.Approximate(r1), TestHelper.Approximate(m1), "#1");
			Assert.AreEqual(TestHelper.Approximate(r2), TestHelper.Approximate(m2), "#2");
		}
		
		[Test]
		public void CreateShadow()
		{
			Vector3 v1 = new Vector3(1.5f, 1.0f, 0.5f);
			Plane p1 = new Plane(1.0f, 5.0f, 2.5f, 1.0f);
			Matrix m1 = Matrix.CreateShadow(v1, p1);
			Matrix r1 = new Matrix(1.100564f, -0.1760902f, -0.08804509f, 0f,
			-1.320676f, 0.484248f, -0.4402255f, 0f,
			-0.6603382f, -0.4402255f, 1.144586f, 0f,
			-0.2641353f, -0.1760902f, -0.08804509f, 1.364699f);
			
			Vector3 v2 = new Vector3(0.5f, 1.25f, 2.75f);
			Plane p2 = new Plane(2.0f, 1.75f, 2.75f, 4.75f);
			Matrix m2 = new Matrix();
			Matrix.CreateShadow(ref v2, ref p2, out m2);
			Matrix r2 = new Matrix(2.54951f, -0.6537205f, -1.438185f, 0f,
			-0.2288022f, 2.238993f, -1.258412f, 0f,
			-0.3595463f, -0.8988657f, 0.8334937f, 0f,
			-0.6210345f, -1.552586f, -3.41569f, 2.810998f);

			Assert.AreEqual(TestHelper.Approximate(r1), TestHelper.Approximate(m1), "#1");
			Assert.AreEqual(TestHelper.Approximate(r2), TestHelper.Approximate(m2), "#2");
		}
		
		[Test]
		public void CreateShadow2()
		{			
			Vector3 v1 = new Vector3(10.0f, 10.0f, 10.0f);
			Plane p1 = new Plane(1.0f, 5.0f, 2.5f, 1.0f);
			Matrix m1 = Matrix.CreateShadow(v1, p1);
			Matrix r1 = new Matrix(13.20676f, -1.760902f, -1.760902f, 0f,
            -8.804509f, 6.163157f, -8.804509f, 0f,
            -4.402255f, -4.402255f, 10.56541f, 0f,
            -1.760902f, -1.760902f, -1.760902f, 14.96767f);
			
			Vector3 v2 = new Vector3(-10f, -10f, -10f);
			Plane p2 = new Plane(2.0f, 1.75f, 2.75f, 4.75f);
			Matrix m2 = new Matrix();
			Matrix.CreateShadow(ref v2, ref p2, out m2);
			Matrix r2 = new Matrix(-11.76697f, 5.229764f, 5.229764f, 0f,
            4.576044f, -12.42069f, 4.576044f, 0f,
            7.190926f, 7.190926f, -9.805807f, 0f,
            12.42069f, 12.42069f, 12.42069f, -16.99673f);

			Assert.AreEqual(TestHelper.Approximate(r1), TestHelper.Approximate(m1), "#1");
			Assert.AreEqual(TestHelper.Approximate(r2), TestHelper.Approximate(m2), "#2");
		}
		
		[Test]
		public void CreateFromQuaternion()
		{
			Quaternion qu1 = new Quaternion(1.0f, 0.5f, 0.0f, -1.0f);
            Matrix mx1 = new Matrix();
            mx1 = Matrix.CreateFromQuaternion(qu1);
			Matrix res1 = new Matrix(0.5f, 1f, 1f, 0f,
			                         1f, -1f,-2f, 0f,
			                         -1f, 2f, -1.5f, 0f,
			                         0f, 0f, 0f, 1f);

			Quaternion qu2 = new Quaternion (0.0f, -1.0f, 1.0f, 0.0f);
            Matrix mx2 = new Matrix();
            Matrix.CreateFromQuaternion (ref qu2, out mx2);
			Matrix res2 = new Matrix(-3f, 0f, 0f, 0f,
			                         0f, -1f, -2f, 0f,
			                         0f, -2f, -1f, 0f,
			                         0f, 0f, 0f, 1f);
			
			Assert.AreEqual(TestHelper.Approximate(res1), TestHelper.Approximate(mx1), "#1");
			Assert.AreEqual(TestHelper.Approximate(res2), TestHelper.Approximate(mx2), "#2");
		}
		
		[Test]
		public void CreateLookAt()
		{
            Vector3 v01 = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 v02 = new Vector3(1.0f, 1.0f, 0.0f);
            Vector3 v03 = new Vector3(0.0f, -1.0f, 1.0f);
            Matrix mx1 = new Matrix();
            mx1 = Matrix.CreateLookAt(v01, v02, v03);
			Matrix res1 = new Matrix(0.5773503f, 0.4082483f, -0.7071068f, 0f,
			                         -0.5773503f, -0.4082483f, -0.7071068f, 0f,
			                         -0.5773503f, 0.8164966f, 0f, 0f,
			                         0f, 0f, 0f, 1f);

            Vector3 v04 = new Vector3(1.0f, 0.0f, 1.0f);
            Vector3 v05 = new Vector3(-0.5f, -0.5f, 0.0f);
            Vector3 v06 = new Vector3(-1.0f, 1.0f, 1.0f);
            Matrix mx2 = new Matrix();
            Matrix.CreateLookAt(ref v04, ref v05, ref v06, out mx2);
			Matrix res2 = new Matrix(0.1543033f, -0.5773502f, 0.8017837f, 0f,
			                         0.7715167f, 0.5773502f, 0.2672612f, 0f,
			                         -0.6172134f, 0.5773502f, 0.5345225f, 0f,
			                         0.46291f, 0f, -1.336306f, 1f);
			
			Assert.AreEqual(TestHelper.Approximate(res1), TestHelper.Approximate(mx1), "#1");
			Assert.AreEqual(TestHelper.Approximate(res2), TestHelper.Approximate(mx2), "#2");
		}
		
		[Test]
		public void CreateOrthographic()
		{
			Matrix mx1 = Matrix.CreateOrthographic(800.0f, 400.0f, 8.0f, 10.0f);
			Matrix res1 = new Matrix(0.0025f, 0f, 0f, 0f,
			                         0f, 0.005f, 0f, 0f,
			                         0f, 0f, -0.5f, 0f,
			                         0f, 0f, -4.0f, 1.0f);
			
			Matrix mx2 = new Matrix(-1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f);
			Matrix.CreateOrthographic(800.0f, 400.0f, 8.0f, 10.0f, out mx2);
			Matrix res2 = res1;
			
			//Console.WriteLine(mx1.M33.ToString("f"));
			//Console.WriteLine(res1.M33.ToString("f"));
			Assert.AreEqual(TestHelper.Approximate(res1), TestHelper.Approximate(mx1), "#1");
			Assert.AreEqual(TestHelper.Approximate(res2), TestHelper.Approximate(mx2), "#2");
		}
		
		[Test]
		public void CreateOrthographicOffCenter()
		{
			Matrix mx1 = Matrix.CreateOrthographicOffCenter(200.0f, 100.0f, 1000.0f, 500.0f, 8.0f, 10.0f);
			Matrix res1 = new Matrix(-0.02f, 0f, 0f, 0f,
			                         0f, -0.004f, 0f, 0f,
			                         0f, 0f, -0.5f, 0f,
			                         3f, 3f, -4.0f, 1.0f);
			
			Matrix mx2 = new Matrix(-1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f,
			                        -1.0f, -1.0f, -1.0f, -1.0f);
			Matrix.CreateOrthographicOffCenter(200.0f, 100.0f, 1000.0f, 500.0f, 8.0f, 10.0f, out mx2);
			Matrix res2 = res1;
			
			Assert.AreEqual(TestHelper.Approximate(res1), TestHelper.Approximate(mx1), "#1");
			Assert.AreEqual(TestHelper.Approximate(res2), TestHelper.Approximate(mx2), "#2");
		}
		
		[Test]
		public void CreatePerspectiveFieldOfView()
		{	
            Matrix mx1 = new Matrix();
            mx1 = Matrix.CreatePerspectiveFieldOfView(2.0f, 1.2f, 0.5f, 5.0f);
			Matrix res1 = new Matrix(0.5350772f, 0f, 0f, 0f,
			                         0f, 0.6420926f, 0f, 0f,
			                         0f, 0f, -1.111111f, -1f,
			                         0f, 0f, -0.5555556f, 0f);

            Matrix mx2 = new Matrix();
            Matrix.CreatePerspectiveFieldOfView(0.5f, 1.0f, 0.5f, 1.0f, out mx2);
			Matrix res2 = new Matrix(3.916317f, 0f, 0f, 0f,
			                         0f, 3.916317f, 0f, 0f,
			                         0f, 0f, -2f, -1f,
			                         0f, 0f, -1f, 0f);
			
			Assert.AreEqual(TestHelper.Approximate(res1), TestHelper.Approximate(mx1), "#1");
			Assert.AreEqual(TestHelper.Approximate(res2), TestHelper.Approximate(mx2), "#2");
		}
		
		[Test,ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage="fieldOfView takes a value between 0 and Pi (180 degrees) in radians.", Handler="fieldOfView", MatchType=MessageMatch.Contains)]
		public void CreatePerspectiveFieldOfViewFieldOfViewException1()
		{
			Matrix mx1 = new Matrix();
			mx1 = Matrix.CreatePerspectiveFieldOfView(-0.1f, 1.2f, 0.5f, 5.0f);
		}

		[Test,ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage="fieldOfView takes a value between 0 and Pi (180 degrees) in radians.", Handler="fieldOfView", MatchType=MessageMatch.Contains)]
		public void CreatePerspectiveFieldOfViewFieldOfViewException2()
		{
			Matrix mx1 = new Matrix();
			mx1 = Matrix.CreatePerspectiveFieldOfView(3.14159263f, 1.2f, 0.5f, 5.0f);
		}

		public void fieldOfView(Exception ex)
		{
			Assert.AreEqual("fieldOfView", ((ArgumentOutOfRangeException)ex).ParamName);
		}

		[Test,ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage="You should specify positive value for nearPlaneDistance.", Handler="nearPlaneDistance", MatchType=MessageMatch.Contains)]
		public void CreatePerspectiveFieldOfViewNearPlaneException()
		{
			Matrix mx1 = new Matrix();
			mx1 = Matrix.CreatePerspectiveFieldOfView(3.14159262f, 1.2f, -0.5f, 5.0f);
		}
		
		public void nearPlaneDistance(Exception ex)
		{
			Assert.AreEqual("nearPlaneDistance", ((ArgumentOutOfRangeException)ex).ParamName);
		}
		
		[Test,ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage="You should specify positive value for farPlaneDistance.", Handler="farPlaneDistance", MatchType=MessageMatch.Contains)]
		public void CreatePerspectiveFieldOfViewFarPlaneException()
		{
			Matrix mx1 = new Matrix();
			mx1 = Matrix.CreatePerspectiveFieldOfView(3.14159262f, 1.2f, 0.5f, -5.0f);
		}
		
		public void farPlaneDistance(Exception ex)
		{
			Assert.AreEqual("farPlaneDistance", ((ArgumentOutOfRangeException)ex).ParamName);
		}

		[Test,ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage="Near plane distance is larger than Far plane distance. Near plane distance must be smaller than Far plane distance.", Handler="nearfarPlaneDistance", MatchType=MessageMatch.Contains)]
		public void CreatePerspectiveFieldOfViewNearFarPlaneException()
		{
			Matrix mx1 = new Matrix();
			mx1 = Matrix.CreatePerspectiveFieldOfView(3.14159262f, 1.2f, 2.5f, 1.0f);
		}
		
		public void nearfarPlaneDistance(Exception ex)
		{
			Assert.AreEqual("nearPlaneDistance", ((ArgumentOutOfRangeException)ex).ParamName);
		}
		
		[Test]
		public void Transform()
		{
			Quaternion q1 = new Quaternion(5.0f, 3.75f, -5.0f, 2.5f);
			Matrix m1 = new Matrix(1.0f, 2.0f, 3.0f, 4.0f,
				0.5f, -1.0f, -1.0f, 3.75f,
				3.0f, 3.0f, 1.0f, 2.0f,
				4.25f, -3.0f, 1.25f, 1f);
			Matrix r1 = Matrix.Transform(m1, q1);
			Matrix e1 = new Matrix(-45.875f, -373f, -325.125f, 4f,
				-69.8125f, 167.75f, 55.25f, 3.75f,
				-75.125f, -322f, -320.875f, 2f,
				-554.3438f, 272f, -351.0938f, 1f);
			
			Matrix r2;
			Quaternion q2 = new Quaternion(1.0f, 1.0f, 0f, 4.25f);
			Matrix m2 = new Matrix(3.5f, 2.5f, 3.75f, 2.75f,
				1.0f, 1.0f, 2.0f, 4.25f,
				-1.0f, -1.0f, 2.0f, 3.75f,
				1.0f, 4.75f, 5.0f, 1f);
			Matrix.Transform(ref m2, ref q2, out r2);
			Matrix e2 = new Matrix(33.375f, -27.375f, -19.75f, 2.75f,
				18f, -16f, -6f, 4.25f,
				16f, -18f, -6f, 3.75f,
				51f, -45.25f, 16.875f, 1f);

			Assert.AreEqual(TestHelper.Approximate(e1), TestHelper.Approximate(r1), "#1");
			Assert.AreEqual(TestHelper.Approximate(e2), TestHelper.Approximate(r2), "#2");
		}
		
		[Test]
		public void Decompose()
		{
			Matrix m01 = new Matrix(1f, 1f, 1f, 1f, -0.5f, 2.25f, 3.5f, 2f, 1f, -0.5f, -2f, 3.75f, 0, 3.5f, 2f, 1f);
			Vector3 s01 = new Vector3();
			Vector3 t01 = new Vector3();
			Quaternion q01 = new Quaternion();
			bool d01 = m01.Decompose(out s01, out q01, out t01);
			Vector3 s02 = new Vector3(1.732051f, -4.190763f, 2.291288f);
			Vector3 t02 = new Vector3(0f, 3.5f, 2f);
			Quaternion q02 = new Quaternion(0f, 0f, 0f, 1f);
			bool d02 = false;

			Matrix tmp01 = Matrix.CreateFromQuaternion(new Quaternion(3f, 0, 0, -4f));
			Matrix tmp02 = Matrix.CreateTranslation(5.25f, 3.336f, -2.95f);
			Matrix tmp03 = Matrix.CreateScale(2.5f);
			Matrix m11 = Matrix.Multiply(tmp01, tmp02);
			m11 = Matrix.Multiply(m11, tmp03);
			Vector3 s11 = new Vector3();
			Vector3 t11 = new Vector3();
			Quaternion q11 = new Quaternion();
			bool d11 = m11.Decompose(out s11, out q11, out t11);
			Vector3 s12 = new Vector3(2.5f, 73.52721f, 73.52721f);
			Vector3 t12 = new Vector3(13.125f, 8.34f, -7.375f);
			Quaternion q12 = new Quaternion(0.8882616f, 0f,0f, -0.4593379f);
			bool d12 = true;

			Assert.AreEqual(TestHelper.Approximate(s02), TestHelper.Approximate(s01), "#1");
			Assert.AreEqual(TestHelper.Approximate(t02), TestHelper.Approximate(t01), "#2");
			Assert.AreEqual(TestHelper.Approximate(q02), TestHelper.Approximate(q01), "#3");
			Assert.AreEqual(d02, d01, "#4");
			Assert.AreEqual(TestHelper.Approximate(s12), TestHelper.Approximate(s11), "#5");
			Assert.AreEqual(TestHelper.Approximate(t12), TestHelper.Approximate(t11), "#6");
			Assert.AreEqual(TestHelper.Approximate(q12), TestHelper.Approximate(q11), "#7");
			Assert.AreEqual(d12, d11, "#8");						
		}
		
		#endregion Static methods
		
        #region Instance methods
		
        [Test]
        public void Add()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Matrix n = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            Matrix expected = new Matrix(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10);

            m = m + n;
            Assert.AreEqual(expected, m, "#1");
            Assert.AreEqual(n, new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8), "test 1");

            m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            m = Matrix.Add(m, n);
            Assert.AreEqual(expected, m, "test 2");

            m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Matrix outResult;
            Matrix.Add(ref m, ref n, out outResult);
            Assert.AreEqual(expected, outResult, "Test 3");
        }


        [Test]
        public void Backward()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Backward = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 100, 200, 300, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Determinant()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Assert.AreEqual(0, m.Determinant(), "#1");

            m = new Matrix(1, 2, 3, 2.665f, 3, 2, 31.43234f, 3, 6, 4, 2, 6, 3, 6, 532, 3);

			//Assert.AreEqual(TestHelper.Approximate(-1216.07629f), TestHelper.Approximate(m.Determinant()), "#2");
			Assert.AreEqual(-1216.07629f, m.Determinant(), "#2");
        }


        [Test]
        public void Down()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Down = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, -100, -200, -300, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Forward()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Forward = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, -100, -200, -300, 4, 5, 6, 7, 8);
            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Left()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Left = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(-100, -200, -300, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Right()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Right = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(100, 200, 300, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void ToStringTest()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            string expected = "{ {M11:1 M12:2 M13:3 M14:4} {M21:5 M22:6 M23:7 M24:8} {M31:9 M32:8 M33:7 M34:6} {M41:5 M42:4 M43:3 M44:2} }";
            Assert.AreEqual(expected, m.ToString());

        }


        [Test]
        public void Translation()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Translation = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 100, 200, 300, 8);
            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Up()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Up = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 100, 200, 300, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }
		
		[Test()]
		public void Invert()
		{
			Matrix test1 = Matrix.Invert(Matrix.Identity);
			Matrix expected1 = Matrix.Identity;
			
            Matrix test2 = Matrix.Invert(new Matrix(1f, 0f, 0f, 2f, 0f, 1f, 3f, 0f, 4f, 0f, 1f, 0f, 0f, 0f, 0f, 1f));			
            Matrix expected2 = new Matrix(1f, 0f, 0f, -2f, 12f, 1f, -3f, -24f, -4f, 0f, 1f, 8f, 0f, 0f, 0f, 1f);
			
			Matrix test3 = Matrix.Invert(new Matrix(1, 2, 3, 2.665f, 3, 2, 31.43234f, 3, 6, 4, 2, 6, 3, 6, 532, 3));
			Matrix expected3 = new Matrix(-0.6006006f, -0.5434364f, 0.5217183f, 0.03353353f, 0f, -4.362136f, 2.056068f,  0.25f, 0f, 0.03285978f, -0.01642989f, 0f, 0.6006006f, 3.440574f, -1.720287f, -0.2002002f);
			
			Assert.AreEqual(expected1, test1, "#1 Identity");
			Assert.AreEqual(expected2, test2, "#2 Non-orthogonal");
			Assert.AreEqual(TestHelper.Approximate(expected3), TestHelper.Approximate(test3), "#3 Non-orthogonal");
		}
		
        #endregion Instance methods
    }
}
