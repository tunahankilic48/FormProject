using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;
using FormProject.Infrastructure.DbContext;

namespace FormProject.Infrastructure.Repositories
{
    public class FieldRepository : BaseRepository<Field>, IFieldRepository
    {
        public FieldRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
