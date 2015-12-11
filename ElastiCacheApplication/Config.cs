using System.Configuration;

namespace ElastiCacheApplication {
	public class Config {
		public string Host {
			get { return ConfigurationManager.AppSettings["host"]; }
		}
	}
}
