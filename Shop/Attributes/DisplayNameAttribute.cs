using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Shop.Helpers;
using Shop.Localization;

namespace Shop.Attributes
{
    public class MyDisplayNameAttribute : DisplayNameAttribute
    {
        public IEnumerable<string> KeyWords { get; set; }

        public MyDisplayNameAttribute(params string[] keys)
        {
            KeyWords = new List<string>(keys);
        }

	    public override string DisplayName
	    {
		    get
		    {
			    return
				    (((AbstractTranslationsProvider) HttpContext.Current.Items[Constants.CONTEXT_TRANSLATIONS]).GetTranslation(
					    KeyWords));
		    }
	    }
    }
}