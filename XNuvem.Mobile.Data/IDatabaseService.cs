using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNuvem.Mobile.Data
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection Connection { get; }
        Task Init();
    }
}
