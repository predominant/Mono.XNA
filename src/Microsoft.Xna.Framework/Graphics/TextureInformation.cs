#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
 * Rob Loach

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
using System.Globalization;

namespace Microsoft.Xna.Framework.Graphics
{
    [Serializable]
    public struct TextureInformation
    {
        #region Constructors
        public TextureInformation(int width, int height, int depth, int mipLevels, SurfaceFormat format)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.surfaceFormat = format;
            this.resourcetype = ResourceType.Texture2D;
            this.imageFormat = ImageFileFormat.Jpg;
        }
        #endregion Constructors


        #region Operators
        public static bool operator !=(TextureInformation left, TextureInformation right)
        {
            return !(left == right);
        }

        public static bool operator ==(TextureInformation left, TextureInformation right)
        {
            return (left.depth == right.depth) &&
                (left.height == right.height) &&
                (left.imageFormat == right.imageFormat) &&
                (left.mipLevels == right.mipLevels) &&
                (left.resourcetype == right.resourcetype) &&
                (left.surfaceFormat == right.surfaceFormat) &&
                (left.width == right.width);
        }
        #endregion Operators


        #region Properties
        public int Depth { get { return depth; } set { depth = value; } }

        public SurfaceFormat Format { get { return surfaceFormat; } set { surfaceFormat = value; } }

        public int Height { get { return height; } set { height = value; } }

        public ImageFileFormat ImageFormat { get { return imageFormat; } }

        public int MipLevels { get { return mipLevels; } set { mipLevels = value; } }

        public ResourceType ResourceType { get { return resourcetype; } }

        public int Width { get { return width; } set { width = value; } }
        #endregion Properties


        #region Methods
        public override bool Equals(object obj)
        {
            return obj is TextureInformation && this == (TextureInformation)obj;
        }

        public override int GetHashCode()
        {
            return (this.depth.GetHashCode() ^
                    this.height.GetHashCode() ^
                    this.imageFormat.GetHashCode() ^
                    this.mipLevels.GetHashCode() ^
                    this.resourcetype.GetHashCode() ^
                    this.surfaceFormat.GetHashCode() ^
                    this.width.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Width:{0} Height:{1} Format:{2} Depth:{3} MipLevels:{4}}}", new object[] { this.width, this.height, this.surfaceFormat.ToString(), this.depth, this.mipLevels });
        }
        #endregion Methods


        #region Fields
        private int width, height, depth, mipLevels;
        private SurfaceFormat surfaceFormat;
        internal ResourceType resourcetype;
        internal ImageFileFormat imageFormat;
        #endregion Fields
    }
}
