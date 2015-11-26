using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Observers
{
	public static class ActionFactory
	{
		public static SimpleAction CreateSimpleAction(string s)
		{
			return new SimpleAction {Message = s};
		}
	}
}