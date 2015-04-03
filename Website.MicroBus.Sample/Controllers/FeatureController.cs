using System;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Feature;
using Enexure.MicroBus;

namespace Website.MicroBus.Sample.Controllers
{
	public class FeatureController : ApiController
	{
		private readonly IBus bus;

		public FeatureController(IBus bus)
		{
			this.bus = bus;
		}

		public async Task Get()
		{
			//var result = await bus.Query(new FeatureQuery());
		}

		public async Task Post()
		{
			await bus.Send(new FeatureCommand());
		}
	}
}
