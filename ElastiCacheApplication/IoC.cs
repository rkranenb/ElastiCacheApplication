using ElastiCacheApplication.Commands;
using StructureMap;
using StructureMap.Graph;

namespace ElastiCacheApplication {

	static class IoC {

		public static IContainer Initialize() {
			return new Container(_ => {

				_.Scan(scan => {
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
					scan.AddAllTypesOf<ICommand>();
				});

				_.For<ILogger>()
					.AlwaysUnique()
					.Use(new Logger(NLog.LogManager.GetLogger("Default")));

				_.For<IRedisClient>()
					.Singleton()
					.Use<RedisClient>();

			});
		}

	}
}
