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
using SdlDotNet.Graphics;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceInformation
    {
		
		#region Private Fields
		
        DeviceType _deviceType;
        CreateOptions _createOptions;
        PresentationParameters _presentationParameters;
        GraphicsAdapter _adapter;
		
		#endregion Private Fields
		
		#region Constructors

        public GraphicsDeviceInformation()
        {
            _deviceType = DeviceType.Hardware;
            _createOptions = CreateOptions.HardwareVertexProcessing;
            _adapter = GraphicsAdapter.DefaultAdapter;
            _presentationParameters = new PresentationParameters();
            _presentationParameters.BackBufferWidth = Video.Screen.Width;
            _presentationParameters.BackBufferHeight = Video.Screen.Height;
        }

        internal GraphicsDeviceInformation(int width, int height)
        {
            _deviceType = DeviceType.Hardware;
            _createOptions = CreateOptions.HardwareVertexProcessing;
            _presentationParameters = new PresentationParameters();
            _presentationParameters.BackBufferWidth = width;
            _presentationParameters.BackBufferHeight = height;
            _adapter = GraphicsAdapter.DefaultAdapter;
        }

        private GraphicsDeviceInformation(bool cloning)
        {
            
        }
		
		#endregion Constructors
		
		#region Properties

        public GraphicsAdapter Adapter {
            get { return _adapter; }
            set { _adapter = value; }
        }
		
#if NUNITTESTS
        public
#else
        internal
#endif
        CreateOptions CreationOptions {
            get { return _createOptions; }
            set { _createOptions = value; }
        }

        public DeviceType DeviceType {
            get { return _deviceType; }
            set { _deviceType = value; }
        }

        public PresentationParameters PresentationParameters {
            get { return _presentationParameters; }
            set { _presentationParameters = value; }
        }
		
		#endregion Properties
		
		#region Public Methods

        public GraphicsDeviceInformation Clone()
        {
            GraphicsDeviceInformation gdi = new GraphicsDeviceInformation(true);
            gdi._adapter = Adapter;
            gdi._createOptions = CreationOptions;
            gdi._deviceType = DeviceType;
            gdi._presentationParameters = PresentationParameters;
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

            return _deviceType == gdi._deviceType &&
                _createOptions == gdi._createOptions &&
                _presentationParameters == gdi._presentationParameters;
        }

        public override int GetHashCode()
        {
            return _deviceType.GetHashCode() ^
                   _createOptions.GetHashCode() ^
                   PresentationParameters.GetHashCode();
        }
		
		#endregion
    }
}
