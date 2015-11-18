using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Localization
{
    public class DatabaseTranslationsProvider : AbstractTranslationsProvider
    {
        public override string GetTranslation(IEnumerable<string> keyStrings)
        {
            string key = KeyGenerator.GenerateKey(keyStrings);
            throw new NotImplementedException();
        }
    }
}