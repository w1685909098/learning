using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public  class BaseRepository<T> :BaseEntity
    {
        public SqlContext SqlContext { get; set; }
        //public T GetTByName(string name)
        //{
        //    return SqlContext.Entities.Where(e=>e.na)
        //}
    }
}
