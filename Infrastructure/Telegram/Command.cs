using Domain.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Infrastructure.Telegram
{
	public class Command
	{
		private static readonly Crud crud = new();
		public static async Task StartCommand(ITelegramBotClient botClient, Update update)
		{
			BotUser botUser = new()
			{
				FirstName = update!.Message!.Chat.FirstName??"",
				ChatId = update.Message!.Chat.Id.ToString(),
				UserName = update!.Message!.From!.ToString()??"",
				StatusCode = 1
			};
			await crud.AddBotUserAsync(botUser);
			await botClient.SendTextMessageAsync(update.Message.Chat.Id,
										   "Assalomu Alekum \n Xush kelibsiz!");
		}

		public static async Task CommandA(ITelegramBotClient botClient, Update update)
		{
			ReplyKeyboardMarkup replyKeyboardMarkup = new(
				                                      new[]
				                                      {
													  new KeyboardButton[] { "Test Ishlash" },
													  new KeyboardButton[] { "Test Qo'shish" },
													  new KeyboardButton[] { "Admin Bilan Bog'lanish" },
				                                      })
			                                          {
			                                       	  ResizeKeyboard = true
		                                           	  };

			await botClient.SendTextMessageAsync(chatId: update.Message!.Chat.Id,
										   text: "Qanday Amal Bajarmoqchisiz!",
										   replyMarkup: replyKeyboardMarkup
										   );
		}

		public static async Task Command1B11(ITelegramBotClient botClient, Update update)
		{
			await Console.Out.WriteLineAsync();
		}

		public static async Task Command1B12(ITelegramBotClient botClient, Update update)
		{
			await botClient.SendTextMessageAsync(chatId: update.Message!.Chat.Id,
				"Test Qo'shish uchun Admin bolishingiz kerak");
		      	ReplyKeyboardMarkup markup = new(
				                             new[]
				{
					new KeyboardButton[]  {  KeyboardButton.WithRequestContact("Contact yuborish") },
					new KeyboardButton[] { "Orqaga" }
				})
			                                 {
			                               	ResizeKeyboard = true
		                                  	};
			markup.ResizeKeyboard = true;
			await botClient.SendTextMessageAsync(
					chatId: update.Message.Chat.Id,
					text: "Admin bo'lish uchun contact yuboring",
					replyMarkup: markup
			);
			crud.UpdateUser(update.Message.Chat.Id.ToString(), 12);
		}

		public static async Task Command1B13(ITelegramBotClient botClient, Update update)
		{
			ReplyKeyboardMarkup reply = new(
										new[]
				                        {
					                    new KeyboardButton[] {"Adminga  habar yozish:"},
					                    new KeyboardButton[] {"Bosh sahifaga qaytish:"},
				                        })
			                            { ResizeKeyboard = true };
			await botClient.SendTextMessageAsync(chatId: update.Message!.Chat.Id,
										 text: "Qanday Amal Bajarmoqchisiz!",
										 replyMarkup: reply);
			crud.UpdateUser(update.Message!.Chat.Id.ToString(),14);
		}

		public static async Task RequestAdmin(ITelegramBotClient botClient, Update update, BotUser user)
		{
			Admin? admin1 = crud.ReadAdmin(user.UserId);
			if (admin1 == null)
			{
				Admin admin = new()
				{
					PhoneNumber = update.Message!.Contact!.PhoneNumber,
					BotUserId = user.UserId,
					IsAdmin = false
				};
				await crud.AddAdminAsync(admin);
			}

			await botClient.SendTextMessageAsync(5359334768,
												  $"userId:  {user.UserId}  name:  {user.FirstName}\nAdmin bo'lish uchun So'rov yubordi");
			ReplyKeyboardMarkup replyKeyboardMarkup = new(
													  new[]
													  {
													  new KeyboardButton[] { "Ok" },
													  })
			                                          {
			                                       	  ResizeKeyboard = true
			                                          };
			await botClient.SendTextMessageAsync(chatId: update.Message!.Chat.Id,
				text: "Adminga so'rov yuborildi",
				replyMarkup: replyKeyboardMarkup);
			crud.UpdateUser(user.ChatId, 20);
		}

	}
}
