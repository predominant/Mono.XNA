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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public enum EffectParameterType
    {
        Void = 0,
        Bool = 1,
        Int32 = 2,
        Single = 3,
        String = 4,
        Texture = 5,
        Texture1D = 6,
        Texture2D = 7,
        Texture3D = 8,
        TextureCube = 9,
        Sampler = 10,
        Sampler1D = 11,
        Sampler2D = 12,
        Sampler3D = 13,
        SamplerCube = 14,
        PixelShader = 15,
        VertexShader = 16,
    }

    public enum EffectParameterClass
    {
        Scalar = 0,
        Vector = 1,
        MatrixRows = 2,
        MatrixColumns = 3,
        Object = 4,
        Struct = 5,
    }

    public sealed class EffectParameter
    {
        public static bool operator !=(EffectParameter left, EffectParameter right) { throw new NotImplementedException(); }

        public static bool operator ==(EffectParameter left, EffectParameter right) { throw new NotImplementedException(); }

        public EffectAnnotationCollection Annotations { get { throw new NotImplementedException(); } }

        public int ColumnCount { get { throw new NotImplementedException(); } }

        public EffectParameterCollection Elements { get { throw new NotImplementedException(); } }

        public string Name { get { throw new NotImplementedException(); } }

        public EffectParameterClass ParameterClass { get { throw new NotImplementedException(); } }

        public EffectParameterType ParameterType { get { throw new NotImplementedException(); } }

        public int RowCount { get { throw new NotImplementedException(); } }

        public string Semantic { get { throw new NotImplementedException(); } }

        public EffectParameterCollection StructureMembers { get { throw new NotImplementedException(); } }

        public override bool Equals(object obj) { throw new NotImplementedException(); }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public bool GetValueBoolean() { throw new NotImplementedException(); }

        public bool[] GetValueBooleanArray(int count) { throw new NotImplementedException(); }

        public int GetValueInt32() { throw new NotImplementedException(); }

        public int[] GetValueInt32Array(int count) { throw new NotImplementedException(); }

        public Matrix GetValueMatrix() { throw new NotImplementedException(); }

        public Matrix[] GetValueMatrixArray(int count) { throw new NotImplementedException(); }

        public Matrix GetValueMatrixTranspose() { throw new NotImplementedException(); }

        public Matrix[] GetValueMatrixTransposeArray(int count) { throw new NotImplementedException(); }

        public Quaternion GetValueQuaternion() { throw new NotImplementedException(); }

        public Quaternion[] GetValueQuaternionArray(int count) { throw new NotImplementedException(); }

        public float GetValueSingle() { throw new NotImplementedException(); }

        public float[] GetValueSingleArray(int count) { throw new NotImplementedException(); }

        public string GetValueString() { throw new NotImplementedException(); }

        public Texture2D GetValueTexture2D() { throw new NotImplementedException(); }

        public Texture3D GetValueTexture3D() { throw new NotImplementedException(); }

        public TextureCube GetValueTextureCube() { throw new NotImplementedException(); }

        public Vector2 GetValueVector2() { throw new NotImplementedException(); }

        public Vector2[] GetValueVector2Array(int count) { throw new NotImplementedException(); }

        public Vector3 GetValueVector3() { throw new NotImplementedException(); }

        public Vector3[] GetValueVector3Array(int count) { throw new NotImplementedException(); }

        public Vector4 GetValueVector4() { throw new NotImplementedException(); }

        public Vector4[] GetValueVector4Array(int count) { throw new NotImplementedException(); }

        public void SetArrayRange(int start, int end) { throw new NotImplementedException(); }

        public void SetValue(bool value) { throw new NotImplementedException(); }

        public void SetValue(bool[] value) { throw new NotImplementedException(); }

        public void SetValue(float value) { throw new NotImplementedException(); }

        public void SetValue(float[] value) { throw new NotImplementedException(); }

        public void SetValue(int value) { throw new NotImplementedException(); }

        public void SetValue(int[] value) { throw new NotImplementedException(); }

        public void SetValue(Matrix value) { throw new NotImplementedException(); }

        public void SetValue(Matrix[] value) { throw new NotImplementedException(); }

        public void SetValue(Quaternion value) { throw new NotImplementedException(); }

        public void SetValue(Quaternion[] value) { throw new NotImplementedException(); }

        public void SetValue(string value) { throw new NotImplementedException(); }

        public void SetValue(Texture value) 
        {
            //TODO
        }

        public void SetValue(Vector2 value) { throw new NotImplementedException(); }

        public void SetValue(Vector2[] value) { throw new NotImplementedException(); }

        public void SetValue(Vector3 value) { throw new NotImplementedException(); }

        public void SetValue(Vector3[] value) { throw new NotImplementedException(); }

        public void SetValue(Vector4 value) { throw new NotImplementedException(); }

        public void SetValue(Vector4[] value) { throw new NotImplementedException(); }

        public void SetValueTranspose(Matrix value) { throw new NotImplementedException(); }

        public void SetValueTranspose(Matrix[] value) { throw new NotImplementedException(); }
    }

    public sealed class EffectParameterCollection : IEnumerable<EffectParameter>
    {
        public int Count { get { throw new NotImplementedException(); } }

        public EffectParameter this[int index] { get { throw new NotImplementedException(); } }

        public EffectParameter this[string name] { get { throw new NotImplementedException(); } }

        public IEnumerator<EffectParameter> GetEnumerator() { throw new NotImplementedException(); }

        public EffectParameter GetParameterBySemantic(string semantic) { throw new NotImplementedException(); }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
