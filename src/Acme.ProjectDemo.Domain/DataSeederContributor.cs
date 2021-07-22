using Acme.ProjectDemo.Entities.CustomerDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.ProjectDemo
{
    public class DataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CustomerDetail, Guid> _customerDetailRepository;

        public DataSeederContributor(IRepository<CustomerDetail, Guid> customerDetails)
        {
            _customerDetailRepository = customerDetails;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _customerDetailRepository.GetCountAsync() <= 0)
            {
                await _customerDetailRepository.InsertAsync(
                    new CustomerDetail
                    {
                        FirstName = "Anastazia",
                        LastName = "Tembo",
                        DateOfBirth = new DateTime(1949, 6, 8),
                        Address = "Woodlands Chalala",
                        EducationalLevel = EducationalType.Certificate,
                        ProfilePhoto = "",
                        PhoneNumber = "+26097895856",
                        UploadDocuments = "",
                        Job = "Secritary",
                        BankDetails = "Stanbic, AccountNum: 8856-5555-8852",
                        ShippingAddress = "Woodlands Chalala Plot# 25785"
                    },
                    autoSave: true
                );
                await _customerDetailRepository.InsertAsync(
                   new CustomerDetail
                   {
                       FirstName = "Lisa",
                       LastName = "Jane",
                       DateOfBirth = new DateTime(1999, 4, 18),
                       Address = "New Ksama",
                       EducationalLevel = EducationalType.Diploma,
                       ProfilePhoto = "",
                       PhoneNumber = "+26485452",
                       UploadDocuments = "",
                       Job = "Software Developer",
                       BankDetails = "Stanbic, AccountNum: 8856-5896-8852",
                       ShippingAddress = "New Ksama Plot# 62587"
                   },
                   autoSave: true
               );
                await _customerDetailRepository.InsertAsync(
                   new CustomerDetail
                   {
                       FirstName = "Jane",
                       LastName = "Doe",
                       DateOfBirth = new DateTime(1949, 6, 8),
                       Address = "Chelstone",
                       EducationalLevel = EducationalType.Doctorate,
                       ProfilePhoto = "",
                       PhoneNumber = "+26097842563",
                       UploadDocuments = "",
                       Job = "Software Developer",
                       BankDetails = "Absa, AccountNum: 8856-2654-3628",
                       ShippingAddress = "Chelstone Plot# 25785"
                   },
                   autoSave: true
               );
            }
        }
    }
}
