using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Entities.Repo
{
	/// <summary>
	/// md5记录表
	/// </summary>
	[Table("tbl_md5")]
	public class MD5 : EntityBase
	{
		/// <summary>
		/// 主键id
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		/// <summary>
		/// 字符串
		/// </summary>
		[MaxLength(128)]
		[Required]
		public string Txt { get; set; }

		/// <summary>
		/// md值
		/// </summary>
		[StringLength(32)]
		[Required]
		public string Md5 { get; set; }

		/// <summary>
		/// 记录创建时间
		/// </summary>
		[Required]
		public long CreationTime { get; set; }
	}
}
