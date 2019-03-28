using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShortUrl.Api.App;
using ShortUrl.Api.Common.Utils;
using ShortUrl.Api.Data;
using ShortUrl.Api.Entities;
using ShortUrl.Api.Exceptions;
using ShortUrl.Api.Models.Configuration;
using ShortUrl.Api.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgNet.Date;

namespace ShortUrl.Api.Core.Account
{
	/// <summary>
	/// 用户账户服务
	/// </summary>
	[Service(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
	public class AccountService
	{
		private readonly MssqlDbContext _db;

		private readonly AppSettings _appSettings;

		public AccountService(MssqlDbContext dbContext, IOptions<AppSettings> appSettings)
		{
			_db = dbContext;
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// 注册新用户
		/// </summary>
		/// <param name="input">用户信息</param>
		/// <returns></returns>
		public User Signup(SignupInputModel input)
		{
			var _user = NgNet.MappingUtils.MapPropertiesTo<User>(input);
			_user.Password = NgNet.Security.HashHelper.StringSHA512(_user.Password);
			var _oldUser = _db.Users.FirstOrDefault(t=>t.UserName==_user.UserName && !t.IsDeleted);
			if(_oldUser != null)
			{
				throw new ApiException("此用户名已存在");
			}
			_user.CreationTime = DateTime.Now.ToUnixTimestamp();
			_db.Users.Add(_user);
			_db.SaveChangesAsync();
			return _user;
		}

		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="input">用户信息</param>
		/// <param name="token">签发的token</param>
		/// <returns></returns>
		public User Login(LoginInputModel input, out string token)
		{
			var _user = _db.Users.Single(t => t.UserName == input.UserName && !t.IsDeleted);
			if (_user == null)
			{
				throw new ApiException("此用户不存在");
			}
			if (NgNet.Security.HashHelper.StringSHA512(input.Password) == _user.Password)
			{
				token = SecurityUtils.IssueToken(_appSettings, _user);
				return _user;
			}
			else
			{
				throw new ApiException("用户名或密码错误");
			}
		}
	}
}
