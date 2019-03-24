using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Entities
{
	[Table("tb_user")]
	public class User : EntityBase
	{
		[Key()]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(16)]
		[MinLength(6)]
		[Required]
		public string UserName { get; set; }

		[StringLength(128)]
		[Required]
		public string Password { get; set; }

		public string Email { get;set;}

		public string Telephone { get;set;}

		public string MobilePhone { get; set; }

		[Required]
		public int RoleType { get; set; }

		[Required]
		public long Creation_Time { get; set; }

	}
}
