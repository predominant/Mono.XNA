using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class DynamicIndexBuffer : IndexBuffer
    {
        public DynamicIndexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, BufferUsage usage, IndexElementSize elementSize)
			: base (graphicsDevice, sizeInBytes, usage, elementSize)
        {
            throw new NotImplementedException();
        }
        public DynamicIndexBuffer(GraphicsDevice graphicsDevice, Type indexType, int elementCount, BufferUsage usage)
			: base (graphicsDevice, indexType, elementCount, usage)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool flag1)
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options)
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
