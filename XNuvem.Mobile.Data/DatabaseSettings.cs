using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public interface IDatabaseSettings {
        string FilePath { get; set; }
        string FileName { get; set; }
        SQLiteOpenFlags Flags { get; set; }
        IList<Type> Tables { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string FilePath { get; set;}
        public string FileName { get; set; }
        public SQLiteOpenFlags Flags { get; set; }
        public IList<Type> Tables { get; set; }

        public DatabaseSettings() {
            Tables = new List<Type>();
        }


    }

    public static class DatabaseSettingsExtension 
    {
        public static string FullName(this IDatabaseSettings settings) {
            return Path.Combine(settings.FilePath, settings.FileName);
        }
    }
}
