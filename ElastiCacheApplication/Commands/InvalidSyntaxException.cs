using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElastiCacheApplication.Commands {
	public class InvalidSyntaxException : Exception {

		const string message = "The syntax is invalid for this command.";

		public InvalidSyntaxException() : base(message) { }

		public InvalidSyntaxException(string message) : base(message) { }

	}
}
