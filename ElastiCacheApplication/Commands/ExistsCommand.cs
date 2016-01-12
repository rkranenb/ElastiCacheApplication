using System;
using System.Text;

namespace ElastiCacheApplication.Commands {

	public class ExistsCommand : ICommand {

		private IRedisClient client;
		private ILogger logger;

		public ExistsCommand(IRedisClient client, ILogger logger) {
			this.client = client;
			this.logger = logger;
		}

		public string Key {
			get { return "exists"; }
		}

		public void Execute(string[] args) {

			if (args.Length != 1) throw new InvalidSyntaxException();

			var key = Encoding.Default.GetBytes(args[0]);

			if (client.Exists(key)) {
				logger.Info("Found.");
			} else {
				logger.Info("Not found.");
			}

		}
	}
}
