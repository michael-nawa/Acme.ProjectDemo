using Acme.ProjectDemo.Entities.CustomerDetail;
using Acme.ProjectDemo.Entities.CustomerDetails;
using AutoMapper;

namespace Acme.ProjectDemo
{
    public class ProjectDemoApplicationAutoMapperProfile : Profile
    {
        public ProjectDemoApplicationAutoMapperProfile()
        {
            CreateMap<CustomerDetail, CustomerDetailDto>();
            CreateMap<CreateUpdateCustomerDetailDto, CustomerDetail>();
        }
    }
}
