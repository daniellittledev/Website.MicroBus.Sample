using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Domain;

namespace Website.MicroBus.Sample
{
	public class DependencyConfig
	{
		public static void RegisterDependencies(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// OPTIONAL: Register the Autofac filter provider.
			builder.RegisterWebApiFilterProvider(config);

			builder.RegisterModule(new DomainModule());

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}