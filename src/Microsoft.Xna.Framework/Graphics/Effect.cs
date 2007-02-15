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
using System.IO;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Effect : IDisposable
    {
        protected Effect(GraphicsDevice graphicsDevice, Effect cloneSource) { throw new NotImplementedException(); }

        ~Effect()
        {
        }

        public Effect(GraphicsDevice graphicsDevice, byte[] effectCode, CompilerOptions options, EffectPool pool) { throw new NotImplementedException(); }
        public Effect(GraphicsDevice graphicsDevice, Stream effectCodeFileStream, CompilerOptions options, EffectPool pool) { throw new NotImplementedException(); }
        public Effect(GraphicsDevice graphicsDevice, string effectCodeFile, CompilerOptions options, EffectPool pool) { throw new NotImplementedException(); }
        public Effect(GraphicsDevice graphicsDevice, Stream effectCodeFileStream, int numberBytes, CompilerOptions options, EffectPool pool) { throw new NotImplementedException(); }
        public static bool operator !=(Effect left, Effect right) { throw new NotImplementedException(); }
        public static bool operator ==(Effect left, Effect right) { throw new NotImplementedException(); }
        public string Creator { get { throw new NotImplementedException(); } }
        public EffectTechnique CurrentTechnique { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public EffectPool EffectPool { get { throw new NotImplementedException(); } }
        public EffectFunctionCollection Functions { get { throw new NotImplementedException(); } }
        public GraphicsDevice GraphicsDevice { get { throw new NotImplementedException(); } }
        public bool IsDisposed { get { throw new NotImplementedException(); } }
        public EffectParameterCollection Parameters { get { throw new NotImplementedException(); } }
        public EffectTechniqueCollection Techniques { get { throw new NotImplementedException(); } }
        public event EventHandler Disposing;
        public event EventHandler Lost;
        public event EventHandler Reset;
        public void Begin() { throw new NotImplementedException(); }
        public void Begin(SaveStateMode saveStateMode) { throw new NotImplementedException(); }
        public virtual Effect Clone(GraphicsDevice device) { throw new NotImplementedException(); }
        public void CommitChanges() { throw new NotImplementedException(); }
        public static CompiledEffect CompileEffectFromFile(Stream effectFileStream, CompilerMacro[] preprocessorDefines, CompilerIncludeHandler includeHandler, CompilerOptions options, TargetPlatform platform) { throw new NotImplementedException(); }
        public static CompiledEffect CompileEffectFromFile(string effectFile, CompilerMacro[] preprocessorDefines, CompilerIncludeHandler includeHandler, CompilerOptions options, TargetPlatform platform) { throw new NotImplementedException(); }
        public static CompiledEffect CompileEffectFromFile(Stream effectFileStream, int numberBytes, CompilerMacro[] preprocessorDefines, CompilerIncludeHandler includeHandler, CompilerOptions options, TargetPlatform platform) { throw new NotImplementedException(); }
        public static CompiledEffect CompileEffectFromSource(string effectFileSource, CompilerMacro[] preprocessorDefines, CompilerIncludeHandler includeHandler, CompilerOptions options, TargetPlatform platform) { throw new NotImplementedException(); }
        public string Disassemble(bool enableColorCode) { throw new NotImplementedException(); }
        public static string Disassemble(Effect effect, bool enableColorCode) { throw new NotImplementedException(); }
        public void Dispose() { throw new NotImplementedException(); }
        protected virtual void Dispose(bool disposing) { throw new NotImplementedException(); }
        public void End() { throw new NotImplementedException(); }
        public override bool Equals(object obj) { throw new NotImplementedException(); }
        public override int GetHashCode() { throw new NotImplementedException(); }
        protected void raise_Disposing(object sender, EventArgs e) { throw new NotImplementedException(); }
        protected void raise_Lost(object sender, EventArgs e) { throw new NotImplementedException(); }
        protected void raise_Reset(object sender, EventArgs e) { throw new NotImplementedException(); }
        public override string ToString() { throw new NotImplementedException(); }
    }
}
