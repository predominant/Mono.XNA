// ContentWriter.cs created with MonoDevelop
// User: lars at 18.16 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
    
    
    public sealed class ContentWriter : BinaryWriter
    {
        
#region Constructor
        
        public ContentWriter()
        {
        }

#endregion
        
#region Properties

        public TargetPlatform TargetPlatform 
        { 
            get { throw new NotImplementedException(); }
        }
        
#endregion
        
#region Public Methods

        public void Write(Color value)
        {
            throw new NotImplementedException();
        }
        
        public void Write(Matrix value)
        {
            throw new NotImplementedException();
        }
        
        public void Write(Quaternion value)
        {
            throw new NotImplementedException();
        }
        
        public void Write(Vector2 value)
        {
            throw new NotImplementedException();
        }
        
        public void Write(Vector3 value)
        {
            throw new NotImplementedException();
        }
        
        public void Write(Vector4 value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteExternalReference<T>(ExternalReference<T> reference)
        {
            throw new NotImplementedException();
        }
        
        public void WriteObject<T>(T value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteObject<T>(T value, ContentTypeWriter typeWriter)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value, ContentTypeWriter typeWriter)
        {
            throw new NotImplementedException();
        }
        
        public void WriteSharedResource<T>(T value)
        {
            throw new NotImplementedException();
        }
        
#endregion
        
#region Protected Methods

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
        
#endregion
        
    }
}
