using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Shop.Enums;

namespace Shop.Localization
{
	public static class TranslationsProviderFactory
	{
		public static AbstractTranslationsProvider GetTranslationsProvider(TranslationsProviderType type, Language lang)
		{
			switch (type)
			{
				case TranslationsProviderType.Properties:
					{
						string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations.properties");
						return new PropertiesTranslationsProvider(path, lang);
					}

				default:
					{
						throw new NotImplementedException();
					}
			}
		}
	}
}