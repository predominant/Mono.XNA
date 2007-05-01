using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics.Internal
{
    /// <summary>
    /// Responsible for initializing the graphics subsystem
    /// </summary>
    class GraphicsSubSystem
    {
        static object s_sync = new object();

        const int DEFAULT_DISPLAY_WIDTH = 800;
        const int DEFAULT_DISPLAY_HEIGHT = 600;
        const int DEFAULT_BITS_PER_PIXEL = 32;
        const bool DEFAULT_RESIZABLE = false;
        const bool DEFAULT_OPENGL = true;
        const bool DEFAULT_FULLSCREEN = false;
        const bool DEFAULT_HARDWARE = true;

        const bool DEFAULT_SHOW_CURSOR = false;

        public static void EnsureSubSystem()
        {
            lock(s_sync)
            {
                if (Video.IsInitialized) return;

                Video.Initialize();
                SetVideoMode(DEFAULT_DISPLAY_WIDTH, DEFAULT_DISPLAY_HEIGHT, DEFAULT_FULLSCREEN);
                Mouse.ShowCursor = DEFAULT_SHOW_CURSOR;
            }
        }

        public static void SetVideoMode(int width, int height, bool isFullScreen)
        {
            lock (s_sync)
            {
                if (width != VideoInfo.ScreenWidth ||
                    height != VideoInfo.ScreenHeight ||
                    isFullScreen != Video.Screen.FullScreen)
                {
                    Video.SetVideoMode(width, height, DEFAULT_BITS_PER_PIXEL,
                                       DEFAULT_RESIZABLE, DEFAULT_OPENGL, isFullScreen, DEFAULT_HARDWARE);
                    Gl.glViewport(0, 0, width, height);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics.Internal
{
    /// <summary>
    /// Responsible for initializing the graphics subsystem
    /// </summary>
    class GraphicsSubSystem
    {
        static object s_sync = new object();

        const int DEFAULT_DISPLAY_WIDTH = 800;
        const int DEFAULT_DISPLAY_HEIGHT = 600;
        const int DEFAULT_BITS_PER_PIXEL = 32;
        const bool DEFAULT_RESIZABLE = false;
        const bool DEFAULT_OPENGL = true;
        const bool DEFAULT_FULLSCREEN = false;
        const bool DEFAULT_HARDWARE = true;

        const bool DEFAULT_SHOW_CURSOR = false;

        public static void EnsureSubSystem()
        {
            lock(s_sync)
            {
                if (Video.IsInitialized) return;

                Video.Initialize();
                SetVideoMode(DEFAULT_DISPLAY_WIDTH, DEFAULT_DISPLAY_HEIGHT, DEFAULT_FULLSCREEN);
                Mouse.ShowCursor = DEFAULT_SHOW_CURSOR;
            }
        }

        public static void SetVideoMode(int width, int height, bool isFullScreen)
        {
            lock (s_sync)
            {
                if (width != VideoInfo.ScreenWidth ||
                    height != VideoInfo.ScreenHeight ||
                    isFullScreen != Video.Screen.FullScreen)
                {
                    Video.SetVideoMode(width, height, DEFAULT_BITS_PER_PIXEL,
                                       DEFAULT_RESIZABLE, DEFAULT_OPENGL, isFullScreen, DEFAULT_HARDWARE);
                    Gl.glViewport(0, 0, width, height);
                }
            }
        }
    }
}
