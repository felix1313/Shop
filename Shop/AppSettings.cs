using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Shop.Enums;

namespace Shop
{
    public static class AppSettings
    {
        public static Language DeafaultLanguage
        {
            get
            {
                return (Language) Enum.Parse(typeof (Language), ConfigurationManager.AppSettings["DefaultLang"], true);
            }
        }
    }
}