using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Shop.Enums
{
    public enum Language
    {
        En,
        Ua
    }

    public static class LanguageExtentions
    {
        public static string ToFullString(this Language lang)
        {
            switch (lang)
            {
                case Language.En:
                    return "English";
                case Language.Ua:
                    return "Українська";
                default:
                    throw new NotImplementedException(lang.ToString());
            }
        }
    }
}