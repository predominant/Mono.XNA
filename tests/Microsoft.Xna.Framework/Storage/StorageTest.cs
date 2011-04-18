#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Jérémie LAVAL <jeremie.laval@gmail.com>

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
using NUnit.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;
using System.IO;
using System.Text;

namespace Tests.Microsoft.Xna.Framework.Storage
{
	[TestFixture]
	public class StorageTest
	{
		StorageDevice storageDevice;
		StorageContainer storageContainer;
		
		[SetUp]
		public void Setup()
		{
			storageContainer = storageDevice.OpenContainer("StorageDemo");
		}
		
		[TearDown]
		public void Teardown()
		{
			Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar
				+ "SavedGames", true);
		}

        [Test]
        public void OpenContainerTwice()
        {
            
            StorageContainer c1 = storageDevice.OpenContainer("Test");
            StorageContainer c2 = storageDevice.OpenContainer("Test1");
            StorageContainer c3 = storageDevice.OpenContainer("Test");

            Assert.AreNotEqual(c1, c3, "#1");
            Assert.AreNotSame(c1, c3, "#2");
            Assert.AreNotEqual(c1, c2, "#3");
        }
		
		[Test]
		public void TestSpaceValue()
		{
			// if this assertion fail the other fail too
			Assert.IsTrue(storageDevice.IsConnected, "#1");
			
			Assert.IsTrue(storageDevice.FreeSpace > 0, "#2"); // check if there is no problem
			Assert.IsTrue(storageDevice.TotalSpace > 0, "#3");
			
			// not consistent
			Assert.IsTrue(storageDevice.FreeSpace <= storageDevice.TotalSpace, "#4: " + storageDevice.TotalSpace + " " + storageDevice.FreeSpace);
		}
		
		[Test, ExpectedException(typeof(System.ArgumentNullException))]
		public void TestOpenContainerNull()
		{
			// null reference passed
			storageDevice.OpenContainer(null);
		}

		// You must pass in a non-null title name
		[Test, ExpectedException(typeof(System.ArgumentNullException))]
		public void TestOpenContainerEmpty()
		{
			// empty string passed
			storageDevice.OpenContainer(string.Empty);
		}
		
		[Test]
		public void TestDisposed()
		{
			Assert.IsFalse(storageContainer.IsDisposed);
			
			// now we Dispose
			storageContainer.Dispose();
			Assert.IsTrue(storageContainer.IsDisposed);
		}
		
		[Test]
		public void TestDirectoryCreated()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar
				+ "SavedGames";
				
			// the directory has been created
			Assert.IsTrue(Directory.Exists(path));
			
			// the main directory isn't empty
			Assert.IsTrue(Directory.GetDirectories(path).Length > 0);
		}
		
		[Test]
		public void TestContainerStorage()
		{
			// is not null
			Assert.IsTrue(storageContainer.StorageDevice != null);
			
			// is the same that our device
			Assert.IsTrue(storageContainer.StorageDevice == storageDevice);
		}
		
		[Test]
		public void TestContainerTitleName()
		{
			Assert.IsTrue(storageContainer.TitleName != null);
			
			Assert.IsTrue(storageContainer.TitleName == "StorageDemo");
		}
		
		#region Old Code
		/*
		[Test] // After running it on Windows look for the exception produced
		public void TestShowOverflow()
		{
			// Overflow
			StorageDevice.ShowStorageDeviceGuide((PlayerIndex)40);
			StringBuilder path = new StringBuilder(50);
			path.Append(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
			path.Append(Path.DirectorySeparatorChar);
			path.Append("SavedGames");
			path.Append(Path.DirectorySeparatorChar);
			path.Append("StorageDemo");
			path.Append(Path.DirectorySeparatorChar);
			path.Append("Player1");

			Assert.IsTrue(Directory.Exists(path.ToString()));
		}
		
		[Test]
		public void TestAsyncShowOverflow()
		{
			// Overflow
			StorageDevice.BeginShowStorageDeviceGuide((PlayerIndex)40, null, null);
		}
		
		[Test]
		public void TestShowNegative()
		{
			StorageDevice.ShowStorageDeviceGuide((PlayerIndex)(-4));
			StringBuilder path = new StringBuilder(50);
			path.Append(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
			path.Append(Path.DirectorySeparatorChar);
			path.Append("SavedGames");
			path.Append(Path.DirectorySeparatorChar);
			path.Append("StorageDemo");
			path.Append(Path.DirectorySeparatorChar);
			path.Append("Player1");

			Assert.IsTrue(Directory.Exists(path.ToString()));
		}
		
		// It's more a Mono problem
		[Test]
		public void TestAsyncBadResult()
		{
			// a wrong IAsyncResult
			StorageDevice.EndShowStorageDeviceGuide(new System.Runtime.Remoting.Messaging.AsyncResult());
		}
		
		[Test, ExpectedException(typeof(System.ArgumentException))]
		public void TestAsyncNull()
		{
			// Null reference passed
			StorageDevice.EndShowStorageDeviceGuide(null);
		}
		*/
		#endregion Old Code
	}
}


