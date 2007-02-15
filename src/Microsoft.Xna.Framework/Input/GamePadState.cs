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
using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadState
    {
        #region Private Fields

        private GamePadButtons buttons;
        private GamePadDPad dPad;
        private bool isConnected;
        private int packetNumber;
        private GamePadThumbSticks thumbSticks;
        private GamePadTriggers triggers;

        #endregion Private Fields


        #region Public Properties

        public GamePadButtons Buttons
        {
            get { return this.buttons; }
        }

        public GamePadDPad DPad
        {
            get { return this.dPad; }
        }

        public bool IsConnected
        {
            get { return this.isConnected; }
        }

        public int PacketNumber
        {
            get { return this.packetNumber; }
        }

        public GamePadThumbSticks ThumbSticks
        {
            get { return this.thumbSticks; }
        }

        public GamePadTriggers Triggers
        {
            get { return this.triggers; }
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

        public bool Equals(GamePadState obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            // Packetnumber should be unique
            return this.packetNumber;
        }

        public override string ToString()
        {
            return string.Format("{{IsConnected:{0}}}", isConnected);
        }

        #endregion
    }
}
