#region License
/*
MIT License
Copyright © 2011 The Mono.Xna Team

All rights reserved.

Authors: 
 * Lars Magnusson <lavima@gmail.com>

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
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
    
    
    public sealed class ContentWriter : BinaryWriter
    {
		#region Fields
		
		private TargetPlatform targetPlatform;
		
		#endregion Fields
		
		#region Constructor
        
        internal ContentWriter(TargetPlatform targetPlatform, Stream stream)
			: base(prepareStream(targetPlatform, stream))
        {
			this.targetPlatform = targetPlatform;
        }

		#endregion Constructor
        
		#region Properties

        public TargetPlatform TargetPlatform 
        { 
            get { return targetPlatform; }
        }
        
		#endregion Properties
        
		#region Public Methods

        public void Write(Color value)
        {
            Write(value.PackedValue);
        }
        
        public void Write(Matrix value)
        {
            Write(value.M11);
			Write(value.M12);
			Write(value.M13);
			Write(value.M14);
			Write(value.M21);
			Write(value.M22);
			Write(value.M23);
			Write(value.M24);
			Write(value.M31);
			Write(value.M32);
			Write(value.M33);
			Write(value.M34);
			Write(value.M41);
			Write(value.M42);
			Write(value.M43);
			Write(value.M44);
        }
        
        public void Write(Quaternion value)
        {
            Write(value.X);
			Write(value.Y);
			Write(value.Z);
			Write(value.W);
        }
        
        public void Write(Vector2 value)
        {
            Write(value.X);
			Write(value.Y);
        }
        
        public void Write(Vector3 value)
        {
            Write(value.X);
			Write(value.Y);
			Write(value.Z);
        }
        
        public void Write(Vector4 value)
        {
            Write(value.X);
			Write(value.Y);
			Write(value.Z);
			Write(value.W);
        }
        
        public void WriteExternalReference<T>(ExternalReference<T> reference)
        {
            Write(reference.Filename);
        }
        
        public void WriteObject<T>(T value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteObject<T>(T value, ContentTypeWriter typeWriter)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value, ContentTypeWriter typeWriter)
        {
            throw new NotImplementedException();
        }
        
        public void WriteSharedResource<T>(T value)
        {
            throw new NotImplementedException();
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
		
		private static Stream prepareStream(TargetPlatform targetPlatform, Stream output)
		{
			output.WriteByte(0x58);
			output.WriteByte(0x4e);
			output.WriteByte(0x42);
			
			output.WriteByte(getPlatformCode(targetPlatform));
			
			return output;	
		}
		
		private static byte getPlatformCode(TargetPlatform targetPlatform)
		{
			if (targetPlatform == TargetPlatform.Windows)
				return 0x77;
			else if (targetPlatform == TargetPlatform.Xbox360)
				return 0x78;
		}
		
		#endregion Methods	
    }
}
