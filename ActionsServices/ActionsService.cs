using System.Collections.Generic;
using WHO.DW.DMT.Models.ActionsServices.Actions;
using WHO.DW.DMT.Models.ActionsServices.Handlers;

namespace WHO.DW.DMT.Models.ActionsServices
{
	public static class ActionsService
	{
		static ActionsService()
		{
			Handlers = new HashSet<HandlerBase>();
		}

		public static void InitializeHandlers()
		{
			Handlers.Add(new DatabaseHandler());
			Handlers.Add(new DataManagerEmailHandler());
			Handlers.Add(new AdminEmailHandler());
		}

		private static readonly HashSet<HandlerBase> Handlers;

		public static void AddHandler(HandlerBase handler)
		{
			Handlers.Add(handler);
		}

		public static void RemoteHandler(HandlerBase handler)
		{
			Handlers.Remove(handler);
		}

		public static void Notify(Action action)
		{
			foreach (HandlerBase handler in Handlers)
			{
				handler.Accept(action);
			}
		}
	}
}