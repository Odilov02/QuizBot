using Domain.Models;

namespace Infrastructure
{
	public interface IRepository
	{
		public Task AddAdminAsync(Admin admin);

		public Task AddQuestionAsync(Question question);

		public Task AddBotUserAsync(BotUser botUser);

		public void DeleteAdmin(Admin admin);

		public void UpdateAdmin(int id);

		public BotUser? ReadBotUser(string chatid);

		public List<Admin> ReadAllAdmin();
		public void UpdateUser(string chatId, int statuscode);

	}
}
