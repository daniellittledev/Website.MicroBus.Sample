using System;
using Autofac;
using Domain.CrossCutting;
using Domain.Datastore;
using Domain.Feature;
using Enexure.MicroBus.Autofac;

namespace Domain
{
	public class DomainModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Context>().InstancePerLifetimeScope();

			builder.RegisterMicroBus(x => {

				var pipeline = x.CreatePipeline()
					.AddHandler<TransactionHandler>();

				x.RegisterHandler<FeatureCommandHandler>(pipeline);

			});
		}
	}
}
