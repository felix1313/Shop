using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Enums;

namespace Shop.Localization
{
    public abstract class AbstractTranslationsProvider
    {
        public Language Lang { get; set; }

        public ITranslationsKeyGenerator KeyGenerator { protected get; set; }

        public string GetTranslation(params string[] keyStrings)
        {
            List<string> l = keyStrings.ToList();
            return GetTranslation(l);
        }

        public abstract string GetTranslation(IEnumerable<string> keyStrings);

        protected AbstractTranslationsProvider(Language lang, ITranslationsKeyGenerator keyGenerator)
        {
            this.Lang = lang;
            this.KeyGenerator = keyGenerator;
        }
    }
}