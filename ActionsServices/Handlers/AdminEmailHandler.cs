using System.Collections.Generic;
using System.Linq;
using WHO.DW.DMT.DataProviders;
using WHO.DW.DMT.Models.ActionsServices.ActionAcceptors;
using WHO.DW.DMT.Models.ActionsServices.Actions;
using WHO.DW.DMT.Models.EmailServices;

namespace WHO.DW.DMT.Models.ActionsServices.Handlers
{
	public class AdminEmailHandler : HandlerBase
	{
		public AdminEmailHandler() : base(ActionAcceptorsFactory.UserRegister())
		{
		}

		protected override void notify(Action action)
		{
			Email emailPrototype = EmailCreator.CreateEmail(action);

			IEnumerable<User> admins = DmtDataProvider.GetUsers().Where(u => u.Roles.Any(r => r.Name == "Administrator"));

			EmailService.SendEmailsAsync(emailPrototype, admins);
		}
	}
}