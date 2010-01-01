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

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class GeometryContent : ContentItem
    {

    #region Private Fields
    private IndexCollection indices = new IndexCollection();
    private MaterialContent material;
    private MeshContent parent;
    private VertexContent vertices;
    #endregion

    #region Constructor
    public GeometryContent()
    {
        this.vertices = new VertexContent(this);
    }
    #endregion

    #region Properties
    public IndexCollection Indices
    {
        get
        {
            return this.indices;
        }
    }

    [ContentSerializer(Optional=true, SharedResource=true)]
    public MaterialContent Material
    {
        get
        {
            return this.material;
        }
        set
        {
            this.material = value;
        }
    }

    [ContentSerializerIgnore]
    public MeshContent Parent
    {
        get
        {
            return this.parent;
        }
        internal set
        {
            this.parent = value;
        }
    }

    public VertexContent Vertices
    {
        get
        {
            return this.vertices;
        }
    }
    #endregion

    }
}
