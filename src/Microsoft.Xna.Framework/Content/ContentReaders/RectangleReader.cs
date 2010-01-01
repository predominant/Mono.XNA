using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class RectangleReader : ContentTypeReader<Rectangle>
    {

        public RectangleReader()
        {
        }

        protected internal override Rectangle Read(ContentReader input, Rectangle existingInstance)
        {
            Rectangle rectangle;
            rectangle.X = input.ReadInt32();
            rectangle.Y = input.ReadInt32();
            rectangle.Width = input.ReadInt32();
            rectangle.Height = input.ReadInt32();
            return rectangle;
        }
    }
}
