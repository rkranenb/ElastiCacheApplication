using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElastiCacheApplication {

	public interface IRedisClient {
		byte[] Get(byte[] key);
		void Put(byte[] key, byte[] value);
	}

	public class RedisClient : IRedisClient {

		private ConnectionMultiplexer connection;

		public RedisClient(IConfig config) {
			connection = ConnectionMultiplexer.Connect(config.Host);
		}

		public byte[] Get(byte[] key) {
			var db = connection.GetDatabase();
			return db.StringGet(key);
		}

		public void Put(byte[] key, byte[] value) {
			var db = connection.GetDatabase();
			db.StringSet(key, value);
		}
	}
}
