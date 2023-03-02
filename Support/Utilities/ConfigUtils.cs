using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDCSharpProject.Support.Utilities
{
    public class ConfigUtils
    {
        public static Dictionary<string, string> ReadProperties(string filePath)
        {
            var properties = new Dictionary<string, string>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length == 0 || line.StartsWith("#"))
                    {
                        continue;
                    }
                    int separatorIndex = line.IndexOf("=");
                    if (separatorIndex == -1)
                    {
                        continue;
                    }
                    string key = line.Substring(0, separatorIndex).Trim();
                    string value = line.Substring(separatorIndex + 1).Trim();
                    properties[key] = value;
                }
            }
            return properties;
        }
    }
}
