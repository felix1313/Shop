using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WHO.DW.Core.Attributes;
using WHO.DW.Core.Enums;
using WHO.DW.Core.Exceptions;
using WHO.DW.Core.Models;
using WHO.DW.DMT.DataProviders;

namespace WHO.DW.DMT.Models.ActionsServices.Actions
{
	public static class ActionFactory
	{
		private const string Separator = "#";

		public static string CodeWithParent(string code, string parentCode)
		{
			return code + Separator + parentCode;
		}

		private static string fieldWithLang(string field, Language lang)
		{
			return fieldWithLang(field, lang.ToString());
		}

		private static string fieldWithLang(string field, string lang)
		{
			return field + Separator + lang;
		}

		private static Action getActionWithUserAndDate(Action action)
		{
			action.SetCurrnetUserAndDate();
			return action;
		}

		public static Action Action(
			ActionType actionType,
			Entity entity,
			string code,
			string field,
			string oldValue,
			string newValue)
		{
			return getActionWithUserAndDate(
				new Action
				{
					ActionType = actionType,
					Entity = entity,
					Code = code,
					Field = field,
					OldValue = oldValue,
					NewValue = newValue
				});
		}

		public static Action CreateAction(
			Entity entity,
			string code)
		{
			return getActionWithUserAndDate(
				new Action
				{
					ActionType = ActionType.Created,
					Entity = entity,
					Code = code,
				});
		}

		public static Action CreateAction(Entity entity, string code, int userId)
		{
			Action result = new Action
			{
				ActionType = ActionType.Created,
				Entity = entity,
				Code = code,
				UserId = userId
			};

			result.SetCurrentDate();
			return result;
		}

		public static Action CreateAction(
			Entity entity,
			string code,
			string parentCode)
		{
			return CreateAction(entity, CodeWithParent(code, parentCode));
		}

		public static Action DeleteAction(
			Entity entity,
			string code)
		{
			return getActionWithUserAndDate(
				new Action
				{
					ActionType = ActionType.Deleted,
					Entity = entity,
					Code = code
				});
		}

		public static Action DeleteAction(
			Entity entity,
			string code,
			string parentCode)
		{
			return DeleteAction(entity, CodeWithParent(code, parentCode));
		}

		public static Action ModifyAction(
			Entity entity,
			string code,
			string field,
			string oldValue,
			string newValue)
		{
			return getActionWithUserAndDate(
				new Action
				{
					ActionType = ActionType.Modified,
					Entity = entity,
					Code = code,
					Field = field,
					OldValue = oldValue,
					NewValue = newValue
				});
		}

		public static Action ModifyAction(
			Entity entity,
			string code,
			string field,
			string oldValue,
			string newValue,
			Language lang)
		{
			return ModifyAction(entity, code, fieldWithLang(field, lang), oldValue, newValue);
		}

		public static Action ModifyAction(
			Entity entity,
			string code,
			string parentCode,
			string field,
			string oldValue,
			string newValue)
		{
			return ModifyAction(entity, CodeWithParent(code, parentCode), field, oldValue, newValue);
		}

		public static Action ModifyAction(
			Entity entity,
			string code,
			string parentCode,
			string field,
			string oldValue,
			string newValue,
			Language lang)
		{
			return ModifyAction(entity, CodeWithParent(code, parentCode), fieldWithLang(field, lang), oldValue, newValue);
		}

		public static Action TranslationAction(Translation translation)
		{
			string oldValue;

			try
			{
				oldValue = DwDataProvider.GetTranslation(
					translation.GroupCode,
					translation.KeyCode,
					translation.FieldCode,
					translation.Lang);
			}
			catch (RecordNotFoundException)
			{
				oldValue = string.Empty;
			}

			if (oldValue == (translation.Label ?? string.Empty))
			{
				return null;
			}

			Action result = getActionWithUserAndDate(
				new Action
				{
					ActionType = ActionType.Modified,
					Entity = (Entity) Enum.Parse(typeof(Entity), translation.GroupCode),
					NewValue = translation.Label ?? string.Empty,
					OldValue = oldValue
				});

			switch (translation.GroupCode)
			{
				case "MetadataAttributeValue":
				case "DataAttributeValue":
					result.Code = CodeWithParent(translation.FieldCode, translation.KeyCode);
					result.Field = fieldWithLang("label", translation.Lang);
					break;

				default:
					result.Code = translation.KeyCode;
					result.Field = fieldWithLang(translation.FieldCode, translation.Lang);
					break;
			}

			return result;
		}

		public static IEnumerable<Action> ModifyAction(object before, object after, Entity entity, string code)
		{
			Type type = after.GetType();
			if (before.GetType() != type)
			{
				throw new Exception("Both arguments should be of the same type in order to create list of modify actions");
			}

			PropertyInfo[] properties = type.GetProperties();

			List<Action> result = new List<Action>();

			foreach (PropertyInfo property in properties)
			{
				Attribute attribute = property.GetCustomAttribute(typeof(DbColumnAttribute));
				if (attribute == null)
				{
					continue;
				}

				if (!((DbColumnAttribute) attribute).Insertable)
				{
					continue;
				}

				object valueBefore = property.GetValue(before);
				object valueAfter = property.GetValue(after);

				string stringBefore = string.Empty;
				string stringAfter = string.Empty;

				if (valueBefore != null)
				{
					stringBefore = valueBefore.ToString();
				}

				if (valueAfter != null)
				{
					stringAfter = valueAfter.ToString();
				}

				if (stringAfter != stringBefore)
				{
					string name = property.Name;
					result.Add(ModifyAction(entity, code, name, stringBefore, stringAfter));
				}
			}

			return result;
		}
	}
}