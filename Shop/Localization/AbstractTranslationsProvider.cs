using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Localization
{
    public abstract class AbstractTranslationsProvider
    {
        public ITranslationsKeyGenerator KeyGenerator { protected get; set; }

        public string GetTranslation(params string[] keyStrings)
        {
            List<string> l = keyStrings.ToList();
            return GetTranslation(l);
        }

        public abstract string GetTranslation(IEnumerable<string> keyStrings);
    }
}