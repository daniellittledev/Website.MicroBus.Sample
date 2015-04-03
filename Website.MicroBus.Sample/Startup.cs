using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Website.MicroBus.Sample.Startup))]

namespace Website.MicroBus.Sample
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseWebApi(GlobalConfiguration.Configuration);
		}
	}
}
