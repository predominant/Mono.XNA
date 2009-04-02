// IntermediateReader.cs created with MonoDevelop
// User: lars at 10.54 21.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Xml;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{
    
    
    public sealed class IntermediateReader
    {

#region Constructor
        
        public IntermediateReader()
        {
        }

#endregion
        
#region Properties

        public IntermediateSerializer Serializer 
        { 
            get { throw new NotImplementedException(); }
        }
        
        public XmlReader Xml 
        { 
            get { throw new NotImplementedException(); }
        }
        
#endregion
        
#region Public Methods

        public bool MoveToElement(string elementName)
        {
            throw new NotImplementedException();
        }
        
        public void ReadExternalReference<T>(ExternalReference<T> existingInstance)
        {
            throw new NotImplementedException();
        }
        
        public T ReadObject<T>(ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        public T ReadObject<T>(ContentSerializerAttribute format, ContentTypeSerializer typeSerializer)
        {
            throw new NotImplementedException();
        }
        
        public T ReadObject<T>(ContentSerializerAttribute format, ContentTypeSerializer typeSerializer, T existingInstance)
        {
            throw new NotImplementedException();
        }
        
        public T ReadObject<T>(ContentSerializerAttribute format, T existingInstance)
        {
            throw new NotImplementedException();
        }
        
        public T ReadRawObject<T>(ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        public T ReadRawObject<T>(ContentSerializerAttribute format, ContentTypeSerializer typeSerializer)
        {
            throw new NotImplementedException();
        }
        
        public T ReadRawObject<T>(ContentSerializerAttribute format, ContentTypeSerializer typeSerializer, T existingInstance)
        {
            throw new NotImplementedException();
        }
        
        public T ReadRawObject<T>(ContentSerializerAttribute format, T existingInstance)
        {
            throw new NotImplementedException();
        }
        
        public void ReadSharedResource<T>(ContentSerializerAttribute format, Action<T> fixup)
        {
            throw new NotImplementedException();
        }
        
        public Type ReadTypeName()
        {
            throw new NotImplementedException();
        }
        
#endregion
        
    }
}
