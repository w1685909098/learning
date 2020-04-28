using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Repository
{
    public class BaseRepository<T>
    {
        public IList<T> GetPaged(IList<T> lists,int pageIndex,int pageSize)
        {
            return lists.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
