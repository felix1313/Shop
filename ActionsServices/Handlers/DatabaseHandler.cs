using WHO.DW.DMT.DataProviders;
using WHO.DW.DMT.Models.ActionsServices.ActionAcceptors;
using WHO.DW.DMT.Models.ActionsServices.Actions;

namespace WHO.DW.DMT.Models.ActionsServices.Handlers
{
	public class DatabaseHandler : HandlerBase
	{
		public DatabaseHandler() : base(ActionAcceptorsFactory.AcceptAll())
		{
		}

		protected override void notify(Action action)
		{
			DmtDataProvider.AddAction(action);
		}
	}
}