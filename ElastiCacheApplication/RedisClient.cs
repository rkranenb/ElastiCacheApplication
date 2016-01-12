using StackExchange.Redis;
using System;

namespace ElastiCacheApplication {

	public interface IRedisClient {
		byte[] Get(byte[] key);
		void Put(byte[] key, byte[] value);
		void Put(byte[] key, byte[] value, double timeoutInMinutes);
		void Del(byte[] key);
		bool Exists(byte[] key);
	}

	public class RedisClient : IRedisClient {

		private ConnectionMultiplexer connection;

		public RedisClient(IConfig config, ILogger logger) {			
			connection = ConnectionMultiplexer.Connect(config.Host);
			logger.Info("Connected to {0}", config.Host);
		}

		public byte[] Get(byte[] key) {
			var db = connection.GetDatabase();
			return db.StringGet(key);
		}

		public void Put(byte[] key, byte[] value) {
			var db = connection.GetDatabase();
			db.StringSet(key, value);
		}

		public void Del(byte[] key) {
			var db = connection.GetDatabase();
			db.KeyDelete(key);
		}

		public void Put(byte[] key, byte[] value, double timeoutInMinutes) {
			var db = connection.GetDatabase();
			var ts = TimeSpan.FromMinutes(timeoutInMinutes);
			db.StringSet(key, value, ts);
		}

		public bool Exists(byte[] key) {
			var db = connection.GetDatabase();
			return db.KeyExists(key);
		}
	}
}
