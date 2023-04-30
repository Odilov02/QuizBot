using Domain.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Infrastructure.Telegram
{
	public class SuperAdminPanel
	{
		private static string SuperChatId = "5359334768";
		private static readonly Crud crud = new();
		public static async Task CodeText(ITelegramBotClient botClient, Update update)
		{

			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			if (SuperChatId == chatId && text == "020819diyorbek")
			{
				await Commandtext(botClient, update, chatId);
			}
		}

		private static async Task Commandtext(ITelegramBotClient botClient, Update update, string chatId)
		{
			await StatusCode.RemoveReplyMarkup(botClient, update);
			crud.UpdateUser(chatId, 1000);
			ReplyKeyboardMarkup reply = new(new[]
			{
		            new KeyboardButton[] {"Admin Bo'lish Uchun So'rov Yuborganlar:"},
					new KeyboardButton[] {"adminlar royhatini korish:"},
					new KeyboardButton[] {"Murojatlarga Javob yozish:"},
					new KeyboardButton[] {"Super Admindan chiqish:"},
			})
			{ ResizeKeyboard = true };
			await botClient.SendTextMessageAsync(chatId: chatId,
										   text: "Bosh Admin sahifasi:",
										   replyMarkup: reply);

		}

		public static async Task Code1000(ITelegramBotClient botClient, Update update)
		{
			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 1000)
			{
				await StatusCode.RemoveReplyMarkup(botClient, update);
				if (text == "Admin Bo'lish Uchun So'rov Yuborganlar:")
				{
					await Command1000(botClient);
					string sms = "";
					List<Admin> admins = crud.ReadAllAdmin().Where(x => x.IsAdmin == false).ToList();
					foreach (Admin admin in admins)
					{
						sms += $"Id: {admin.AdminId}  name {admin!.Botuser!.FirstName}\n";
					}
					await botClient.SendTextMessageAsync(SuperChatId, sms);

					crud.UpdateUser(SuperChatId, 1001);
				}
				else if (text == "Murojatlarga Javob yozish:")
				{

				}
				else if (text == "Super Admindan chiqish:")
				{

				}
			}
		}

		private static async Task Command1000(ITelegramBotClient botClient)
		{
			ReplyKeyboardMarkup reply = new(
										new[]
										{
										new KeyboardButton[]{"Admin uchun nomzod Tanlash:"},
										new KeyboardButton[]{"Orqaga"},
										})
			                            { ResizeKeyboard = true };
			await botClient.SendTextMessageAsync(
											  chatId: SuperChatId,
											  text: "Qanday amal bajarmoqchisiz",
											  replyMarkup: reply
											  );
		}

		public static async Task Code1001(ITelegramBotClient botClient, Update update)
		{
			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode == 1001)
			{
				await StatusCode.RemoveReplyMarkup(botClient, update);
				if (text == "Orqaga")
				{
					await Commandtext(botClient, update, chatId);
				}
				else if(text=="Admin uchun nomzod Tanlash:")
				{
					ReplyKeyboardMarkup reply = new(
						new KeyboardButton[] { "Orqaga" })
					                            { ResizeKeyboard = true };
					await botClient.SendTextMessageAsync(chatId: SuperChatId,
						                                 text:"Id Kiriting:",
														 replyMarkup:reply
												   );
				}
				crud.UpdateUser(SuperChatId, 1002);
			}
		}
		public static async Task Code1002(ITelegramBotClient botClient,Update update)
		{
			string? text = update!.Message!.Text;
			string chatId = update.Message.Chat.Id.ToString();
			BotUser? user = crud.ReadBotUser(chatId);
			if (user!.StatusCode==1002)
			{
				if (text=="Orqaga")
				{
					crud.UpdateUser(SuperChatId, 1001);
					await Command1000(botClient);
				}
				try
				{
					int id = int.Parse(text!);
					crud.UpdateAdmin(id);
				    Admin? admin= crud.ReadAdmin(id);
					await botClient.SendTextMessageAsync(SuperChatId, "Muvaffaqiyatli Qo'shildi");
					await botClient.SendTextMessageAsync(admin!.Botuser!.ChatId, "Siz Adminsiz Endi Test Qo'shishingiz Mumkun");
					crud.UpdateUser(SuperChatId, 1001);
				}
				catch (Exception)
				{
					await botClient.SendTextMessageAsync(SuperChatId, "Bunday Id ga ega foydalanuvchi yo'q");
				}
			}
		}
	}
}
