using System.Threading.Tasks;
using Domain.Datastore;
using Enexure.MicroBus;
using Enexure.MicroBus.MessageContracts;

namespace Domain.CrossCutting
{
	public class TransactionHandler : IPipelineHandler
	{
		private readonly IPipelineHandler innerHandler;
		private readonly Context context;

		public TransactionHandler(IPipelineHandler innerHandler, Context context)
		{
			this.innerHandler = innerHandler;
			this.context = context;
		}

		public async Task<object> Handle(IMessage message)
		{
			var result = await innerHandler.Handle(message);

			context.SaveChanges();

			return result;
		}
	}

}
