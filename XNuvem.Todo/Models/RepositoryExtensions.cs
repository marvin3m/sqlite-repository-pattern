using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XNuvem.Mobile.Data;

namespace XNuvem.Todo.Models
{
    internal static class RepositoryExtensions
    {
        public static async Task<int> SaveAsync(this IRepository<TodoItem> todoRepository, TodoItem item) {
            if(item.ID != 0) {
                return await todoRepository.UpdateAsync(item);
            } else {
                return await todoRepository.InsertAsync(item);
            }
        }
    }
}
