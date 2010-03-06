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
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Effect : IDisposable
    {
        private EffectTechniqueCollection TechniqueCollection;
        private EffectParameterCollection ParamCollection;
 
        private int fragment_handle;
        private int vertex_handle;
        private bool fragment;
        private bool vertex;

        protected Effect(GraphicsDevice graphicsDevice, Effect cloneSource) 
        {
            //TODO
        }

        ~Effect()
        {
        }

        public Effect(GraphicsDevice graphicsDevice, byte[] effectCode, CompilerOptions options, EffectPool pool) 
        {
            int fragmentblocklength = BitConverter.ToInt32(effectCode, 0);

            int vertexblocklength = BitConverter.ToInt32(effectCode, fragmentblocklength + 4);

            if (fragmentblocklength != 0)
            {
                fragment_handle = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
                fragment = true;
            }

            if (vertexblocklength != 0)
            {
                vertex_handle = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
                vertex = true;
            }

            if (fragment)
            {
                string[] fragmentstring = new string[1] { Encoding.UTF8.GetString(effectCode, 4, fragmentblocklength) };
                int[] fragmentLength = new int[1] { fragmentstring[0].Length };
                Gl.glShaderSource(fragment_handle, 1, fragmentstring, fragmentLength);
            }

            if (vertex)
            {
                string[] vertexstring = new string[1] { Encoding.UTF8.GetString(effectCode, fragmentblocklength + 8, vertexblocklength) };
                int[] vertexLength = new int[1] { vertexstring[0].Length };
                Gl.glShaderSource(vertex_handle, 1, vertexstring, vertexLength);
            }

            if (fragment)
            {
                Gl.glCompileShader(fragment_handle);
            }

            if (vertex)
            {
                Gl.glCompileShader(fragment_handle);
            }
        }
        
        public Effect(GraphicsDevice graphicsDevice, Stream effectCodeFileStream, CompilerOptions options, EffectPool pool) 
        {
            throw new NotImplementedException(); 
        }
       
        public Effect(GraphicsDevice graphicsDevice, string effectCodeFile, CompilerOptions options, EffectPool pool) 
        {
            throw new NotImplementedException();
        }

        public Effect(GraphicsDevice graphicsDevice, Stream effectCodeFileStream, int numberBytes, CompilerOptions options, EffectPool pool) 
        {
            throw new NotImplementedException(); 
        }

        public string Creator { get { throw new NotImplementedException(); } }
        public EffectTechnique CurrentTechnique { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        public EffectPool EffectPool { get { throw new NotImplementedException(); } }
        public EffectFunctionCollection Functions { get { throw new NotImplementedException(); } }
        public GraphicsDevice GraphicsDevice { get { throw new NotImplementedException(); } }
        public bool IsDisposed { get { throw new NotImplementedException(); } }
        
        public EffectParameterCollection Parameters
        {
            get
            {
                return ParamCollection;
            }
        }
        
        public EffectTechniqueCollection Techniques 
        {
            get 
            {
                return TechniqueCollection;
            } 
        }

        public void Begin() { throw new NotImplementedException(); }
        public void Begin(SaveStateMode saveStateMode) { throw new NotImplementedException(); }
        
        public virtual Effect Clone(GraphicsDevice device)
        {
            return new Effect(device, this);
        }

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

        public override string ToString() { throw new NotImplementedException(); }
    }
}
