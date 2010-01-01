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
using System.IO;

namespace Microsoft.Xna.Framework.Graphics
{
    public enum CompilerIncludeHandlerType
    {
        Local = 0,
        System = 1,
    }

    [Flags]
    public enum CompilerOptions
    {
        None = 0,
        Debug = 1,
        SkipValidation = 2,
        SkipOptimization = 4,
        PackMatrixRowMajor = 8,
        PackMatrixColumnMajor = 16,
        PartialPrecision = 32,
        ForceVertexShaderSoftwareNoOptimizations = 64,
        ForcePixelShaderSoftwareNoOptimizations = 128,
        NoPreShader = 256,
        AvoidFlowControl = 512,
        PreferFlowControl = 1024,
        NotCloneable = 2048,
    }

    public abstract class CompilerIncludeHandler : IDisposable
    {
        public CompilerIncludeHandler() { throw new NotImplementedException(); }
        public void Dispose() { throw new NotImplementedException(); }
        protected virtual void Dispose(bool disposing) { throw new NotImplementedException(); }

        public abstract Stream Open(CompilerIncludeHandlerType includeType, string filename);
    }

	[Serializable]
    public struct CompilerMacro
    {
        public string Definition { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public string Name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override string ToString() { throw new NotImplementedException(); }
    }
}
