using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{
    public interface IDataRepository<T> where T:class
    {
        void ClearCache(string key);
        IQueryable<T> GetCache();
    }
}
