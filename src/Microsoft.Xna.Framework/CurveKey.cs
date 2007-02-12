#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:
Olivier Dufour (Duff)

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
using System.ComponentModel;

namespace Microsoft.Xna.Framework
{
    [Serializable]
    public class CurveKey : IEquatable<CurveKey>, IComparable<CurveKey>
    {
        #region Private Fields

        private CurveContinuity m_continuity;
        private float m_position;
        private float m_tangentIn;
        private float m_tangentOut;
        private float m_value;

        #endregion Private Fields


        #region Properties

        public CurveContinuity Continuity
        {
            get { return m_continuity; }
            set { m_continuity = value; }
        }

        public float Position
        {
            get { return m_position; }
        }

        public float TangentIn
        {
            get { return m_tangentIn; }
            set { m_tangentIn = value; }
        }

        public float TangentOut
        {
            get { return m_tangentOut; }
            set { m_tangentOut = value; }
        }

        public float Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        #endregion


        #region Constructors

        public CurveKey(float position, float value)
            : this(position, value, 0, 0, CurveContinuity.Default)
        {

        }

        public CurveKey(float position, float value, float tangentIn, float tangentOut)
            : this(position, value, tangentIn, tangentOut, CurveContinuity.Default)
        {

        }

        public CurveKey(float position, float value, float tangentIn, float tangentOut, CurveContinuity continuity)
        {
            this.m_position = position;
            this.m_value = value;
            this.m_tangentIn = tangentIn;
            this.m_tangentOut = tangentOut;
            this.m_continuity = continuity;
        }

        #endregion Constructors


        #region Public Methods

        public static bool operator !=(CurveKey a, CurveKey b)
        {
            return !(a == b);
        }

        public static bool operator ==(CurveKey a, CurveKey b)
        {
            if (object.Equals(a, null))
                return object.Equals(b, null);

            if (object.Equals(b, null))
                return object.Equals(a, null);

            return (a.m_position == b.m_position)
                && (a.m_value == b.m_value)
                && (a.m_tangentIn == b.m_tangentIn)
                && (a.m_tangentOut == b.m_tangentOut)
                && (a.m_continuity == b.m_continuity);
        }

        public CurveKey Clone()
        {
            return new CurveKey(m_position, m_value, m_tangentIn, m_tangentOut, m_continuity);
        }

        public int CompareTo(CurveKey other)
        {
            return m_position.CompareTo(other.m_position);
        }

        public bool Equals(CurveKey other)
        {
            return (this == other);
        }

        public override bool Equals(object obj)
        {
            return (obj is CurveKey) ? ((CurveKey)obj) == this : false;
        }

        public override int GetHashCode()
        {
            return m_position.GetHashCode() ^ m_value.GetHashCode() ^ m_tangentIn.GetHashCode() ^
                m_tangentOut.GetHashCode() ^ m_continuity.GetHashCode();
        }

        #endregion
    }
}
