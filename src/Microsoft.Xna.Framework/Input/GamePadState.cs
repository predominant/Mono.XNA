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

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadState
    {
        #region Private Fields

        internal GamePadButtons buttons;
        internal GamePadDPad dPad;
        internal bool isConnected;
        int packetNumber;
        internal GamePadThumbSticks thumbSticks;
        internal GamePadTriggers triggers;

        #endregion Private Fields

        #region Public Properties

        public GamePadButtons Buttons
        {
            get { return buttons; }
        }

        public GamePadDPad DPad
        {
            get { return dPad; }
        }

        public bool IsConnected
        {
            get { return isConnected; }
        }

        public int PacketNumber
        {
            get { return packetNumber; }
            internal set { packetNumber = value & 0x7FFFFFFF; } // ensures the packet number wraps back to zero, and not to 0x8000000
        }

        public GamePadThumbSticks ThumbSticks
        {
            get { return thumbSticks; }
        }

        public GamePadTriggers Triggers
        {
            get { return triggers; }
        }

        #endregion Public Properties

        #region Public Methods

        public static bool operator !=(GamePadState left, GamePadState right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadState left, GamePadState right)
        {
            return (left.isConnected == right.isConnected)
                   && (left.dPad == right.dPad)
                   && (left.buttons == right.buttons)
                   && (left.thumbSticks == right.thumbSticks)
                   && (left.triggers == right.triggers)
                   && (left.packetNumber == right.packetNumber);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadState) ? ((GamePadState)obj) == this : false;
        }

        //public bool Equals(GamePadState obj)
        //{
        //    return this == obj;
        //}

        public bool IsButtonDown(Microsoft.Xna.Framework.Input.Buttons button)
        {
            throw new System.NotImplementedException();
        }

        public bool IsButtonUp(Microsoft.Xna.Framework.Input.Buttons button)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            // Packetnumber should be unique
            return packetNumber;
        }

        public GamePadState(Microsoft.Xna.Framework.Input.GamePadThumbSticks thumbSticks, Microsoft.Xna.Framework.Input.GamePadTriggers triggers, Microsoft.Xna.Framework.Input.GamePadButtons buttons, Microsoft.Xna.Framework.Input.GamePadDPad dPad)
        {
            throw new System.NotImplementedException();
        }

        public GamePadState(Microsoft.Xna.Framework.Vector2 leftThumbStick, Microsoft.Xna.Framework.Vector2 rightThumbStick, float leftTrigger, float rightTrigger,params Microsoft.Xna.Framework.Input.Buttons[] buttons)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{{IsConnected:{0}}}", isConnected);
        }

        #endregion
    }
}