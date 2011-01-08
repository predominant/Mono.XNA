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
using System.IO;
using Tao.DevIl;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{

    public abstract class Texture : GraphicsResource
    {
        //public static bool operator !=(Texture left, Texture right) { throw new NotImplementedException(); }

        //public static bool operator ==(Texture left, Texture right) { throw new NotImplementedException(); }


        public int LevelCount { get { throw new NotImplementedException(); } }

        public int LevelOfDetail { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public static Texture FromFile(GraphicsDevice graphicsDevice, Stream textureStream) { throw new NotImplementedException(); }

        public static Texture FromFile(GraphicsDevice graphicsDevice, string filename) { throw new NotImplementedException(); }

        public static Texture FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes) { throw new NotImplementedException(); }

        public static Texture FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters) { throw new NotImplementedException(); }

        public static Texture FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters) {
            TextureInformation texinfo = GetTextureInformation(filename);
            if (creationParameters.Width == 0) creationParameters.Width = texinfo.Width;
            if (creationParameters.Height == 0) creationParameters.Height = texinfo.Height;
            if (creationParameters.Depth == 0) creationParameters.Depth = texinfo.Depth;
            if (texinfo.ResourceType == ResourceType.Texture2D)
            {
                int ImgID;
                Il.ilGenImages(1, out ImgID);
                Il.ilBindImage(ImgID);
                Il.ilLoadImage(filename);
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                int depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
                int size = Il.ilGetInteger(Il.IL_IMAGE_SIZE_OF_DATA);
                Texture2D tex = new Texture2D(graphicsDevice, creationParameters.Width, creationParameters.Height, creationParameters.Depth, TextureUsage.None, SurfaceFormat.Rgb32);
                
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, tex.textureId);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Il.ilGetInteger(Il.IL_IMAGE_BYTES_PER_PIXEL), creationParameters.Width, creationParameters.Height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, Il.ilGetData());
                
                Il.ilBindImage(0);
                return tex;
            }
            else if (texinfo.ResourceType == ResourceType.Texture3D) { throw new NotImplementedException(); }
            else if (texinfo.ResourceType == ResourceType.Texture3DVolume) { throw new NotImplementedException(); } //FIXME: Should we handle this here too?
            else if (texinfo.ResourceType == ResourceType.TextureCube) { throw new NotImplementedException(); }
            else return null;
        }

        public static Texture FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, TextureCreationParameters creationParameters) { throw new NotImplementedException(); }

        public static Texture FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height, int depth) { throw new NotImplementedException(); }

        public void GenerateMipMaps(TextureFilter filterType) { throw new NotImplementedException(); }

        public static TextureCreationParameters GetCreationParameters(GraphicsDevice graphicsDevice, Stream textureStream) { throw new NotImplementedException(); }

        public static TextureCreationParameters GetCreationParameters(GraphicsDevice graphicsDevice, string filename) { throw new NotImplementedException(); }

        public static TextureCreationParameters GetCreationParameters(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes) { throw new NotImplementedException(); }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public static TextureInformation GetTextureInformation(Stream textureStream) { throw new NotImplementedException(); }

        public static TextureInformation GetTextureInformation(string filename) {
            FileStream FS = null;
            try
            {
                FS = File.OpenRead(filename);
            }
            finally
            {
                if (FS != null) FS.Close();
            }
            TextureInformation TexInfo = new TextureInformation();
            TexInfo.Depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
            TexInfo.Format = SurfaceFormat.Color; //TODO: Set properly.
            TexInfo.Height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            TexInfo.imageFormat = ILimageformat2XNAimageformat(Il.ilGetInteger(Il.IL_IMAGE_FORMAT));
            TexInfo.resourcetype = ResourceType.Texture2D; //TODO: Find out how to detect and set properly.
            TexInfo.Width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            return TexInfo;
        }

        private static ImageFileFormat ILimageformat2XNAimageformat(int ILFormat)
        {
            throw new NotImplementedException();
        }

        public static TextureInformation GetTextureInformation(Stream textureStream, int numberBytes) { throw new NotImplementedException(); }

        public void Save(string filename, ImageFileFormat format) { throw new NotImplementedException(); }

    }
}
