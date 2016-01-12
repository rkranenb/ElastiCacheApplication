using System;
using System.Text;

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

			if (args.Length < 2 || args.Length > 3) throw new InvalidSyntaxException();

			var key = Encoding.Default.GetBytes(args[0]);
			var value = Encoding.Default.GetBytes(args[1]);

			double timeoutInMinutes = 0;
			if (args.Length == 3) {
				if (double.TryParse(args[2], out timeoutInMinutes)) {
					client.Put(key, value, timeoutInMinutes);
					logger.Info("Put value into database with expiry of {0} minutes.\nItem will be removed at {1}", timeoutInMinutes, DateTime.Now.AddMinutes(timeoutInMinutes));
					return;
				} 
				throw new ArgumentException("Invalid value for 'timeoutInMinutes'.");
			} else {
				client.Put(key, value);
				logger.Info("Put value into database");
			}

		}
	}
}
