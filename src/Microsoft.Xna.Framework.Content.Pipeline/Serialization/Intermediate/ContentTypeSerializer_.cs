// ContentTypeSerializer_.cs created with MonoDevelop
// User: lars at 10.43 21.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{
    
    
    public abstract class ContentTypeSerializer<T> : ContentTypeSerializer
    {
        
#region Constructor
        
        protected ContentTypeSerializer() 
            : base (typeof(T))
        {
        }
        
        protected ContentTypeSerializer(string xmlTypeName)
            : base (typeof(T), xmlTypeName)
        {
            
        }

#endregion
        
#region Public Methods

        protected internal override Object Deserialize(IntermediateReader input, ContentSerializerAttribute format, Object existingInstance)
        {
            throw new NotImplementedException();
        }
        
        protected internal abstract T Deserialize(IntermediateReader input, ContentSerializerAttribute format, T existingInstance);
        
        public override bool ObjectIsEmpty(Object value)
        {
            throw new NotImplementedException();
        }
        
        public virtual bool ObjectIsEmpty(T value)
        {
            throw new NotImplementedException();
        }
        
        protected internal override void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, Object value)
        {
            throw new NotImplementedException();
        }
        
        protected internal virtual void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, T value)
        {
            throw new NotImplementedException();
        }
        
        protected internal override void Serialize(IntermediateWriter output, Object value, ContentSerializerAttribute format)
        {
            throw new NotImplementedException();
        }
        
        protected internal abstract void Serialize(IntermediateWriter output, T value, ContentSerializerAttribute format);
        
#endregion
        
    }
}
