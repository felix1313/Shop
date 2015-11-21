using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Attributes
{
    public class DisplayNameAttribute : Attribute
    {
        public IEnumerable<string> KeyWords { get; set; }

        public DisplayNameAttribute(params string[] keys)
        {
            KeyWords = new List<string>(keys);
        }
    }
}