using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.ProjectDemo.Entities.CustomerDetail
{
    public interface ICustomerDetailAppService :
        ICrudAppService< //Defines CRUD methods
            CustomerDetailDto,
            Guid, //Primary key  
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCustomerDetailDto> //Used to create/update 
    {
        Task<CustomerDetailDto> GetUserDetails(String userEmail);
    }
}
