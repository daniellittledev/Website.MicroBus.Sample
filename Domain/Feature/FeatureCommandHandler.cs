using System;
using System.Threading.Tasks;
using Domain.Datastore;
using Enexure.MicroBus;

namespace Domain.Feature
{
	public class FeatureCommandHandler : ICommandHandler<FeatureCommand>
	{
		private readonly Context context;

		public FeatureCommandHandler(Context context)
		{
			this.context = context;
		}

		public Task Handle(FeatureCommand command)
		{
			return Task.FromResult(0);
		}
	}

	public class FeatureCommand : ICommand
	{
	}
}
