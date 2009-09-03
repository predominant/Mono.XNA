#region License
/*
MIT License
Copyright © 2006 - 2007 The Mono.Xna Team

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

namespace Microsoft.Xna.Framework.Graphics
{
    [Serializable]
    public class PresentationParameters : IDisposable
    {
        #region Constants

        public const int DefaultPresentRate = 60;

        #endregion Constants

        #region Private Fields

        private DepthFormat autoDepthStencilFormat;
        private int backBufferCount;
        private SurfaceFormat backBufferFormat;
        private int backBufferHeight;
        private int backBufferWidth;
        private IntPtr deviceWindowHandle;
        private bool enableAutoDepthStencil;
        private int fullScreenRefreshRateInHz;
        private bool isFullScreen;
        private int multiSampleQuality;
        private MultiSampleType multiSampleType;
        private PresentInterval presentationInterval;
        private PresentOptions presentOptions;
        private SwapEffect swapEffect;
        private bool disposed;

        #endregion Private Fields
		
		#region Properties

        public DepthFormat AutoDepthStencilFormat {
            get { return autoDepthStencilFormat; }
            set { autoDepthStencilFormat = value; }
        }

        public int BackBufferCount {
            get { return backBufferCount; }
            set { backBufferCount = value; }
        }

        public SurfaceFormat BackBufferFormat {
            get { return backBufferFormat; }
            set { backBufferFormat = value; }
        }

        public int BackBufferHeight {
            get { return backBufferHeight; }
            set { backBufferHeight = value; }
        }

        public int BackBufferWidth {
            get { return backBufferWidth; }
            set { backBufferWidth = value; }
        }

        public IntPtr DeviceWindowHandle {
            get { return deviceWindowHandle; }
            set { deviceWindowHandle = value; }
        }

        public bool EnableAutoDepthStencil {
            get { return enableAutoDepthStencil; }
            set { enableAutoDepthStencil = value; }
        }

        public int FullScreenRefreshRateInHz {
            get { return fullScreenRefreshRateInHz; }
            set { fullScreenRefreshRateInHz = value; }
        }

        public bool IsFullScreen {
            get { return isFullScreen; }
            set { isFullScreen = value; }
        }

        public int MultiSampleQuality {
            get { return multiSampleQuality; }
            set { multiSampleQuality = value; }
        }

        public MultiSampleType MultiSampleType {
            get { return multiSampleType; }
            set { multiSampleType = value; }
        }

        public PresentInterval PresentationInterval {
            get { return presentationInterval; }
            set { presentationInterval = value; }
        }

        public PresentOptions PresentOptions {
            get { return presentOptions; }
            set { presentOptions = value; }
        }

        public SwapEffect SwapEffect {
            get { return swapEffect; }
            set { swapEffect = value; }
        }

        #endregion Properties

        #region Constructors

        public PresentationParameters()
        {
            Clear();
        }

        ~PresentationParameters()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Operators

        public static bool operator !=(PresentationParameters left, PresentationParameters right)
        {
            return !(left == right);
        }
        
        public static bool operator ==(PresentationParameters left, PresentationParameters right)
        {
            if (object.Equals(left, null))
                return (object.Equals(right, null));

            if (object.Equals(right, null))
                return (object.Equals(left, null));

            return left.Equals(right);
        }

        #endregion Operators

        #region Methods

        public void Clear()
        {
            autoDepthStencilFormat = DepthFormat.Unknown;
            backBufferCount = 0;
            backBufferFormat = SurfaceFormat.Unknown;
            backBufferHeight = 0;
            backBufferWidth = 0;
            deviceWindowHandle = IntPtr.Zero;
            enableAutoDepthStencil = false;
            fullScreenRefreshRateInHz = 0;
            isFullScreen = false;
            multiSampleQuality = 0;
            multiSampleType = MultiSampleType.None;
            presentationInterval = PresentInterval.Default;
            presentOptions = PresentOptions.None;
            swapEffect = SwapEffect.Default;
        }

        public PresentationParameters Clone()
        {
            PresentationParameters clone = new PresentationParameters();
            clone.autoDepthStencilFormat = this.autoDepthStencilFormat;
            clone.backBufferCount = this.backBufferCount;
            clone.backBufferFormat = this.backBufferFormat;
            clone.backBufferHeight = this.backBufferHeight;
            clone.backBufferWidth = this.backBufferWidth;
            clone.deviceWindowHandle = this.deviceWindowHandle;
            clone.disposed = this.disposed;
            clone.enableAutoDepthStencil = this.enableAutoDepthStencil;
            clone.fullScreenRefreshRateInHz = this.fullScreenRefreshRateInHz;
            clone.isFullScreen = this.isFullScreen;
            clone.multiSampleQuality = this.multiSampleQuality;
            clone.multiSampleType = this.multiSampleType;
            clone.presentationInterval = this.presentationInterval;
            clone.presentOptions = this.presentOptions;
            clone.swapEffect = this.swapEffect;
            return clone;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                if (disposing)
                {
                    // Dispose managed resources
                }
                // Dispose unmanaged resources
            }
        }

        public override bool Equals(object obj)
        {
            PresentationParameters parameters = obj as PresentationParameters;
            if (parameters == null) return false;
            return (parameters.autoDepthStencilFormat == this.autoDepthStencilFormat) &&
                (parameters.backBufferCount == this.backBufferCount) &&
                (parameters.backBufferFormat == this.backBufferFormat) &&
                (parameters.backBufferHeight == this.backBufferHeight) &&
                (parameters.backBufferWidth == this.backBufferWidth) &&
                (parameters.deviceWindowHandle == this.deviceWindowHandle) &&
                (parameters.enableAutoDepthStencil == this.enableAutoDepthStencil) &&
                (parameters.fullScreenRefreshRateInHz == this.fullScreenRefreshRateInHz) &&
                (parameters.isFullScreen == this.isFullScreen) &&
                (parameters.multiSampleQuality == this.multiSampleQuality) &&
                (parameters.multiSampleType == this.multiSampleType) &&
                (parameters.presentationInterval == this.presentationInterval) &&
                (parameters.presentOptions == this.presentOptions) &&
                (parameters.swapEffect == this.swapEffect);
        }

        #endregion Methods

    }
}
