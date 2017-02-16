using System;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Feature;
using Enexure.MicroBus;

namespace Website.MicroBus.Sample.Controllers
{
	public class FeatureController : ApiController
	{
		private readonly IMicroBus bus;

		public FeatureController(IMicroBus bus)
		{
			this.bus = bus;
		}

		public async Task Get()
		{
			//var result = await bus.Query(new FeatureQuery());
		}

		public async Task Post()
		{
			await bus.SendAsync(new FeatureCommand());
		}
	}
}
