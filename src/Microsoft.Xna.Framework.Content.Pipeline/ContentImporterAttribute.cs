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
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline
{

    [Serializable, AttributeUsage(AttributeTargets.Class)]
	public class ContentImporterAttribute : Attribute
	{
		#region Private Fields

		private bool cacheImportedData;
		private string defaultProcessor;
		private string displayName;
		private IEnumerable<string> fileExtensions;		
		
		#endregion Private Fields
		
		#region Constructors

        public ContentImporterAttribute(string fileExtension)
            : this(new string[] { fileExtension })
        {
        }

        public ContentImporterAttribute(params string[] fileExtensions)
        {
            if (fileExtensions == null)
                throw new ArgumentNullException("fileExtensions");
            
            foreach (string str in fileExtensions)
            {
                if (string.IsNullOrEmpty(str))
                    throw new ArgumentNullException("extension");
                if (!str.StartsWith("."))
                    throw new ArgumentException("Bad file extension", str);
            }
            this.fileExtensions = Array.AsReadOnly<string>(fileExtensions);
        }
		
		#endregion Constructor
		
		#region Properties
		
		public bool CacheImportedData 
		{ 
			get { return cacheImportedData; } 
			set { cacheImportedData = value; } 
		}

		public string DefaultProcessor 
		{ 
			get { return defaultProcessor; } 
			set { defaultProcessor = value; } 
		}
		
		public virtual string DisplayName 
		{ 
			get { return displayName; }
			set { displayName = value; } 
		}
		
		public IEnumerable<string> FileExtensions 
		{ 
			get { return fileExtensions; }
		}

		#endregion Properties

	}
}
