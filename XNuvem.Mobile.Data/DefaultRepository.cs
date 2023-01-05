using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public class DefaultRepository<T> : IRepository<T>
        where T : class, new()
    {
        readonly IDatabaseService _service;

        public DefaultRepository(IDatabaseService service) {
            _service = service;
            _service.Init().Wait();
        }

        public IDatabaseService Service => _service;

        public AsyncTableQuery<T> Table {
            get {
                return _service.Connection.Table<T>();
            }
        }

        public async Task<int> DeleteAsync(T item) {
            return await _service.Connection.DeleteAsync(item);
        }

        public async Task<int> InsertAsync(T item) {
            return await _service.Connection.InsertAsync(item);
        }

        public async Task<int> UpdateAsync(T item) {
            return await _service.Connection.UpdateAsync(item);
        }
    }
}
