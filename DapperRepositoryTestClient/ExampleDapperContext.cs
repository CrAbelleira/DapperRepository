using DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperRepositoryTestClient
{
    class ExampleDapperContext : DapperContext
    {

        public DapperGenericRepository<String> tblString { get; }
        public DapperGenericRepository<String> tblString2 { get; }
        public DapperGenericRepository<String> tblString3 { get; }
        public DapperGenericRepository<String> tblString4 { get; }


        ExampleDapperContext(IDbConnection connection) : base(connection)
        {
            this.tblString = new DapperGenericRepository<string>(this);
            
        }
    }
}
