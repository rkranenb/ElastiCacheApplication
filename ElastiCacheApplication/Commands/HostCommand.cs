
namespace ElastiCacheApplication.Commands {

	public class HostCommand :ICommand{

		private IConfig config;
		private ILogger logger;

		public HostCommand(IConfig config, ILogger logger) {
			this.config=config;
			this.logger = logger;
		}

		public string Key {
			get { return "host"; }
		}

		public void Execute(string[] args) {
			logger.Info(config.Host);
		}
	}
}
