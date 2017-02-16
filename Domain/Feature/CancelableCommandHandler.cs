using System;
using System.Threading.Tasks;
using Domain.Datastore;
using Enexure.MicroBus;
using System.Threading;

namespace Domain.Feature
{
	public class CancelableCommandHandler : ICancelableCommandHandler<CancelableCommand>
	{
		public async Task Handle(CancelableCommand command, CancellationToken cancellation)
		{
			await Task.Delay(TimeSpan.FromHours(1), cancellation);
		}
	}

	public class CancelableCommand : ICommand
	{
	}
}
