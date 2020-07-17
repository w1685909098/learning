using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public  class KeywordRepository :BaseRepository<Keyword>
    {
        public KeywordRepository(SqlDbContext context ):base(context)
        {

        }
        public IList<Keyword> GetRankedKeywords(int maxCount)
        {
            return Entities.OrderBy(e => e.Used).Take(maxCount).ToList();
        }

    }
}
