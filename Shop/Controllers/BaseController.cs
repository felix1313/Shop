using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Observers;

namespace Shop.Controllers
{
    public class BaseController : Controller, IObservable
    {

		private readonly List<IObserver> _observers = new List<IObserver>();

		protected IDisplayModelsProvider DisplayModelsProvider = new DisplayModelsDataBaseProvider();

	    public bool IsUserAuthenticated
	    {
		    get { return Session["user"] != null; }
	    }

		public new RedirectToRouteResult RedirectToAction(string action, string controller)
		{
			return base.RedirectToAction(action, controller);
		}

		public void AddObserver(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void Notify(IAction a)
		{
			foreach (IObserver observer in _observers)
			{
				observer.DoAction(a);
			}
		}
    }
}
