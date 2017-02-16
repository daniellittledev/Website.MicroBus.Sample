using System.Threading.Tasks;
using Domain.Datastore;
using Enexure.MicroBus;

namespace Domain.CrossCutting
{
	public class TransactionHandler : IDelegatingHandler
	{
		private readonly Context context;

		public TransactionHandler(Context context)
		{
			this.context = context;
		}

		public async Task<object> Handle(INextHandler next, object message)
		{
			var result = await next.Handle(message);

			context.SaveChanges();

			return result;
		}
	}

}
