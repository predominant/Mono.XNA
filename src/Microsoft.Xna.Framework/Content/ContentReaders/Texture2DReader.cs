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
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    internal class Texture2DReader : ContentTypeReader<Texture2D>
    {
        internal Texture2DReader()
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
 
           // Byte 17 - 20 is the data type. I'm assuming this because the only enum with value 4096
            // is the SetDataOptions.NoOverwrite enum. I'm unsure about this.
             SetDataOptions compressionType = (SetDataOptions)input.ReadInt32();

            // There is 1 byte (8 bits) for each colour channel, R, G, B and A
            // The total length of the texture in bytes is then width * height * (1 + 1 + 1 + 1) = width * height * 4
             int imageLength = width * height * 4;
 
            //Duff: my issue is that here do not know what put on miplevel but the first bytes are in fact from other part of reader
             // I'm not sure what the default colour is, i just choose transparent white. I don't know how to check
            TextureCreationParameters param = new TextureCreationParameters(width, height, levelCount, 0, surfaceFormat,
                                                                            ResourceUsage.None, ResourceManagementMode.Automatic, Color.TransparentWhite,
                                                                             FilterOptions.None, FilterOptions.None);

            return Texture2D.FromFile(input.GraphicsDevice, input.BaseStream, imageLength, param);
        }
    }
}
