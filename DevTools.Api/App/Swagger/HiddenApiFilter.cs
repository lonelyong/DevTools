using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DevTools.Api.App.Swagger
{
	public class HiddenApiFilter : IDocumentFilter
	{
		public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
		{
			foreach (var api in context.ApiDescriptions)
			{
				if(api.TryGetMethodInfo(out MethodInfo mi))
				{
					if(mi.GetCustomAttribute<HiddenApiAttribute>() != null 
						|| mi.DeclaringType.GetCustomAttribute<HiddenApiAttribute>() != null)
					{
						swaggerDoc.Paths.Remove('/' + api.RelativePath.TrimEnd('/'));
					}
				}
			}
		}
	}
}
