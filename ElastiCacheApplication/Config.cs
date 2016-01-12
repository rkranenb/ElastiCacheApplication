using System;
using System.Configuration;

namespace ElastiCacheApplication {

	public interface IConfig {
		string Host { get; }
	}

	public class Config : IConfig {
		public string Host {
			get {
				var args = Environment.GetCommandLineArgs();
				if (args.Length == 2) {
					return args[1];
				}
				return ConfigurationManager.AppSettings["host"];
			}
		}
	}

}
