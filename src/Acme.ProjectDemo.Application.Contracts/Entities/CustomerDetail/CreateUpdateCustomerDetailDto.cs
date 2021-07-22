using Acme.ProjectDemo.Entities.CustomerDetails;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.ProjectDemo.Entities.CustomerDetail
{
    public class CreateUpdateCustomerDetailDto
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = new DateTime(1990, 1, 1);

        [Required]
        public string Address { get; set; }

        [Required]
        public EducationalType EducationalLevel { get; set; } = EducationalType.Undefined;

        public string ProfilePhoto { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        public string UploadDocuments { get; set; }
        [Required]

        public string Job { get; set; }
        [Required]

        public string BankDetails { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string UserEmail { get; set; }

        public IFormFile ProfilePhotoFile { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
