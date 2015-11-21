using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WHO.DW.DMT.Models.ActionsServices.Actions
{
	[Table("ActionsLog")]
	public class Action
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Timestamp")]
		public DateTime Timestamp { get; set; }

		public int UserId { get; set; }

		[NotMapped]
		public ActionType ActionType { get; set; }

		[Column("ActionType")]
		[DisplayName("Action type")]
		public string ActionTypeString
		{
			get { return ActionType.ToString(); }
			set { ActionType = (ActionType) Enum.Parse(typeof(ActionType), value); }
		}

		[NotMapped]
		public Entity Entity { get; set; }

		[Column("Entity")]
		[DisplayName("Entity")]
		public string EntityString
		{
			get { return Entity.ToString(); }
			set { Entity = (Entity) Enum.Parse(typeof(Entity), value); }
		}

		[DisplayName("Code")]
		public string Code { get; set; }

		[DisplayName("Field")]
		public string Field { get; set; }

		[DisplayName("Old value")]
		public string OldValue { get; set; }

		[DisplayName("New value")]
		public string NewValue { get; set; }

		[DisplayName("User")]
		public virtual User User { get; set; }

		public void SetCurrentUser()
		{
			UserId = int.Parse(HttpContext.Current.User.Identity.GetUserId());
		}

		public void SetCurrentDate()
		{
			Timestamp = DateTime.Now;
		}

		public void SetCurrnetUserAndDate()
		{
			SetCurrentUser();
			SetCurrentDate();
		}
	}
}