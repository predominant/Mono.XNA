// IntermediateSerializer.cs created with MonoDevelop
// User: lars at 11.03 21.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Xml;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate
{
    
    
    public sealed class IntermediateSerializer
    {
        
#region Constructor        
        
        public IntermediateSerializer()
        {
        }

#endregion
        
#region Public Methods
        
        public static T Deserialize<T>(XmlReader input, string referenceRelocationPath)
        {
            throw new NotImplementedException();
        }
        
        public static void Serialize<T>(XmlWriter output, T value, string referenceRelocationPath)
        {
            throw new NotImplementedException();
        }
        
        public ContentTypeSerializer GetTypeSerializer(Type type)
        {
            throw new NotImplementedException();
        }
        
#endregion        
        
    }
}
