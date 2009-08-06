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
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Microsoft.Xna.Framework.Design
{
    public class MathTypeConverter : ExpandableObjectConverter
    {
        protected PropertyDescriptorCollection propertyDescriptions;
        protected bool supportStringConvert;
       

        public MathTypeConverter()
        {
           this.supportStringConvert = true;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
           return this.supportStringConvert && (sourceType == typeof(String)) || base.CanConvertFrom(context,sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context,destinationType));
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
           return this.propertyDescriptions;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
           return true;
        }
		
		internal static T[] ConvertToT<T>(ITypeDescriptorContext context, CultureInfo culture, object value, int Count, string messageParam)
		{
			if (!(value is String))return null;
			
			string val = ((string)value).Trim();
			
			if (val.Length == 0) return null;
			if (culture == null) culture = CultureInfo.CurrentCulture;
	
			char sep = culture.TextInfo.ListSeparator[0];
			string[] valArray = val.Split(new char[] { sep });
			TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
			T[] TArray = new T[valArray.Length];
			
			for (int i = 0; i < TArray.Length; i++)
			{
				try{
					TArray[i] = (T) converter.ConvertFromString(context,culture,valArray[i]);
				}
				catch(Exception ex) {
					throw new ArgumentException("Invalid string format",ex);
				}
			}
			
			if (TArray.Length != Count) throw new ArgumentException("Invalid string format");

			return TArray;
		}
    }
}
