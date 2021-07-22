using Acme.ProjectDemo.Entities.CustomerDetail;
using Acme.ProjectDemo.Permissions;
using Acme.ProjectDemo.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Acme.ProjectDemo.Entities.CustomerDetails
{
    public class CustomerDetailAppService :
            CrudAppService<
            CustomerDetail, //The  entity
            CustomerDetailDto, //Used to show 
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCustomerDetailDto>, //Used to create/update a book
        ICustomerDetailAppService //implement the IBookAppService
    {
        private readonly IAppUserRepository _appUserRepository;

        public CustomerDetailAppService(
            IRepository<CustomerDetail, Guid> repository,
             IAppUserRepository appUserRepository
            )
           : base(repository)
        {
            _appUserRepository = appUserRepository;

            //define permissions
            GetPolicyName = ProjectDemoPermissions.CustomerDetail.Default;
            GetListPolicyName = ProjectDemoPermissions.CustomerDetail.Default;
            CreatePolicyName = ProjectDemoPermissions.CustomerDetail.Create;
            UpdatePolicyName = ProjectDemoPermissions.CustomerDetail.Edit;
            DeletePolicyName = ProjectDemoPermissions.CustomerDetail.Delete;
        }

        public async Task<CustomerDetailDto> GetUserDetails(string userEmail)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from CustomerDetail in queryable
                        join userData in _appUserRepository
                        on CustomerDetail.UserEmail equals userData.Email
                        where CustomerDetail.UserEmail == userEmail
                        select new { CustomerDetail, userData };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if (queryResult == null)
            {
                return null;
            }
            else
            {
                var dataDto = ObjectMapper.Map<CustomerDetail, CustomerDetailDto>(queryResult.CustomerDetail);
                dataDto.UserEmail = queryResult.userData.Email;
                return dataDto;
            }
        }
    }
}
