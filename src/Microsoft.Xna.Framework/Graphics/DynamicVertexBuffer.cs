using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class DynamicVertexBuffer : VertexBuffer
    {
        public DynamicVertexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, BufferUsage usage)
            : base (graphicsDevice, sizeInBytes, usage)
        {
            throw new NotImplementedException();
        }
        
        public DynamicVertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int elementCount, BufferUsage usage)
            : base (graphicsDevice, vertexType, elementCount, usage)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride, SetDataOptions options)
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            throw new NotImplementedException();
        }

        public bool IsContentLost
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

