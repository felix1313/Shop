using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Shop.Localization
{
    public class CamelCaseKeyGenerator : ITranslationsKeyGenerator
    {
        public string GenerateKey(IEnumerable<string> keyWords)
        {
            StringBuilder res = new StringBuilder();

            foreach (string s in keyWords)
            {
                string t = s[0].ToString().ToUpper() + s.Substring(1).ToLower();
                res.Append(t);
            }

            return res.ToString();
        }
    }
}