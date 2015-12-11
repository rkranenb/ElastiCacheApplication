
namespace ElastiCacheApplication.Commands {
	public interface ICommand {
		string Key { get;  }
		void Execute(string[] args);
	}
}
