using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication {

	public interface ILogger {
		void Error(string message, params object[] args);
		void Info(string message, params object[] args);
		void Warn(string message, params object[] args);
	}

	public class Logger : ILogger {

		private NLog.Logger logger;

		public Logger(NLog.Logger logger) {
			this.logger = logger;
		}

		public void Error(string message, params object[] args) {
			logger.Error(message, args);
		}

		public void Info(string message, params object[] args) {
			logger.Info(message, args);
		}

		public void Warn(string message, params object[] args) {
			logger.Warn(message, args);
		}
	}
}
