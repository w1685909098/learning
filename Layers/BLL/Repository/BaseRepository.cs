using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public  class BaseRepository<T> where T:BaseEntity
    {

        protected DbContext context;
        protected DbSet<T> Entities
        {
            get
            {
                return context.Set<T>();
            }
        }
        //public BaseRepository()
        //{

        //}
        public BaseRepository(DbContext context )
        {
            this.context = context;
        }
        //public T GetTByName(string name)
        //{
        //    return SqlContext.Entities.Where(e=>e.na)
        //}
        public T Find(int id)
        {
            return Entities.Find(id);
        }
    }
}
