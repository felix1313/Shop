using WHO.DW.DMT.Models.ActionsServices.Actions;

namespace WHO.DW.DMT.Models.ActionsServices.ActionAcceptors
{
	public interface IActionAcceptor
	{
		bool IsAccepted(Action action);
	}
}