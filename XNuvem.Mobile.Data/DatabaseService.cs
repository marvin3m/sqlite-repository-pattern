using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseSettings _settings;
        SQLiteAsyncConnection _connection;
        

        public SQLiteAsyncConnection Connection { get => _connection; }

        public DatabaseService(IDatabaseSettings settings) {
            Check.IsNotNullOrEmpty(settings.FileName, nameof(settings.FileName));
            _settings = settings;
        }

        public async Task Init() {
            if (_connection is not null) 
                return;

            _connection = new SQLiteAsyncConnection(_settings.FullName(), _settings.Flags);

            foreach(var table in _settings.Tables) {
                await _connection.CreateTableAsync(table);
            }
        }
    }
}
