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
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{


    public class GetLastOutputs : Task
    {

        #region Constructor

        public GetLastOutputs()
        {
        }

        #endregion

        #region Properties

        private string intermediateDirectory;
        [Required]
        public string IntermediateDirectory
        {
            get
            {
                return intermediateDirectory;
            }
            set
            {
                intermediateDirectory = value;
            }
        }

        private ITaskItem[] outputContentFiles;
        [Output]
        public ITaskItem[] OutputContentFiles
        {
            get
            {
                return outputContentFiles;
            }
        }

        #endregion

        #region Public Methods

        public override bool Execute()
        {
            if (string.IsNullOrEmpty(IntermediateDirectory))
            {
                base.Log.LogError("IntermediateDirectory is null or empty");
            }
            string path = null;
            try
            {
                path = Path.Combine(IntermediateDirectory, "ContentPipeline.xml");
            }
            catch (ArgumentException)
            {
                base.Log.LogError("IntermediateDirectory invalid");
            }

            if (base.Log.HasLoggedErrors)
            {
                return false;
            }

            List<ITaskItem> list = new List<ITaskItem>();
            if (File.Exists(path))
            {
                XPathNavigator navigator = null;
                try
                {
                    navigator = new XPathDocument(path).CreateNavigator();
                    if (BuildWasSuccessful(navigator))
                    {
                        XPathNodeIterator outputiterator = navigator.Select("/XnaContent/Asset/Item[not(contains(Options,'IntermediateFile'))]/Output");
                        XPathNodeIterator extraiterator = navigator.Select("/XnaContent/Asset/Item[not(contains(Options,'IntermediateFile'))]/Extra");
                        while (outputiterator.MoveNext())
                        {
                            list.Add(new TaskItem(outputiterator.Current.Value));
                        }
                        while (extraiterator.MoveNext())
                        {
                            list.Add(new TaskItem(extraiterator.Current.Value));
                        }
                    }
                }
                catch (XmlException)
                {
                }
            }
            this.outputContentFiles = list.ToArray();
            return !base.Log.HasLoggedErrors;
        }

        static bool BuildWasSuccessful(System.Xml.XPath.XPathNavigator navigator)
        {
            bool valueAsBoolean = false;
            XPathNodeIterator iterator = navigator.Select("XnaContent/Asset/BuildSuccessful");
            iterator.MoveNext();
            try
            {
                valueAsBoolean = iterator.Current.ValueAsBoolean;
            }
            catch (FormatException)
            {
            }
            catch (InvalidCastException)
            {
            }
            return valueAsBoolean;
        }


        #endregion

    }
}
