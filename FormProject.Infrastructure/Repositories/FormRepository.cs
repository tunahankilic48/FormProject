using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;
using FormProject.Infrastructure.DbContext;

namespace FormProject.Infrastructure.Repositories
{
    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        public FormRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
