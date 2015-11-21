using WHO.DW.DMT.Models.ActionsServices.ActionAcceptors;
using WHO.DW.DMT.Models.ActionsServices.Actions;

namespace WHO.DW.DMT.Models.ActionsServices.Handlers
{
	public abstract class HandlerBase
	{
		protected HandlerBase(IActionAcceptor acceptor)
		{
			this.acceptor = acceptor;
		}

		private readonly IActionAcceptor acceptor;

		public void Accept(Action action)
		{
			if (acceptor.IsAccepted(action))
			{
				notify(action);
			}
		}

		protected abstract void notify(Action action);
	}
}