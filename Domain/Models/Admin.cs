using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	[Table("admin")]
	public class Admin
	{
		[Column("admin_id")]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdminId { get; set; }
		[Column("phone_number")]
		public string PhoneNumber { get; set; } = "";
		[Column("is_admin")]
		public bool IsAdmin { get; set; }

		[Column("botuser_id")]
		public int BotUserId { get; set; }
		public BotUser? Botuser { get; set; }
	}
}
