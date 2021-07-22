using Acme.ProjectDemo.Entities.CustomerDetails;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.ProjectDemo.Entities.CustomerDetail
{
    public class CustomerDetailDto : AuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public EducationalType EducationalLevel { get; set; }
        public string ProfilePhoto { get; set; }
        public string PhoneNumber { get; set; }
        public string UploadDocuments { get; set; }
        public string Job { get; set; }
        public string BankDetails { get; set; }
        public string ShippingAddress { get; set; }
        public string UserEmail { get; set; }
    }
}
