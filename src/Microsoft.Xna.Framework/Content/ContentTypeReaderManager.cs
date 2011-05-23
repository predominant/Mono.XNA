#region License
/*
MIT License
Copyright © 2011 The MonoXNA Team

All rights reserved.

Authors:
 * Lars Magnusson <lavima@gmail.com>

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
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework.Content.Readers;

namespace Microsoft.Xna.Framework.Content
{
    public sealed class ContentTypeReaderManager
    {
		#region Fields
		
        private ContentReader contentReader;
        private static Dictionary<string, ContentTypeReader> nameToReader = new Dictionary<string, ContentTypeReader>();
        private static Dictionary<Type, ContentTypeReader> readerTypeToReader = new Dictionary<Type, ContentTypeReader>();
        private static Dictionary<Type, ContentTypeReader> targetTypeToReader = new Dictionary<Type, ContentTypeReader>();
		
		#endregion Fields
		
		#region Constructors

        static ContentTypeReaderManager()
        {
            ContentTypeReader reader = new ObjectReader();
            targetTypeToReader.Add(typeof(object), reader);
            readerTypeToReader.Add(typeof(ObjectReader), reader);
        }

        private ContentTypeReaderManager(ContentReader contentReader)
        {
            this.contentReader = contentReader;
        }
		
		#endregion Constructors
		
		#region Methods

        public ContentTypeReader GetTypeReader(Type targetType)
        {
            return GetTypeReader(targetType, this.contentReader);
        }

        internal static ContentTypeReader GetTypeReader(Type targetType, ContentReader contentReader)
        {
            ContentTypeReader reader;
            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }
            lock (nameToReader)
            {
                if (!targetTypeToReader.TryGetValue(targetType, out reader))
                {
                    throw new ContentLoadException("TypeReader not registered");
                }
            }
            return reader;
        }

        internal static ContentTypeReader[] ReadTypeManifest(int typeCount, ContentReader contentReader)
        {
            ContentTypeReader[] readers = new ContentTypeReader[typeCount];
            List<ContentTypeReader> newTypeReaders = null;
            try
            {
                for (int i = 0; i < typeCount; i++)
                {
                    string typename = contentReader.ReadString();
                    if (typename.Contains("PublicKey"))
                    {
                        typename = typename.Split(new char[] { '[', '[' })[0] + "[" + typename.Split(new char[] { '[', '[' })[2].Split(',')[0] + "]"; //FIXME: Fix for cross-assembly reference problem. Maybe bad solution. Problem: tried to load type from msxna assembly.
                    }
                    ContentTypeReader reader = GetTypeReader(typename, contentReader, ref newTypeReaders);
                    if (contentReader.ReadInt32() != reader.TypeVersion)
                    {
                        throw new ContentLoadException("Bad XNB TypeVersion");
                    }
                    readers[i] = reader;
                }
                if (newTypeReaders != null)
                {
                    ContentTypeReaderManager manager = new ContentTypeReaderManager(contentReader);
                    foreach (ContentTypeReader reader2 in newTypeReaders)
                    {
                        reader2.Initialize(manager);
                    }
                }
                return readers;
            }
            catch
            {
                RollbackAddReaders(newTypeReaders);
                throw;
            }
            return readers;
        }

        private static void AddTypeReader(string readerTypeName, ContentReader contentReader, ContentTypeReader reader)
        {
            Type targetType = reader.TargetType;
            if (targetType != null)
            {
                if (targetTypeToReader.ContainsKey(targetType))
                {
                    throw new ContentLoadException("TypeReader duplicate");
                }
                targetTypeToReader.Add(targetType, reader);
            }
            readerTypeToReader.Add(reader.GetType(), reader);
            nameToReader.Add(readerTypeName, reader);
        }

        private static ContentTypeReader GetTypeReader(string readerTypeName, ContentReader contentReader, ref List<ContentTypeReader> newTypeReaders)
        {
            lock (nameToReader)
            {
                ContentTypeReader reader;
                if (!nameToReader.TryGetValue(readerTypeName, out reader) && InstantiateTypeReader(readerTypeName, contentReader, out reader))
                {
                    AddTypeReader(readerTypeName, contentReader, reader);
                    
					if (newTypeReaders == null)
                        newTypeReaders = new List<ContentTypeReader>();
                    newTypeReaders.Add(reader);
                }
                return reader;
            }
        }

        private static bool InstantiateTypeReader(string readerTypeName, ContentReader contentReader, out ContentTypeReader reader)
        {
            try
            {
                Type key = Type.GetType(readerTypeName);
                if (key == null)
                {
                    throw new ContentLoadException("TypeReader not found");
                }
                if (readerTypeToReader.TryGetValue(key, out reader))
                {
                    nameToReader.Add(readerTypeName, reader);
                    return false;
                }
                reader = (ContentTypeReader)Activator.CreateInstance(key);
            }
            catch (Exception exception)
            {
                if ((((exception is ArgumentException) || (exception is TargetInvocationException)) || ((exception is TypeLoadException) || (exception is NotSupportedException))) || ((exception is MemberAccessException) || (exception is InvalidCastException)))
                {
                    throw new ContentLoadException("TypeReader invalid");
                }
                throw;
            }
            return true;
        }

        private static void RollbackAddReader<T>(Dictionary<T, ContentTypeReader> dictionary, ContentTypeReader reader)
        {
            IEnumerator<KeyValuePair<T, ContentTypeReader>> enumerator = dictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<T, ContentTypeReader> current = enumerator.Current;
                if (current.Value == reader)
                {
                    KeyValuePair<T, ContentTypeReader> pair = enumerator.Current;
                    dictionary.Remove(pair.Key);
                    enumerator = dictionary.GetEnumerator();
                }
            }
        }

        private static void RollbackAddReaders(List<ContentTypeReader> newTypeReaders)
        {
            if (newTypeReaders != null)
            {
                lock (nameToReader)
                {
                    foreach (ContentTypeReader reader in newTypeReaders)
                    {
                        RollbackAddReader<string>(nameToReader, reader);
                        RollbackAddReader<Type>(targetTypeToReader, reader);
                        RollbackAddReader<Type>(readerTypeToReader, reader);
                    }
                }
            }
        }
		
		#endregion Methods
    }
}
