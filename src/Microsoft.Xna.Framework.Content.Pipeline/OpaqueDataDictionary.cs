// OpaqueDataDictionary.cs created with MonoDevelop
// User: lars at 03.45 22.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class OpaqueDataDictionary : NamedValueDictionary<Object>
	{

#region Constructor
		
		public OpaqueDataDictionary()
		{
		}
		
#endregion
		
#region Public Methods
		
		public string GetContentAsXml()
		{
			throw new NotImplementedException();
		}
		
		public T GetValue<T>(string key, T defaultValue)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods
		
		protected override void SetItem(string key, Object value)
		{
			throw new NotImplementedException();
		}
		
		protected internal override Type DefaultSerializerType 
		{ 
			get { throw new NotImplementedException(); }
		}

		protected override void AddItem(string key, Object value)
		{
			throw new NotImplementedException();
		}
		
		protected override void ClearItems()
		{
			throw new NotImplementedException();
		}

		protected override bool RemoveItem(string key)
		{
			throw new NotImplementedException();
		}

#endregion
		
	}
}
