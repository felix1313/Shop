using System.Collections.Generic;
using System.Linq;
using WHO.DW.DMT.Models.ActionsServices.Actions;

namespace WHO.DW.DMT.Models.ActionsServices.ActionAcceptors
{
	public class AggregateActionAcceptor : IActionAcceptor
	{
		public IEnumerable<IActionAcceptor> Acceptors { get; set; }

		public bool IsAccepted(Action action)
		{
			return Acceptors.All(a => a.IsAccepted(action));
		}
	}
}