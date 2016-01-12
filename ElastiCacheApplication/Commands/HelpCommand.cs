using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication.Commands {

	public class HelpCommand : ICommand {

		private ILogger logger;

		public HelpCommand(ILogger logger) {
			this.logger = logger;
		}

		public string Key {
			get { return "help"; }

		}

		public void Execute(string[] args) {
			const string format = "{0, 30} : {1}\n";
			var message = new StringBuilder()
				.Append("\n")
				.AppendFormat(format, "del {key}", "Removes an item from the store.")
				.AppendFormat(format, "exists {key}", "Indicates if an item with the key exists.")
				.AppendFormat(format, "get {key}", "Gets an item from the store.")
				.AppendFormat(format, "host", "Shows the host name.")
				.AppendFormat(format, "put {key} {value}", "Puts an item in the store.")
				.AppendFormat(format, "put {key} {value} {timeout}", "Puts an item in the store with the\tgiven timeout in minutes.")

				.AppendFormat(format, "quit", "Closes the application.")
				.Replace("\t", string.Format("\n{0}",new string(' ', 33)))
				.Append("\n")
				.ToString();
			logger.Info(message);

		}
	}
}
