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

using System;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadCapabilities
    {
        #region Private Fields

        internal GamePadType gamePadType;

        // TODO: Change to a BitArray maybe?
        internal bool hasAButton; 
        internal bool hasBButton;
        internal bool hasXButton;
        internal bool hasYButton;
        internal bool hasBackButton;
        internal bool hasStartButton;
        internal bool hasLeftShoulderButton;
        internal bool hasRightShoulderButton;
        internal bool hasDPadLeftButton;
        internal bool hasDPadDownButton;
        internal bool hasDPadRightButton;
        internal bool hasDPadUpButton;
        internal bool isConnected;
        internal bool hasVoiceSupport;

        #endregion Private Fields


        #region Public Properties

        public GamePadType GamePadType
        {
            get { return this.gamePadType; }
        }

        public bool HasLeftStickButton
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasLeftTrigger
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasBigButton
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasLeftVibrationMotor
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasLeftXThumbStick
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasLeftYThumbStick
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasAButton
        {
            get { return this.hasAButton; }
        }

        public bool HasBackButton
        {
            get { return this.hasBackButton; }
        }

        public bool HasBButton
        {
            get { return this.hasBButton; }
        }

        public bool HasDPadDownButton
        {
            get { return this.hasDPadDownButton; }
        }

        public bool HasDPadLeftButton
        {
            get { return this.hasDPadLeftButton; }
        }

        public bool HasDPadRightButton
        {
            get { return this.hasDPadRightButton; }
        }

        public bool HasDPadUpButton
        {
            get { return this.hasDPadUpButton; }
        }

        public bool HasLeftShoulderButton
        {
            get { return this.hasLeftShoulderButton; }
        }

        public bool HasRightShoulderButton
        {
            get { return this.hasRightShoulderButton; }
        }

        public bool HasRightStickButton
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasRightTrigger
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasRightVibrationMotor
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasRightXThumbStick
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasRightYThumbStick
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasStartButton
        {
            get { return this.hasStartButton; }
        }

        public bool HasVoiceSupport
        {
            get { return this.hasVoiceSupport; }
        }

        public bool HasXButton
        {
            get { return this.hasXButton; }
        }

        public bool HasYButton
        {
            get { return this.hasYButton; }
        }

        public bool IsConnected
        {
            get { return this.isConnected; }
        }

        #endregion Public Properties
    }
}
