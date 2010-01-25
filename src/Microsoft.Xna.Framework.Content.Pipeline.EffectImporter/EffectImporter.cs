using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.EffectImporter
{
    [ContentImporter(".fx", DefaultProcessor = "EffectProcessor", DisplayName="Effect - XNA Framework")]
    public class EffectImporter : ContentImporter<EffectContent>
    {
        public override EffectContent Import(string filename, ContentImporterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("filename");
            }
            FileInfo info = new FileInfo(filename);
            if (!info.Exists)
            {
                throw new FileNotFoundException("File: " + filename + " not found.");
            }
            EffectContent content = new EffectContent();
            content.Identity = new ContentIdentity(info.FullName, "EffectImporter");
            content.EffectCode = File.ReadAllText(filename);
            return content;
        }
    }
}
