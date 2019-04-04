using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.App.Swagger
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class HiddenApiAttribute : Attribute
	{

	}
}
