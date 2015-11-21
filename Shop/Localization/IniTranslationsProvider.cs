using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Enums;

namespace Shop.Localization
{
    public class IniTranslationsProvider : AbstractTranslationsProvider
    {
        public IniTranslationsProvider(Language lang) : base(lang, new CamelCaseKeyGenerator())
        {
            throw  new NotImplementedException();
        }

        public override string GetTranslation(IEnumerable<string> keyStrings)
        {
            throw new NotImplementedException();
        }
    }
}