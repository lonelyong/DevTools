using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NgNet.Net;
using DevTools.Api.App;
using DevTools.Api.Common.Utils;
using DevTools.Api.Core.Account;
using DevTools.Api.Data;
using DevTools.Api.Entities;
using DevTools.Api.Models;
using DevTools.Api.Models.Configuration;
using DevTools.Api.Models.ViewModels.Account;
using static System.Net.WebRequestMethods;

namespace DevTools.Api.Controllers
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
		/// <see cref="Http://link.hicode.net"/>
		/// <exception cref="DevTools.Api.Exceptions.ApiException">
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