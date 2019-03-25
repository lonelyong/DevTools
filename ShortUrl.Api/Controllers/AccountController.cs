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
using ShortUrl.Api.Core.Account;
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

		private readonly AccountService _accountService;

		public AccountController(Repository<User> users, IOptions<AppSettings> appSettings, AccountService accountService)
		{
			_users = users.Value;
			_appSettings = appSettings.Value;
			_accountService = accountService;
		}

		/// <summary>
		/// 登录
		/// </summary>
		/// <remarks>
		/// /account/login 提交数据{username:'tom', password:'123456'}
		/// </remarks>
		/// <example>
		/// 暂无示例
		/// </example>
		/// <see cref="https://link.hicode.net"/>
		/// <exception cref="ShortUrl.Api.Exceptions.ApiException">
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("[action]")]
		[AllowAnonymous]
		public ActionResult<LoginOutputModel> Login([FromBody]LoginInputModel input)
		{
			var _user = _accountService.Login(input, out string token);
			var _output = NgNet.MappingUtils.MapPropertiesTo<LoginOutputModel>(_user);
			_output.AccessToken = token;
			_output.UserId = _user.Id;
			return Json(TResponse<LoginOutputModel>.Ok(_output));
		}

		/// <summary>
		/// 注册用户
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("[action]")]
		[AllowAnonymous]
		public ActionResult<SignupOutputModel> Signup([FromBody]SignupInputModel input)
		{
			var _user = _accountService.Signup(input);
			var _output = NgNet.MappingUtils.MapPropertiesTo<SignupOutputModel>(_user);
			_output.UserId = _user.Id;
			return Json(TResponse<SignupOutputModel>.Ok(_output));
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