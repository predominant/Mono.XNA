#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

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

		#endregion Constructor
        
		#region Methods

        public override bool ObjectIsEmpty(Object value)
        {
            return ObjectIsEmpty((T)value);
        }
        
        public virtual bool ObjectIsEmpty(T value)
        {
            return base.ObjectIsEmpty(value);
        }
        
        protected internal override void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, Object value)
        {
            ScanChildren(serializer, callback, (T)value);
        }
        
        protected internal virtual void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, T value)
        {
            base.ScanChildren(serializer, callback, value);
        }
        
        protected internal override void Serialize(IntermediateWriter output, Object value, ContentSerializerAttribute format)
        {
            Serialize(output, (T)value, format);
        }
        
        protected internal abstract void Serialize(IntermediateWriter output, T value, ContentSerializerAttribute format);
        
		protected internal override Object Deserialize(IntermediateReader input, ContentSerializerAttribute format, Object existingInstance)
        {
            return Deserialize(input, format, (T)existingInstance);
        }
        
        protected internal abstract T Deserialize(IntermediateReader input, ContentSerializerAttribute format, T existingInstance);
        
        #endregion Methods
        
    }
    
    
    public abstract class ContentTypeSerializer
    {
		#region Fields
		
		private Type targetType;
		private string xmlTypeName;
		
		#endregion Fields
		
		#region Constructor
        
        protected ContentTypeSerializer(Type targetType)
        {
			this.targetType = targetType;
        }
        
        protected ContentTypeSerializer(Type targetType, string xmlTypeName)
        {
            this.targetType = targetType;
			this.xmlTypeName = xmlTypeName;
        }

		#endregion Constructor
        
		#region Properties

        public virtual bool CanDeserializeIntoExistingObject { 
            get { return true; }
        }
        
        public Type TargetType { 
            get { return targetType; }
        }

        public string XmlTypeName { 
            get { return xmlTypeName; }
        }
        
		#endregion Properties
        
		#region Methods

        public virtual bool ObjectIsEmpty(Object value)
        {
			if (value.GetType().IsValueType)
				return false;
			
            return value == null;
		}
        
        protected internal virtual void Initialize(IntermediateSerializer serializer)
        {
			
        }
		
		protected internal virtual void ScanChildren(IntermediateSerializer serializer, ChildCallback callback, Object value)
        {
			if (value == null)
				return;
            Type valueType = value.GetType();
        }
        
        protected internal abstract Object Deserialize(IntermediateReader input, ContentSerializerAttribute format, Object existingInstance);
        
        protected internal abstract void Serialize(IntermediateWriter output, Object value, ContentSerializerAttribute format);
        
		#endregion Methods
		
		#region Delegates
		
        protected internal delegate void ChildCallback(ContentTypeSerializer typeSerializer, Object value);
				
		#endregion Delegates
        
    }
}
