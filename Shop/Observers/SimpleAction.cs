using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Observers
{
	public class SimpleAction : IAction
	{
		public string Message { get; set; }
	}
}