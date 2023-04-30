using Domain.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Infrastructure.Telegram
{
	public class UpdateHundler : IUpdateHandler
	{
		public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
            //throw new NotImplementedException();
            await Console.Out.WriteLineAsync();
        }

		public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
            Parallel.Invoke(() => StatusCode.Code0(botClient, update));
			Parallel.Invoke(async () =>await StatusCode.Code1(botClient, update));
			Parallel.Invoke(async () =>await StatusCode.Code12(botClient, update));
			Parallel.Invoke(async () =>await StatusCode.Code14(botClient, update));
			Parallel.Invoke(async () =>await StatusCode.Code20(botClient, update));
			Parallel.Invoke(async () => await StatusCode.Code100(botClient, update));
			Parallel.Invoke(async () => await SuperAdminPanel.Code1000(botClient, update));
			Parallel.Invoke(async () => await SuperAdminPanel.Code1001(botClient, update));
			Parallel.Invoke(async () => await SuperAdminPanel.CodeText(botClient, update));
			Parallel.Invoke(async () => await SuperAdminPanel.Code1002(botClient, update));
            await Console.Out.WriteLineAsync();
		}


	}
}

