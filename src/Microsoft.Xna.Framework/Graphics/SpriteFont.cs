using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class SpriteFont
    {
        private Texture2D texture;
        private List<Rectangle> glyphs;
        private List<Rectangle> cropping;
        private List<Char> charmap;
        private int lineSpacing;
        private float spacing;
        private List<Vector3> kerning;
        private char? defaultchar;
        private ReadOnlyCollection<char> characters;

        internal SpriteFont(Texture2D texture, List<Rectangle> glyphs, List<Rectangle> cropping, List<char> charMap, int lineSpacing, float spacing, List<Vector3> kerning, char? defaultchar)
        {
            this.texture = texture;
            this.glyphs = glyphs;
            this.cropping = cropping;
            this.charmap = charMap;
            this.lineSpacing = lineSpacing;
            this.spacing = spacing;
            this.kerning = kerning;
            this.defaultchar = defaultchar;
        }

        public ReadOnlyCollection<char> Characters
        {
            get
            {
                if (this.characters == null)
                {
                    this.characters = new ReadOnlyCollection<char>(this.charmap);
                }
                return this.characters;
            }
        }
        public char? DefaultCharacter
        {
            get
            {
                return this.defaultchar;
            }
            set
            {
                if (value.HasValue && !this.charmap.Contains(value.Value))
                {
                    throw new ArgumentException("Char not in font");
                }
                this.defaultchar = value;
            }
        }

        public int LineSpacing
        {
            get
            {
                return this.lineSpacing;
            }
            set
            {
                this.lineSpacing = value;
            }
        }

        public float Spacing
        {
            get
            {
                return this.spacing;
            }
            set
            {
                this.spacing = value;
            }
        }

        public Vector2 MeasureString(string text)
        {
            return this.Measure(ref text);
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            throw new NotImplementedException();
        }

        internal void Draw(ref string text, SpriteBatch spriteBatch, Vector2 Position, Color color, float rotation, Vector2 origin, ref Vector2 scale, SpriteEffects spriteEffects, float depth)
        {
            Vector2 pos;
            Matrix matrix;
            Matrix Rotationmatrix;
            Matrix.CreateRotationZ(rotation, out Rotationmatrix);
            Matrix.CreateTranslation(-origin.X * scale.X, -origin.Y * scale.Y, 0f, out matrix);
            Matrix.Multiply(ref matrix, ref Rotationmatrix, out Rotationmatrix);
            int flip = 1;
            float beginningofline = 0f;
            bool flag = true;
            if ((spriteEffects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally)
            {
                beginningofline = this.Measure(ref text).X * scale.X;
                flip = -1;
            }
            if ((spriteEffects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically)
            {
                pos.Y = (this.Measure(ref text).Y - this.lineSpacing) * scale.Y;
            }
            else
            {
                pos.Y = 0f;
            }
            pos.X = beginningofline;
            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                switch (character)
                {
                    case '\r':
                        break;

                    case '\n':
                        flag = true;
                        pos.X = beginningofline;
                        if ((spriteEffects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically)
                        {
                            pos.Y -= this.lineSpacing * scale.Y;
                        }
                        else
                        {
                            pos.Y += this.lineSpacing * scale.Y;
                        }
                        break;

                    default:
                        {
                            int indexForCharacter = this.CharacterIndex(character);
                            Vector3 charkerning = this.kerning[indexForCharacter];
                            if (flag)
                            {
                                charkerning.X = Math.Max(charkerning.X, 0f);
                            }
                            else
                            {
                                pos.X += (this.spacing * scale.X) * flip;
                            }
                            pos.X += (charkerning.X * scale.X) * flip;
                            Rectangle rectangle = this.glyphs[indexForCharacter];
                            Rectangle rectangle2 = this.cropping[indexForCharacter];
                            if ((spriteEffects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically)
                            {
                                rectangle2.Y = (this.lineSpacing - rectangle.Height) - rectangle2.Y;
                            }
                            if ((spriteEffects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally)
                            {
                                rectangle2.X -= rectangle2.Width;
                            }
                            Vector2 position = pos;
                            position.X += rectangle2.X * scale.X;
                            position.Y += rectangle2.Y * scale.Y;
                            Vector2.Transform(ref position, ref Rotationmatrix, out position);
                            position += Position;
                            spriteBatch.Draw(this.texture, position, new Rectangle?(rectangle), color, rotation, Vector2.Zero, scale, spriteEffects, depth);
                            flag = false;
                            pos.X += ((charkerning.Y + charkerning.Z) * scale.X) * flip;
                            break;
                        }
                }
            }
        }

        private int CharacterIndex(char character)
        {
            int lowindex = 0;
            int highindex = this.charmap.Count - 1;
            while (lowindex <= highindex)
            {
                int index = lowindex + ((highindex - lowindex) >> 1);
                if (this.charmap[index] == character)
                {
                    return index;
                }
                if (this.charmap[index] < character)
                {
                    lowindex = index + 1;
                }
                else
                {
                    highindex = index - 1;
                }
            }
            if (this.defaultchar.HasValue)
            {
                char ch = this.defaultchar.Value;
                if (character != ch)
                {
                    return this.CharacterIndex(ch);
                }
            }
            throw new ArgumentException("Character not in Font");
        }

        private Vector2 Measure(ref String text)
        {
            if (text.Length == 0)
            {
                return Vector2.Zero;
            }
            Vector2 zero = Vector2.Zero;
            zero.Y = this.lineSpacing;
            float min = 0f;
            int count = 0;
            float z = 0f;
            bool flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '\r')
                {
                    if (text[i] == '\n')
                    {
                        zero.X += Math.Max(z, 0f);
                        z = 0f;
                        min = Math.Max(zero.X, min);
                        zero = Vector2.Zero;
                        zero.Y = this.lineSpacing;
                        flag = true;
                        count++;
                    }
                    else
                    {
                        Vector3 vector2 = this.kerning[this.CharacterIndex(text[i])];
                        if (flag)
                        {
                            vector2.X = Math.Max(vector2.X, 0f);
                        }
                        else
                        {
                            zero.X += this.spacing + z;
                        }
                        zero.X += vector2.X + vector2.Y;
                        z = vector2.Z;
                        Rectangle rectangle = this.cropping[this.CharacterIndex(text[i])];
                        zero.Y = Math.Max(zero.Y, (float)rectangle.Height);
                        flag = false;
                    }
                }
            }
            zero.X += Math.Max(z, 0f);
            zero.Y += count * this.lineSpacing;
            zero.X = Math.Max(zero.X, min);
            return zero;
        }

    }
}
