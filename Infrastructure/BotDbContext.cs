using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class BotDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=::1;Port=5432;Database=QuizBot;User Id=postgres;Password=020819;");
		}
		public BotDbContext() : base()
		{
		}
		public DbSet<Admin> admins { get; set; }
		public DbSet<BotUser> botUsers { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<Question> questions { get; set; }
	}
}
