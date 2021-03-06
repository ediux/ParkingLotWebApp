using System.Data.Entity;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{
	public partial interface IUnitOfWork : ICacheProvider
	{
		DbContext Context { get; set; }

        /// <summary>
        /// 提交資料庫變更耀球的同步方法。
        /// </summary>
		void Commit();
		bool LazyLoadingEnabled { get; set; }
		bool ProxyCreationEnabled { get; set; }
		string ConnectionString { get; set; }

        /// <summary>
        /// 提交資料庫變更耀球的非同步方法。
        /// </summary>
        /// <returns>非同步執行結果。</returns>
        Task CommitAsync();
	}
}