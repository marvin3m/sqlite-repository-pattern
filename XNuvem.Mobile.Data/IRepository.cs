using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public interface IRepository<T> where T : class, new()
    {
        IDatabaseService Service { get; }
        AsyncTableQuery<T> Table { get; }
        Task<int> InsertAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);
    }
}
