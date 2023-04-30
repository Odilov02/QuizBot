using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public class Crud : IRepository
	{
		public async Task AddAdminAsync(Admin admin)
		{
			BotDbContext _db = new();
			await _db.admins.AddAsync(admin);
			_db.SaveChanges();
		}

		public async Task AddQuestionAsync(Question question)
		{
			BotDbContext _db = new();
			await _db.questions.AddAsync(question);
			_db.SaveChanges();
		}

		public async Task AddBotUserAsync(BotUser botUser)
		{
			BotDbContext _db = new();
			await _db.botUsers.AddAsync(botUser);
			_db.SaveChanges();
		}

		public void DeleteAdmin(Admin admin)
		{
			BotDbContext _db = new();
			_db.admins.Remove(admin);
		}

		public void UpdateAdmin(int id)
		{
			BotDbContext _db = new();
			Admin? admin= _db.admins.FirstOrDefault(x => x.AdminId == id);
			if (admin!=null)
			{
				admin.IsAdmin = true;
			_db.SaveChanges();
			}
		}

		public  BotUser? ReadBotUser(string chatid)
		{
			BotDbContext _db = new();
			return  _db.botUsers.FirstOrDefault(x => x.ChatId == chatid);
		}

		public void UpdateUser(string chatId,int statuscode)
		{
			BotDbContext _db = new();
			BotUser? botUser =_db.botUsers.FirstOrDefault(x => x.ChatId == chatId);
			botUser!.StatusCode = statuscode;
			_db.botUsers.Update(botUser);
			_db.SaveChanges();

		}
		public  Admin? ReadAdmin(int Id)
		{
			BotDbContext _db = new();
			return  _db.admins.FirstOrDefault(x => x.BotUserId==Id)??null;
		}
		public List<Admin> ReadAllAdmin()
		{
			BotDbContext _db = new();
			List<Admin> admins = _db.admins.Include(x => x.Botuser).ToList();
			return admins;
		}
	}
}
