using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;
using FormProject.Infrastructure.DbContext;

namespace FormProject.Infrastructure.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
