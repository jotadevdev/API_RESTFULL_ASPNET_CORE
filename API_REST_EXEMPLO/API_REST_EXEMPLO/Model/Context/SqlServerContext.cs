using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace API_REST_EXEMPLO.Model.Context
{
    public class SqlServerContext : DbContext
    {

        public SqlServerContext()
        {

        }


        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

    }
}
