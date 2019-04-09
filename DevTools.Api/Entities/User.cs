using DevTools.Api.Common.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Entities
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Table("tb_user")]
	public class User : EntityBase
	{
		/// <summary>
		/// 主键
		/// </summary>
		[Key()]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		[MaxLength(16)]
		[MinLength(6)]
		[Required]
		[RegularExpression(RegexConsts.USERNAME)]
		public string UserName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[StringLength(128)]
		[Required]
		[RegularExpression(RegexConsts.PASSWORD)]
		public string Password { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		[MaxLength(32)]
		[MinLength(6)]
		[Required]
		[EmailAddress]
		public string Email { get;set;}

		/// <summary>
		/// 固定电话号码
		/// </summary>
		[MaxLength(11)]
		[MinLength(7)]
		[Phone]
		public string Telephone { get;set;}

		/// <summary>
		/// 移动电话号码
		/// </summary>
		[MaxLength(14)]
		[MinLength(11)]
		[RegularExpression(RegexConsts.MOBILEPHONE)]
		public string MobilePhone { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[MaxLength(8)]
		[MinLength(1)]
		public string NickName { get; set; }

		/// <summary>
		/// 角色类型
		/// </summary>
		[Required]
		public UserRoleType RoleType { get; set; } = UserRoleType.Regular;

		/// <summary>
		/// 创建时间
		/// </summary>
		[Required]
		public long CreationTime { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
		[Required]
		public UserStatusCode StatusCode { get; set; } = UserStatusCode.Normal;

		/// <summary>
		/// 是否删除
		/// </summary>
		[Required]
		public bool IsDeleted { get; set; } = false;

	}
}
