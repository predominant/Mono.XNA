#region License
/*
MIT License
Copyright © 2010 The MonoXNA Team

All rights reserved.

Authors: 
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
using Microsoft.Xna.Framework.Design;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework.Design
{
	public class Vector3ConverterTests
	{
		#region Fields
			
		private Vector3Converter converter;
		
		#endregion Fields
		
		#region NUnit Setup
		
		[SetUp]
        public void Setup()
        {
			converter = new Vector3Converter();
		}
		
		#endregion NUnit Setup
		
		#region NUnit Public Methods Tests
		
		[Test]
		public void ConvertTo()
		{
			
		}
		
		[Test]
		public void ConvertFrom()
		{
			
		}
		
		[Test]
		public void CreateInstance()
		{
			
		}
		
		#endregion NUnit Public Methods Tests
	}
}

