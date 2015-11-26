using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Enums;
using Shop.Localization;

namespace Shop.Filters
{
    public class LocalizationFilter : ActionFilterAttribute
    {
		public override void OnActionExecuting(ActionExecutingContext context)
        {
            Language lang = AppSettings.DeafaultLanguage;
			var param = context.HttpContext.Request.QueryString["lang"];
			if (param != null)
			{
				Enum.TryParse(param, true, out lang);
				context.HttpContext.Session["lang"] = lang;
			}
            if (context.HttpContext.Session != null && context.HttpContext.Session["lang"] != null)
            {
	            lang = (Language) (context.HttpContext.Session["lang"]);
            }

	        context.HttpContext.Items["Translations"] =
		        TranslationsProviderFactory.GetTranslationsProvider(AppSettings.TranslationsProviderType, lang);
        }
    }
}