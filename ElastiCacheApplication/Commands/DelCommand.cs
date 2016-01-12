using System;
using System.Text;

namespace ElastiCacheApplication.Commands {

	public class DelCommand : ICommand {

		private IRedisClient client;
		private ILogger logger;

		public DelCommand(IRedisClient client, ILogger logger) {
			this.client = client;
			this.logger = logger;
		}

		public string Key {
			get { return "del"; }
		}

		public void Execute(string[] args) {

			if (args.Length != 1) throw new InvalidSyntaxException();

			var key = Encoding.Default.GetBytes(args[0]);

			client.Del(key);
			logger.Info("Removed item with key '{0}' from database", args[0]);

		}
	}
}
