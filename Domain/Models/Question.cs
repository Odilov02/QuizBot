using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	[Table("question")]
	public class Question
	{
		[Column("question_id")]
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int QuestionId { get; set;}
		[Column("category_id")]
		public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Column("question_text")]
		public string QuestionText { get; set; } = "";
		[Column("answer_a")]
		public string AnswerA { get; set; } = "";
		[Column("answer_b")]
		public string AnswerB { get; set; } = "";
		[Column("answer_c")]
		public string AnswerC { get; set; } = "";
		[Column("answer_d")]
		public string AnswerD { get; set; } = "";
		[Column("true_answer")]
		public string TrueAnswer { get; set; } = "";
    }
}
