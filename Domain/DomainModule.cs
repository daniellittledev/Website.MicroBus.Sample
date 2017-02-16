using System;
using Autofac;
using Domain.CrossCutting;
using Domain.Datastore;
using Domain.Feature;
using Enexure.MicroBus.Autofac;

namespace Domain
{
	using Enexure.MicroBus;

	public class DomainModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Context>().InstancePerLifetimeScope();

			var busBuilder = new BusBuilder();

			busBuilder.RegisterGlobalHandler<TransactionHandler>();
			busBuilder.RegisterCommandHandler<FeatureCommand, FeatureCommandHandler>();
			busBuilder.RegisterCancelableCommandHandler<CancelableCommand, CancelableCommandHandler>();

			builder.RegisterMicroBus(busBuilder);
		}
	}
}
