using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    [Flags]
    public enum TextureUsage
    {
        AutoGenerateMipMap = 0x400,
        Linear = 0x40000000,
        None = 0,
        Tiled = -2147483648
    }
}
