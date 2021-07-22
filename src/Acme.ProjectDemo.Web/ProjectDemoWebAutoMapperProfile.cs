using Acme.ProjectDemo.Entities.CustomerDetail;
using AutoMapper;

namespace Acme.ProjectDemo.Web
{
    public class ProjectDemoWebAutoMapperProfile : Profile
    {
        public ProjectDemoWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<CustomerDetailDto, CreateUpdateCustomerDetailDto>();
        }
    }
}
