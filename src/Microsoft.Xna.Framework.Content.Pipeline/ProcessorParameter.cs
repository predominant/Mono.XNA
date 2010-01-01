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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline
{

    [Serializable]
	public sealed class ProcessorParameter
	{

#region Constructor

        internal ProcessorParameter(string propertyName, Type propertyType)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            if (propertyType == null)
            {
                throw new ArgumentNullException("propertyType");
            }
            this.propertyName = propertyName;
            this.propertyType = propertyType.AssemblyQualifiedName;
            if (propertyType.IsEnum)
            {
                this.possibleEnumValues = new List<string>(Enum.GetNames(propertyType)).AsReadOnly();
            }
        }
		
#endregion
		
#region Properties

        private object defaultValue;
        public object DefaultValue
        {
            get
            {
                return defaultValue;
            }
            internal set
            {
                defaultValue = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            internal set
            {
                description = value;
            }
        }

        private string displayName;
        public string DisplayName
        {
            get
            {
                return displayName;
            }
            internal set
            {
                displayName = value;
            }
        }

        public bool IsEnum
        {
            get
            {
                return (possibleEnumValues != null);
            }
        }

        private ReadOnlyCollection<string> possibleEnumValues;
        public ReadOnlyCollection<string> PossibleEnumValues
        {
            get
            {
                return this.possibleEnumValues;
            }
        }

        private string propertyName;
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }

        private string propertyType;
        public string PropertyType
        {
            get
            {
                return this.propertyType;
            }
        }
		
#endregion
		
	}
}
