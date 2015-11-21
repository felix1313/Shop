using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Localization
{
    public class DotSeparatedKeyGenerator : ITranslationsKeyGenerator
    {
        public string GenerateKey(IEnumerable<string> keyWords)
        {
            return string.Join(".", keyWords.Select(k => k.ToLower()));
        }

        private static DotSeparatedKeyGenerator _instance;

        public static DotSeparatedKeyGenerator Instance
        {
            get { return _instance ?? (_instance = new DotSeparatedKeyGenerator()); }
        }
    }
}