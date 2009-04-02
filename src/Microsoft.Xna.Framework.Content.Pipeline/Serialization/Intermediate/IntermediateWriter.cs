// IntermediateWriter.cs created with MonoDevelop
// User: lars at 11.06 21.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Xml;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{
    
    
    public sealed class IntermediateWriter
    {

#region Constructor
        
        public IntermediateWriter()
        {
        }

#endregion
        
#region Properties

        public IntermediateSerializer Serializer 
        { 
            get { throw new NotImplementedException(); }
        }
        
        public XmlWriter Xml 
        { 
            get { throw new NotImplementedException(); }
        }
        
#endregion
        
#region Public Methods

        public void WriteExternalReference<T>(ExternalReference<T> value)
        {
            throw new NotImplementedException();
        }
        
        public void WriteObject<T>(T value, ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        public void WriteObject<T>(T value, ContentSerializerAttribute format, ContentTypeSerializer typeSerializer)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value, ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        public void WriteRawObject<T>(T value, ContentSerializerAttribute format, ContentTypeSerializer typeSerializer)
        {
            throw new NotImplementedException();
        }
        
        public void WriteSharedResource<T>(T value, ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        public void WriteTypeName(Type type)
        {
            throw new NotImplementedException();
        }
        
#endregion
        
    }
}
