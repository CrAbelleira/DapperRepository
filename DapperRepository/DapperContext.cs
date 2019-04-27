using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DapperRepository
{
    public abstract class DapperContext
    {
        internal IDbConnection connection;
        internal IDbTransaction transaction { get; set; }


        public void SaveChanges()
        {
            transaction.Commit();
        }

        public DapperContext(IDbConnection connection)
        {
            this.connection = connection;
        }
        
    }
}
