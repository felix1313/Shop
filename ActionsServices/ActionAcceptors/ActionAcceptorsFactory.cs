using WHO.DW.DMT.Models.ActionsServices.Actions;

namespace WHO.DW.DMT.Models.ActionsServices.ActionAcceptors
{
	public static class ActionAcceptorsFactory
	{
		public static IActionAcceptor AcceptAll()
		{
			return new FuncActionAcceptor { Func = action => true };
		}

		public static IActionAcceptor MeasureStateChange()
		{
			return new FuncActionAcceptor
			{
				Func = action => action.Entity == Entity.Measure &&
								action.Field == "DataState"
			};
		}

		public static IActionAcceptor UserRegister()
		{
			return new FuncActionAcceptor
			{
				Func = action => action.Entity == Entity.User && action.ActionType == ActionType.Created
			};
		}
	}
}