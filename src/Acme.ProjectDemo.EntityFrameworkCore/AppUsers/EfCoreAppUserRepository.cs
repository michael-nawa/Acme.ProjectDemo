using Acme.ProjectDemo.EntityFrameworkCore;
using Acme.ProjectDemo.Users;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.ProjectDemo.AppUsers
{
    public class EfCoreAppUserRepository :
        EfCoreRepository<ProjectDemoDbContext, AppUser, Guid>,
            IAppUserRepository
    {

        public EfCoreAppUserRepository(
           IDbContextProvider<ProjectDemoDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }


    }
}
