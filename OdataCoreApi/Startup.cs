using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OdataCoreApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOData();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseMvc(routes =>
			{
				ConfigureODataRouting(routes, new ODataConventionModelBuilder(app.ApplicationServices));
			});
		}

		private static void ConfigureODataRouting(IRouteBuilder routes, ODataConventionModelBuilder odataBuilder)
		{
			// Enable full OData queries, you might want to consider which would be actually enabled in production scenaries
			routes.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

			routes.MapODataServiceRoute("ODataRoute", "odata", odataBuilder.GetEdmModel(), new DefaultODataPathHandler(), ODataRoutingConventions.CreateDefault());

			// Work-around for #1175
			routes.EnableDependencyInjection();
		}
	}
}
