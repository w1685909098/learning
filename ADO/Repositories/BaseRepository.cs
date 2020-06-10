using CSharp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Repositories
{
    public  class BaseRepository<T> where T : BaseEntity
    {
        public BaseRepository()
        {

        }
        private SqlContext _sqlContext;
        public BaseRepository(SqlContext context)
        {
            SqlContext = context;
        }
        public SqlContext SqlContext 
        { get
            {
                return _sqlContext;
            }
            set
            {
                if (_sqlContext==null)
                {
                    _sqlContext = new SqlContext();
                }
                _sqlContext = value;
            }
        }
        public  T Get()
        {
            return SqlContext.Find<T>();
        }
    }
}
