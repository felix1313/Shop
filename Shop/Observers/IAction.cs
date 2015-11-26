using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Observers
{
	public interface IAction
	{
		string Message { get; }
	}
}