
using System;

namespace Microsoft.Xna.Framework.Graphics
{		
	class Sprite
    {
		#region Private Fields
		
        private Texture2D texture;
        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;
        private Color color;
        private float rotation;
        private Vector2 origin;
        private SpriteEffects effects;
        private float layerDepth;
		
		#endregion Private Fields
		
		#region Properties
		
		public Texture2D Texture {
			get { return texture ; }
		}
		
		public Rectangle SourceRectangle {
			get { return sourceRectangle; }	
		}
		
		public Rectangle DestinationRectangle {
			get { return destinationRectangle; }	
		}
		
		public Color Color {
			get { return color; }	
		}
		
		public float Rotation {
			get { return rotation; }	
		}
		
		public Vector2 Origin {
			get { return origin; }	
		}
		
		public SpriteEffects Effects {
			get { return effects; }	
		}
		
		public float LayerDepth {
			get { return layerDepth; }	
		}
		
		#endregion Properties
		
		#region Constructor
		
		public Sprite(Texture2D texture, Rectangle sourceRectangle, Rectangle destinationRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
		{
			this.texture = texture;
			this.sourceRectangle = sourceRectangle;
			this.destinationRectangle = destinationRectangle;
			this.color = color;
			this.rotation = rotation;
			this.origin = origin;
			this.effects = effects;
			this.layerDepth = layerDepth;
		}
		
		#endregion
		
    }
}