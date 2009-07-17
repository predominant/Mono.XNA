
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;

namespace MonoDevelop.Xna
{
	
	[DataItem]
	public class Compile : ProjectItem
	{		
		#region Properties
		
		[ItemProperty("Include")]
		private string include;
		public string Include
		{
			get { return include; }
			set { include = value; }
		}
		
		[ItemProperty("Importer")]
		private string importer;
		public string Importer
		{
			get { return importer; }
			set { importer = value; }
		}
		
		[ItemProperty("Processor")]
		private string processor;
		public string Processor
		{
			get { return processor; }
			set { processor = value; }
		}
		
		[ItemProperty("Name")]
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		
		#endregion
		
		#region Constructors
		
		public Compile()
		{
		}
		
		public Compile(string include, string name, string importer, string processor)
		{
			this.include = include;	
			this.name = name;
			this.importer = importer;
			this.processor = processor;
		}
		
		#endregion
		
		
	}
}
