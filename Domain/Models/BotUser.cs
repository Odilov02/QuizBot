using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	[Table("bot_user")]
	public class BotUser
	{
		[Column("user_id")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		[Column("first_name")]
		public string FirstName { get; set; } = "";
		[Column("chat_id")]
		public string ChatId { get; set; } = "";
		[Column("user_name")]
		public string UserName { get; set; } = "";
		[Column("status_code")]
		public int StatusCode { get; set; }
        public Admin? Admin { get; set; }
    }
}
