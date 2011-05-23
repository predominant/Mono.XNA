#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.
 
Authors:
 * Tim Pambor

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
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
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Readers
{
    internal class Texture2DReader : ContentTypeReader<Texture2D>
    {
        public Texture2DReader()
        {
            // Do nothing
        }

        protected internal override Texture2D Read(ContentReader input, Texture2D existingInstance)
        {
            // Byte 1 - 4 is the surface format
             SurfaceFormat surfaceFormat = (SurfaceFormat)input.ReadInt32();
 
            // Byte 5 - 8 is the width of the texture
             int width = (input.ReadInt32());
           
            // Byte 9 - 12 is the height of the texture
             int height = (input.ReadInt32());
 
            // Byte 13 - 16 is the "depth" of the texture
             int levelCount = (input.ReadInt32());

             Texture2D texture = new Texture2D(input.GraphicsDevice, width, height, levelCount, TextureUsage.None, surfaceFormat);

            for (int i = 0; i < levelCount; i++)
            {
                // Byte 17 -  20 is the Length of the texture
                int imageLength = input.ReadInt32();
                byte[] data = input.ReadBytes(imageLength);
                Rectangle? rect = null;
                texture.SetData<byte>(i, rect, data, 0, data.Length, SetDataOptions.None);
            }
            return texture;
        }
    }
}
