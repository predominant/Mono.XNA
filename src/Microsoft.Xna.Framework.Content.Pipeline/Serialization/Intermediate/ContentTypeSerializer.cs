// ContentTypeSerializer.cs created with MonoDevelop
// User: lars at 10.35 21.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{    

    
    
    public abstract class ContentTypeSerializer
    {
        protected internal delegate void ChildCallback(ContentTypeSerializer typeSerializer, Object value);

#region Constructor
        
        protected ContentTypeSerializer(Type targetType)
        {
        }
        
        protected ContentTypeSerializer(Type targetType, string xmlTypeName)
        {
            
        }

#endregion
        
#region Properties

        public virtual bool CanDeserializeIntoExistingObject 
        { 
            get { throw new NotImplementedException(); }
        }
        
        public Type TargetType 
        { 
            get { throw new NotImplementedException(); }
        }

        public string XmlTypeName 
        { 
            get { throw new NotImplementedException(); }
        }
        
#endregion
        
#region Public Methods

        public virtual bool ObjectIsEmpty(Object value)
        {
            throw new NotImplementedException();
        }
        
#endregion
        
#region Protected Methods
        
        protected internal abstract Object Deserialize(IntermediateReader input, ContentSerializerAttribute format, Object existingInstance);
        
        protected internal virtual void Initialize(IntermediateSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        protected internal virtual void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, Object value)
        {
            throw new NotImplementedException();
        }
        
        protected internal abstract void Serialize(IntermediateWriter output, Object value, ContentSerializerAttribute format);
        
#endregion
        
    }
}
