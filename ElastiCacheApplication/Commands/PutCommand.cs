using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication.Commands {

	public class PutCommand : ICommand {

		private IRedisClient client;
		private ILogger logger;

		public PutCommand(IRedisClient client, ILogger logger) {
			this.client = client;
			this.logger = logger;
		}

		public string Key {
			get { return "put"; }
		}

		public void Execute(string[] args) {

			if (args.Length != 2) throw new InvalidSyntaxException();

			logger.Info("Put value into database");

			var key = Encoding.Default.GetBytes(args[0]);
			var value = Encoding.Default.GetBytes(args[1]);

			client.Put(key, value);

		}
	}
}
