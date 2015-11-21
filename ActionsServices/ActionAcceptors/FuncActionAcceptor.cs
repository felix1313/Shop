using System;
using Action = WHO.DW.DMT.Models.ActionsServices.Actions.Action;

namespace WHO.DW.DMT.Models.ActionsServices.ActionAcceptors
{
	public class FuncActionAcceptor : IActionAcceptor
	{
		public Func<Action, bool> Func { get; set; }

		public bool IsAccepted(Action action)
		{
			return Func(action);
		}
	}
}