using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public class DatabaseRegistration
    {
        private readonly IDatabaseSettings _databaseSettings;
        public IDatabaseSettings CurrentSettings => _databaseSettings;
        public DatabaseRegistration(Action<IDatabaseSettings> settingsDelegate) {
            _databaseSettings = GetDefaultSettings();
            if(settingsDelegate != null) {
                settingsDelegate(_databaseSettings);
            }
        }

        internal IDatabaseSettings GetDefaultSettings() {
            return new DatabaseSettings {
                FilePath = FileSystem.AppDataDirectory,
                FileName = null,
                Flags = // open the database in read/write mode
                        SQLite.SQLiteOpenFlags.ReadWrite |
                        // create the database if it doesn't exist
                        SQLite.SQLiteOpenFlags.Create |
                        // enable multi-threaded database access
                        SQLite.SQLiteOpenFlags.SharedCache
            };
        }
    }
}
