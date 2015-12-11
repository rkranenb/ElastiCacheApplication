using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication {

	public interface IRedisConsole {
		void Execute();
	}

	public class RedisConsole : IRedisConsole {

		private IConfig config;
		private ICommandProcessor commandProcessor;

		public RedisConsole(IConfig config, ICommandProcessor commandProcessor) {
			this.config = config;
			this.commandProcessor = commandProcessor;
		}

		public void Execute() {

			var prompt = config.Host.Split('.').First();

			var s = string.Empty;

			while (IsNotQuitCommand(s)) {
				Console.Write("{0} > ", prompt);
				s = Console.ReadLine();
				if (IsNotQuitCommand(s)) {
					commandProcessor.Execute(s);
				}
			}

		}

		private bool IsNotQuitCommand(string s) {
			return !s.Equals("quit", StringComparison.OrdinalIgnoreCase);
		}
	}
}
