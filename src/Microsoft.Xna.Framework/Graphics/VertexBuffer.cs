#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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

namespace Microsoft.Xna.Framework.Graphics
{
    public class VertexBuffer : GraphicsResource
    {
        public VertexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, ResourceUsage usage) { throw new NotImplementedException(); }

        public VertexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, ResourceUsage usage, ResourceManagementMode resourceManagementMode) { throw new NotImplementedException(); }

        public VertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int elementCount, ResourceUsage usage) { throw new NotImplementedException(); }

        public VertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int elementCount, ResourceUsage usage, ResourceManagementMode resourceManagementMode) { throw new NotImplementedException(); }

        public static bool operator !=(VertexBuffer left, VertexBuffer right) { throw new NotImplementedException(); }

        public static bool operator ==(VertexBuffer left, VertexBuffer right) { throw new NotImplementedException(); }

        public ResourceManagementMode ResourceManagementMode { get { throw new NotImplementedException(); } }

        public ResourceUsage ResourceUsage { get { throw new NotImplementedException(); } }

        public int SizeInBytes { get { throw new NotImplementedException(); } }

        protected override void Dispose(bool disposing) { throw new NotImplementedException(); }

        public override bool Equals(object obj) { throw new NotImplementedException(); }

        public void GetData<T>(T[] data) { throw new NotImplementedException(); }

        public void GetData<T>(T[] data, int startIndex, int elementCount) { throw new NotImplementedException(); }

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) { throw new NotImplementedException(); }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public void SetData<T>(T[] data) { throw new NotImplementedException(); }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options) { throw new NotImplementedException(); }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride, SetDataOptions options) { throw new NotImplementedException(); }
    }

    public enum VertexElementFormat
    {
        Single = 0,
        Vector2 = 1,
        Vector3 = 2,
        Vector4 = 3,
        Color = 4,
        Byte4 = 5,
        Short2 = 6,
        Short4 = 7,
        Rgba32 = 8,
        NormalizedShort2 = 9,
        NormalizedShort4 = 10,
        Rg32 = 11,
        Rgba64 = 12,
        UInt101010 = 13,
        Normalized101010 = 14,
        HalfVector2 = 15,
        HalfVector4 = 16,
        Unused = 17,
    }

    public enum VertexElementMethod
    {
        Default = 0,
        UV = 4,
        LookUp = 5,
        LookUpPresampled = 6,
    }

    public enum VertexElementUsage
    {
        Position = 0,
        BlendWeight = 1,
        BlendIndices = 2,
        Normal = 3,
        PointSize = 4,
        TextureCoordinate = 5,
        Tangent = 6,
        Binormal = 7,
        TessellateFactor = 8,
        Color = 10,
        Fog = 11,
        Depth = 12,
        Sample = 13,
    }

}
