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

using Microsoft.Xna.Framework.Graphics;
using System;
using Tao.Sdl;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceInformation
    {
		
		#region Private Fields
		
        DeviceType deviceType;
        PresentationParameters presentationParameters;
        GraphicsAdapter adapter;
		
		#endregion Private Fields
		
		#region Properties

        public GraphicsAdapter Adapter {
            get { return adapter; }
            set { adapter = value; }
        }
		
        public DeviceType DeviceType {
            get { return deviceType; }
            set { deviceType = value; }
        }

        public PresentationParameters PresentationParameters {
            get { return presentationParameters; }
            set { presentationParameters = value; }
        }
		
		#endregion Properties
		
		#region Constructors

        public GraphicsDeviceInformation()
        {
            deviceType = DeviceType.Hardware;
            adapter = GraphicsAdapter.DefaultAdapter;
            presentationParameters = new PresentationParameters();
            presentationParameters.Clear();
        }

        #endregion Constructors		
		
		#region Public Methods

        public GraphicsDeviceInformation Clone()
        {
            GraphicsDeviceInformation gdi = new GraphicsDeviceInformation();
            gdi.adapter = Adapter;
            gdi.deviceType = DeviceType;
            gdi.presentationParameters = PresentationParameters;
            return gdi;
        }
		
		#endregion
		
		#region Object Overrides

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            GraphicsDeviceInformation gdi = obj as GraphicsDeviceInformation;
            if (gdi == null)
                return false;

            return deviceType == gdi.deviceType &&
                   presentationParameters == gdi.presentationParameters;
        }

        public override int GetHashCode()
        {
            return deviceType.GetHashCode() ^
                   PresentationParameters.GetHashCode();
        }
		
		#endregion
    }
}
