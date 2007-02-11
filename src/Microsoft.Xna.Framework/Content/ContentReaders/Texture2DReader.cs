using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    public class Texture2DReader : ContentTypeReader<Texture2D>
    {
        public Texture2DReader()
        {
            // Do nothing
        }

        protected internal override Texture2D Read(ContentReader input, Texture2D existingInstance)
        {
            // Byte 0 is the Mip level by process of elimination. I'm unsure about this
            byte levelOfDetail = input.ReadByte();

            // Byte 1 - 4 is resource usage
            ResourceUsage resourceUsage = (ResourceUsage)input.ReadInt32();

            // Byte 5 - 8 is the resource management type
            ResourceManagementMode resourceManagement = (ResourceManagementMode)input.ReadByte();

            // Byte 9 - 12 is the surface format
            SurfaceFormat surfaceFormat = (SurfaceFormat)input.ReadInt32();

            // Byte 13 - 16 is the width of the texture
            int width = (input.ReadInt32());

            // Byte 17 - 20 is the height of the texture
            int height = (input.ReadInt32());

            // Byte 21 - 24 is the "depth" of the texture
            int levelCount = (input.ReadInt32());

            // Byte 25 - 28 is the data type. I'm assuming this because the only enum with value 4096
            // is the SetDataOptions.NoOverwrite enum. I'm unsure about this.
            SetDataOptions compressionType = (SetDataOptions)input.ReadInt32();

            // There is 1 byte (8 bits) for each colour channel, R, G, B and A
            // The total length of the texture in bytes is then width * height * (1 + 1 + 1 + 1) = width * height * 4
            int imageLength = width * height * 4;

            // I'm not sure what the default colour is, i just choose transparent white. I don't know how to check
            TextureCreationParameters param = new TextureCreationParameters(width, height, levelCount, levelOfDetail, surfaceFormat,
                                                                            resourceUsage, resourceManagement, Color.TransparentWhite,
                                                                            FilterOptions.None, FilterOptions.None);

            return Texture2D.FromFile(input.GraphicsDevice, input.BaseStream, imageLength, param);
        }
    }
}
