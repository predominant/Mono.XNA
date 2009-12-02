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
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Microsoft.Xna.Framework.Content.Pipeline
{

    /// <summary>Provides properties that define opaque data for a game asset.</summary>
    [ContentSerializerCollectionItemName("Data")]
    public sealed class OpaqueDataDictionary : NamedValueDictionary<Object>
	{
        private string xmlContent;

		#region Constructor

        /// <summary>Initializes a new instance of OpaqueDataDictionary.</summary>
        public OpaqueDataDictionary()
		{
		}
		
		#endregion

		#region Public Methods
		
		public string GetContentAsXml()
		{
            if (xmlContent == null)
            {
                if (base.Count == 0)
                {
                    xmlContent = string.Empty;
                }
                else
                {
                    StringBuilder output = new StringBuilder();

                    using (XmlWriter writer = XmlWriter.Create(output))
                    {
                        IntermediateSerializer.Serialize<OpaqueDataDictionary>(writer, this, null);
                    }
                    this.xmlContent = output.ToString();
                }
            }
            return this.xmlContent;
        }

        /// <summary>Gets the value of the specified key/value pair of the asset.</summary>
        /// <param name="key">The name of the key.</param>
        /// <param name="defaultValue">The value to return if the key cannot be found. This can be null for reference types, 0 for primitive types, and a zero-filled structure for structure types.</param>
        public T GetValue<T>(string key, T defaultValue)
        {
            object result = null;

            if (base.TryGetValue(key, out result) && (result is T))
                return (T)result;

            return defaultValue;
        }
 
		
		#endregion
		
		#region Protected Methods

        /// <summary>Modifies the value of an existing element.</summary>
        /// <param name="key">The key of the element to be modified.</param>
        /// <param name="value">The value to be set.</param>
        protected override void SetItem(string key, object value)
        {
            xmlContent = null;

            base.SetItem(key, value);
        }

        /// <summary>Specifies the type hint for the intermediate serializer.</summary>
        protected internal override Type DefaultSerializerType 
		{
            get { return typeof(string); }
		}

        /// <summary>Adds an element to the dictionary.</summary>
        /// <param name="key">The key of the new element.</param>
        /// <param name="value">The value of the new element.</param>
        protected override void AddItem(string key, object value)
        {
            xmlContent = null;

            base.AddItem(key, value);
        }

        /// <summary>Removes all elements from the dictionary.</summary>
        protected override void ClearItems()
        {
            xmlContent = null;

            base.ClearItems();
        }

        /// <summary>Removes the specified element from the dictionary.</summary>
        /// <param name="key">Identity of the key of the data pair to be removed.</param>
        protected override bool RemoveItem(string key)
        {
            xmlContent = null;

            return base.RemoveItem(key);
        }

 

		#endregion
		
	}
}
