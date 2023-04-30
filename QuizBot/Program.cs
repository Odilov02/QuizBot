using Infrastructure.Telegram;
using Newtonsoft.Json;

namespace QuizBot
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Dastur Ishga Tushdi!");
			await TelegramClient.startBot();
			Console.ReadKey();
			Console.WriteLine("Dastur Tugadi!");
		}
	}
	
}