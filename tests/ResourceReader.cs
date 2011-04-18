using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Tests
{
    public static class ResourceReader
    {
        public static Stream GetResourceStream(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            Console.WriteLine("looking for " + resourceName);
            foreach (string name in names)
            {
                Console.WriteLine(name);
                if (name.IndexOf(resourceName) != -1)
                {
                    Console.WriteLine("Found: " + name);
                    return assembly.GetManifestResourceStream(name);
                }
            }

            return null;
        }
    }
}
