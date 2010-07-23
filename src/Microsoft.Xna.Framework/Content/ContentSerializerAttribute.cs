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

namespace Microsoft.Xna.Framework.Content
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ContentSerializerAttribute : Attribute
    {
        #region Private Member Variables

        private bool allowNull;
        private string collectionItemName;
        private string elementName;
        private bool flattenContent;
        private bool hasCollectionItemName;
        private bool optional;
        private bool sharedResource;

        #endregion


        #region Constructor

        public ContentSerializerAttribute()
        {
			allowNull = true;
			collectionItemName = "Item";
            elementName = "Asset";
			flattenContent = false;
			hasCollectionItemName = false;
			optional = false;
			sharedResource = false;
        }

        #endregion Constructor

        #region Properties

        public bool AllowNull {
            get { return this.allowNull; }
            set { this.allowNull = value; }
        }

        public string CollectionItemName {
            get { return this.collectionItemName; }
            set { 
				this.collectionItemName = value; 
				hasCollectionItemName = true;
			}
        }

        public string ElementName {
            get { return this.elementName; }
            set { this.elementName = value; }
        }

        public bool FlattenContent {
            get { return this.flattenContent; }
            set { this.flattenContent = value; }
        }

        public bool HasCollectionItemName {
            get { return this.hasCollectionItemName; }
        }

        public bool Optional {
            get { return this.optional; }
            set { this.optional = value; }
        }

        public bool SharedResource {
            get { return this.sharedResource; }
            set { this.sharedResource = value; }
        }

        #endregion Properties
		
		#region Methods
		
        public ContentSerializerAttribute Clone()
        {
            ContentSerializerAttribute clone = new ContentSerializerAttribute();
            clone.allowNull = this.allowNull;
            clone.collectionItemName = this.collectionItemName;
            clone.elementName = this.elementName;
            clone.flattenContent = this.flattenContent;
            clone.hasCollectionItemName = this.hasCollectionItemName;
            clone.optional = this.optional;
            clone.sharedResource = this.sharedResource;
            return clone;
        }
		
		#endregion Methods

    }
}
