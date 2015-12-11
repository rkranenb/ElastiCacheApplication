using System;
using System.Reflection;

namespace ElastiCacheApplication {

	class Program {

		static void Main(string[] args) {
			ShowApplicationInfo();
			TryExecute(() => {
				var console = IoC.Initialize().GetInstance<IRedisConsole>();
				console.Execute();
			});
		}

		private static void ShowApplicationInfo() {
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			Console.WriteLine("ElastiCache Application version {0}.{1}\n", version.Major, version.Minor);
		}

		private static void TryExecute(Action action) {
			try {
				action();
			} catch (Exception e) {
				while (e != null) {
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(e.Message);
					Console.ForegroundColor = color;
					e = e.InnerException;
				}
			}
		}

	}
}
