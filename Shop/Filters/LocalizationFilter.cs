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
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            Language lang = AppSettings.DeafaultLanguage;
            if (context.HttpContext.Session != null && context.HttpContext.Session["lang"] != null)
            {
                Enum.TryParse(context.HttpContext.Session["lang"].ToString(), out lang);
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations.properties");

	        context.HttpContext.Items["Translations"] = new PropertiesTranslationsProvider(path, lang);
        }
    }
}