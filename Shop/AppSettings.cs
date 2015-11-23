using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Shop.Enums;
using Shop.Localization;

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

	    public static TranslationsProviderType TranslationsProviderType 
	    {
		    get
		    {
			    return
				    (TranslationsProviderType)
					    Enum.Parse(typeof (TranslationsProviderType), ConfigurationManager.AppSettings["TranslationsProvider"], true);
		    }
	    }
    }
}