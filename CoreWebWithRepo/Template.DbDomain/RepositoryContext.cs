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
    }
}
