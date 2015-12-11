using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication {
	public class StackExchangeSpullenboel {

		private Config config;

		public StackExchangeSpullenboel(Config config) {
			this.config = config;
		}

		public void Execute() {
			
			using (var redis = ConnectionMultiplexer.Connect(config.Host)) {

				var db = redis.GetDatabase();

				var key = Encoding.Default.GetBytes("foo");
				var value = Encoding.Default.GetBytes(DateTime.Now.ToString());

				Console.WriteLine("Getting value");
				var redisValue = db.StringGet(key);
				if (redisValue.IsNullOrEmpty) {
					Console.WriteLine("Setting value");
					db.StringSet(key, value);
				}

				Console.WriteLine(Encoding.Default.GetString(redisValue));				

			}

		}
	}
}
