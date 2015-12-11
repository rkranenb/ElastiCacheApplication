using ElastiCacheApplication.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication {

	public interface ICommandProcessor {
		void Execute(string args);
		void Execute(string[] args);
	}

	public class CommandProcessor : ICommandProcessor {

		private readonly IEnumerable<ICommand> commands;


		public CommandProcessor(ICommand[] commands) {
			this.commands = commands;
		}

		public void Execute(string args) {
			if (string.IsNullOrEmpty(args)) return;
			Execute(args.Split(' '));
		}

		public void Execute(string[] args) {
			try {
				if (args == null || args.Length == 0) return;
				var command = commands.Single(c => c.Key.Equals(args[0], StringComparison.OrdinalIgnoreCase));
				command.Execute(args.Skip(1).ToArray());
			} catch (InvalidOperationException) {
				Console.WriteLine("Not a valid command.");
			}
		}

	}
}
