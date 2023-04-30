using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Infrastructure.Telegram
{
	public class TelegramClient
	{
		public static TelegramBotClient bot = new("6193351420:AAF8PfmdF0mjlq9L287bZeKemVvyt8SP8eo");
		public static async Task startBot()
		{
		await bot.ReceiveAsync<UpdateHundler>();
		}
	}
}
