using Domain.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Infrastructure.Telegram
{
	public class StatusCode
	{
		private static readonly Crud crud = new();

		public static async void Code0(ITelegramBotClient botClient, Update update)
		{
			string? text = update.Message!.Text;
			if (text == "/start")
			{
				string chatId = update.Message!.Chat.Id.ToString();
				BotUser? user = crud.ReadBotUser(chatId);
				if (user == null)
				{
					await Command.StartCommand(botClient, update);
					await Command.CommandA(botClient, update);
					crud.UpdateUser(chatId, 1);
				}
				else
				{
					crud.UpdateUser(chatId, 1);
					await RemoveReplyMarkup(botClient, update);
					await Command.CommandA(botClient, update);
				}
			}
		}

		public static async Task Code1(ITelegramBotClient botClient, Update update)
		{
			string? text = update.Message!.Text;
			string chatId = update.Message!.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 1)
			{
				if (text == "Test Ishlash")
				{
					await RemoveReplyMarkup(botClient, update);
					await Command.Command1B11(botClient, update);
				}
				else if (text == "Test Qo'shish")
				{
					await RemoveReplyMarkup(botClient, update);
					await Command.Command1B12(botClient, update);
				}
				else if (text == "Admin Bilan Bog'lanish")
				{
					await RemoveReplyMarkup(botClient, update);
					await Command.Command1B13(botClient, update);
				}
			}
		}

		public static async Task Code12(ITelegramBotClient botClient, Update update)
		{
			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 12)
			{
				if (text == "Orqaga")
				{
					await RemoveReplyMarkup(botClient, update);
					crud.UpdateUser(chatId, 1);
					await Command.CommandA(botClient, update);
				}
				else if (update.Message.Contact != null)
				{

					await RemoveReplyMarkup(botClient, update);
					await Command.RequestAdmin(botClient, update, user);
				}

			}
		}

		public static async Task Code20(ITelegramBotClient botClient, Update update)
		{
			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 20 && text == "Ok")
			{
				await RemoveReplyMarkup(botClient, update);
				crud.UpdateUser(chatId, 1);
				await Command.CommandA(botClient, update);


			}
		}

		public static async Task Code14(ITelegramBotClient botClient, Update update)
		{

			string chatId = update.Message!.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 14)
			{
				string? text = update!.Message!.Text;
				if (text == "Adminga  habar yozish:")
				{
					ReplyKeyboardMarkup reply = new(
												new[]
												{
												new KeyboardButton[] {"Bosh sahifaga qaytish:"},
												})
					{ ResizeKeyboard = true };
					await RemoveReplyMarkup(botClient, update);
					Message sentMessage1 = await botClient.SendTextMessageAsync(
														  chatId: update.Message.Chat.Id,
														  text: "Endi Adminga Habar Yozishingiz Mumkun:",
														  replyMarkup: reply);
					crud.UpdateUser(chatId, 100);
				}
				else if (text == "Bosh sahifaga qaytish:")
				{
					await RemoveReplyMarkup(botClient, update);
					await Command.CommandA(botClient, update);
					crud.UpdateUser(chatId, 1);
				}
			}
		}

		public static async Task Code100(ITelegramBotClient botClient, Update update)
		{
			string chatId = update.Message!.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 100)
			{
				string? text = update!.Message!.Text;
				if ("Bosh sahifaga qaytish:" == text)
				{
					await RemoveReplyMarkup(botClient, update);
					await Command.CommandA(botClient, update);
					crud.UpdateUser(chatId, 1);
				}
				else
				{
					await botClient.SendTextMessageAsync(5359334768, $"id: {user!.UserId} dan habar keldi:");
					await botClient.SendTextMessageAsync(5359334768, text!);
					await botClient.SendTextMessageAsync(chatId, "Habaringiz Adminga yuborildi:");
				}
			}
		}

		public static async Task RemoveReplyMarkup(ITelegramBotClient botClient, Update update)
		{
			Message sentMessage = await botClient.SendTextMessageAsync(
				chatId: update.Message!.Chat.Id,
				text: "-",
				replyMarkup: new ReplyKeyboardRemove());
			await botClient.DeleteMessageAsync(update.Message!.Chat.Id, sentMessage.MessageId);
		}
	}
}
