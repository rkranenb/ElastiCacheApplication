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
			logger.Info("I'm not much of a help thingy. Sorry.");
		}
	}
}
