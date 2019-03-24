using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NgNet.Net;
using ShortUrl.Api.App;
using ShortUrl.Api.Common.Utils;
using ShortUrl.Api.Data;
using ShortUrl.Api.Entities;
using ShortUrl.Api.Models;
using ShortUrl.Api.Models.Configuration;
using ShortUrl.Api.Models.ViewModels.Account;

namespace ShortUrl.Api.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class AccountController : ControllerBase
    {
		private readonly DbSet<User> _users;

		private readonly AppSettings _appSettings;

		public AccountController(Repository<User> users, IOptions<AppSettings> appSettings)
		{
			_users = users.Value;
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("[action]")]
		[AllowAnonymous]
		public ActionResult<LoginOutputModel> Login([FromBody]LoginInputModel input)
		{
			var user = _users.Single(t=>t.UserName == input.UserName);
			if(user == null)
			{
				return Json(TResponse<string>.Error("此用户不存在"));
			}
			if(NgNet.Security.HashHelper.StringSHA512(input.Password) == user.Password)
			{
				var token = SecurityUtils.IssueToken(_appSettings, user);
				return Json(TResponse<LoginOutputModel>.Ok(new LoginOutputModel()
				{
					AccessToken = token,
					UserName = user.UserName
				}));
			}
			else
			{
				return Json(TResponse<string>.Error("用户名或密码错误"));
			}
		}

		/// <summary>
		/// 注册用户
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("[action]")]
		[AllowAnonymous]
		public ActionResult<SignInOutputModel> SignIn([FromBody]SignInInputModel input)
		{
			return Json(TResponse<SignInOutputModel>.Ok(new SignInOutputModel() { }));
		}

		/// <summary>
		/// 获取个人信息
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("[action]")]
		public ActionResult<IndexOutputModel> Index()
		{
			return Json(TResponse<IndexOutputModel>.Ok(new IndexOutputModel()));
		}
	}
}