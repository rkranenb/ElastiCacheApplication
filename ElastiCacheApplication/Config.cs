using System.Configuration;

namespace ElastiCacheApplication {

	public interface IConfig {
		string Host { get; }
	}

	public class Config : IConfig {
		public string Host {
			get { return ConfigurationManager.AppSettings["host"]; }
		}
	}
}
