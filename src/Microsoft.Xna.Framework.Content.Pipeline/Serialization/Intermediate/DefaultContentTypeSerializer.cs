using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{
	public class DefaultContentTypeSerializer : ContentTypeSerializer
	{
		#region Constructor
		
		public DefaultContentTypeSerializer (Type targetType)
			: base(targetType)
		{
		}
		
		#endregion Constructor
		
		#region ContentTypeSerializer Overrides
		
		protected internal override void ScanChildren (IntermediateSerializer serializer, ChildCallback callback, object value)
		{
			base.ScanChildren (serializer, callback, value);
		}
		
		protected internal override object Deserialize (IntermediateReader input, ContentSerializerAttribute format, object existingInstance)
		{
			throw new System.NotImplementedException();
		}
		
		
		protected internal override void Serialize (IntermediateWriter output, object value, ContentSerializerAttribute format)
		{
			throw new System.NotImplementedException();
		}
		
		#endregion ContentTypeSerializer Overrides
	}
}

