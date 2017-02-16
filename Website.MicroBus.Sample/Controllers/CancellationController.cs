using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Feature;
using Enexure.MicroBus;
using System.Web.Mvc;

namespace Website.MicroBus.Sample.Controllers
{
	public class CancellationController : ApiController
	{
		private readonly ICancelableMicroBus bus;

		public CancellationController(ICancelableMicroBus bus)
		{
			this.bus = bus;
		}

		public async Task<string> Get()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var token = cancellationTokenSource.Token;
			cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(1.0));

			await bus.SendAsync(new CancelableCommand(), token);

			return "If this took 1 second, then it works";
		}
	}
}
