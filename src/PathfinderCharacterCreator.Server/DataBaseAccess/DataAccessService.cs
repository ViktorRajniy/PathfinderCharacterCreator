using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class DataAccessService
    {
        private ApplicationContext _db;

        public DataAccessService(ApplicationContext db)
        {
            _db = db;
        }
    }
}
