using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Shop.Enums;

namespace Shop.Localization
{
    public class PropertiesTranslationsProvider : AbstractTranslationsProvider
    {
        private Dictionary<string, string> _dictionary =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase); 

        private void ReadFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] val = line.Split('=');

                if (val.Length != 2)
                {
                    throw new FileLoadException("Invalid file format");
                }

                _dictionary[val[0].Trim()] = val[1].Trim();
            }
        }

        public PropertiesTranslationsProvider(string fileName, Language lang) : base(lang, new DotSeparatedKeyGenerator())
        {
            try
            {
                ReadFile(fileName + lang);
            }
            catch (FileNotFoundException)
            {
                ReadFile(fileName);
            }
        }

        public override string GetTranslation(IEnumerable<string> keyStrings)
        {
            string key = KeyGenerator.GenerateKey(keyStrings);
            try
            {
                return _dictionary[key];
            }
            catch (Exception)
            {
                return key;
            }
        }
    }
}