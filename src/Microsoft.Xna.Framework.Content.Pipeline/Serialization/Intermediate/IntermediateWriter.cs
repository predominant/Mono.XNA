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
