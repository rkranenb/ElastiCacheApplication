using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication.Commands {

	public class GetCommand : ICommand {

		private IRedisClient client;
		private ILogger logger;

		public GetCommand(IRedisClient client, ILogger logger) {
			this.client = client;
			this.logger = logger;
		}

		public string Key {
			get { return "get"; }
		}

		public void Execute(string[] args) {

			if (args.Length != 1) throw new InvalidSyntaxException();

			logger.Info("Getting a value from the database");

			var key = Encoding.Default.GetBytes(args[0]);

			try {
				var value = client.Get(key);
				logger.Info("Got {0}", Encoding.Default.GetString(value));
			} catch (ArgumentNullException) {
				logger.Warn("Not found.");
			}
		}
	}
}
