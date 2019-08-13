#define MSSQL
#if (MSSQL)
using Microsoft.EntityFrameworkCore;
#endif

namespace Template.DbDomain
{
    public partial class RepositoryContext:DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default");
            }
        }
    }
}
