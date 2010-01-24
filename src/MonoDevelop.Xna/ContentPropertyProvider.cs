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
using System.ComponentModel;
using System.Globalization;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.DesignerSupport;

namespace MonoDevelop.Xna
{
	public class ContentPropertyProvider : IPropertyProvider
	{

		#region Constructor
		
		public ContentPropertyProvider ()
		{
		}
		
		#endregion Constructor
		
		#region IPropertyProvider Implementation
		
		public bool SupportsObject (object o)
		{
			ProjectFile file = o as ProjectFile;
			if(file != null)
				return file.Project is ContentProject;
			
			return false;
		}

		public object CreateProvider (object o)
		{
			return new ContentFileWrapper ((ProjectFile)o);
		}		
		
		#endregion IPropertyProvider Implementation
		
		#region Nested ContentFileWrapper Class
		
		public class ContentFileWrapper: CustomDescriptor
		{
			#region Private Fields
			
			const string nameKey = "Name";
			const string importerKey = "Importer";
			const string processorKey = "Processor";
			
			ProjectFile file;
			
			#endregion Private Fields
			
			#region Constructor
			
			public ContentFileWrapper (ProjectFile file)
			{
				this.file = file;
			}
			
			#endregion Constructor
			
			#region Properties
			
			[LocalizedCategory("MonoXNA")]
			[LocalizedDisplayName("Name")]
			[LocalizedDescription("The name of the content.")]
			public string Name {
				get {
					object result = file.ExtendedProperties[nameKey];
					return result == null ? "" : (string)result;
				}
				set { file.ExtendedProperties[nameKey] = value; }
			}
						
			[LocalizedCategory("MonoXNA")]
			[LocalizedDisplayName("Importer")]
			[LocalizedDescription("The importer to use when reading the content file.")]
			[TypeConverter(typeof(ImporterStringsConverter))]
			public string Importer {
				get {
					object result = file.ExtendedProperties[importerKey];
					return result == null ? "" : (string)result;
				}
				set { file.ExtendedProperties[importerKey] = value; }
			}
			
			[LocalizedCategory("MonoXNA")]
			[LocalizedDisplayName("Processor")]
			[LocalizedDescription("The processor to use when building the content file.")]
			[TypeConverter(typeof(ProcessorStringsConverter))]
			public string Processor {
				get {
					object result = file.ExtendedProperties[processorKey];
					return result == null ? "" : (string)result;
				}
				set { file.ExtendedProperties[processorKey] = value; }
			}
			
			#endregion Properties
			
			#region Nested ContentStringsConverter Class
			
			class ContentStringsConverter : TypeConverter 
			{
				#region TypeConverter Overrides
				
				public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
				{
					return destinationType == typeof(string);
				}
				
				public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
				{
					return sourceType == typeof(string);	
				}
				
				public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
				{
					return value as string;
				}

				public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
				{
					return value as string;
				}
				
				public override bool GetStandardValuesSupported (ITypeDescriptorContext context)
				{
					return true;
				}
				
				public override bool GetStandardValuesExclusive (ITypeDescriptorContext context)
				{
					ContentFileWrapper wrapper = context != null ? context.Instance as ContentFileWrapper : null;
					if (wrapper != null && wrapper.file != null)
					{
						ContentProject project = wrapper.file.Project as ContentProject;
						return project != null;
					}
					return false;
				}
				
				#endregion TypeConverter Overrides
			}
			
			#endregion Nested ContentStringConverter Class
			
			#region Nested ImporterStringConverter Class
		
			[MonoDevelop.Components.PropertyGrid.PropertyEditors.StandardValuesSeparator("--")]
			class ImporterStringsConverter : ContentStringsConverter
			{
				#region TypeConverter Overrides
				
				public override StandardValuesCollection GetStandardValues (ITypeDescriptorContext context)
				{
					ContentFileWrapper wrapper = context != null ? context.Instance as ContentFileWrapper : null;
					if (wrapper != null && wrapper.file != null)
					{
						ContentProject project = wrapper.file.Project as ContentProject;
						if (project != null)
							return new StandardValuesCollection(project.GetImporterNames());
					}
					return new StandardValuesCollection(null);
				}
				
				public override bool IsValid (ITypeDescriptorContext context, object value)
				{
					if (!(value is string))
						return false;
					string str = value as string;
					ContentFileWrapper wrapper = context != null ? context.Instance as ContentFileWrapper : null;
					if (wrapper != null && wrapper.file != null)
					{
						ContentProject project = wrapper.file.Project as ContentProject;
						if (project != null)
						{
							foreach (string name in project.GetImporterNames())
							{
								if (name == str)
									return true;
							}
						}
					}
					return false;
				}
				
				#endregion TypeConverter Overrides
			}
			
			#endregion Nested ImporterStringsConverter Class
			
			#region Nested ProcessorStringsConverter Class
		
			[MonoDevelop.Components.PropertyGrid.PropertyEditors.StandardValuesSeparator("--")]
			class ProcessorStringsConverter : ContentStringsConverter
			{
				#region TypeConverter Overrides
				
				public override StandardValuesCollection GetStandardValues (ITypeDescriptorContext context)
				{
					ContentFileWrapper wrapper = context != null ? context.Instance as ContentFileWrapper : null;
					if (wrapper != null && wrapper.file != null)
					{
						ContentProject project = wrapper.file.Project as ContentProject;
						if (project != null)
							return new StandardValuesCollection(project.GetProcessorNames());
					}
					return new StandardValuesCollection(null);
				}
				
				public override bool IsValid (ITypeDescriptorContext context, object value)
				{
					if (!(value is string))
						return false;
					string str = value as string;
					ContentFileWrapper wrapper = context != null ? context.Instance as ContentFileWrapper : null;
					if (wrapper != null && wrapper.file != null)
					{
						ContentProject project = wrapper.file.Project as ContentProject;
						if (project != null)
						{
							foreach (string name in project.GetProcessorNames())
							{
								if (name == str)
									return true;
							}
						}
					}
					return false;
				}
				
				#endregion TypeConverter Overrides
			}
			
			#endregion Nested ProcessorStringsConverter Class
			
		}
		
		#endregion Nested ContentFileWrapper Class		
	}
}
