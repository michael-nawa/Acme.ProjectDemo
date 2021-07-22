using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProjectDemo.Entities.CustomerDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.ProjectDemo.Web.Pages.Admin.CustomerDetails
{
    public class CreateModalModel : ProjectDemoPageModel
    {
        [BindProperty]
        public CreateUpdateCustomerDetailDto CustomerDetailModal { get; set; }

        private readonly ICustomerDetailAppService _repo;

        public CreateModalModel(ICustomerDetailAppService repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
            CustomerDetailModal = new CreateUpdateCustomerDetailDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _repo.CreateAsync(CustomerDetailModal);
            return NoContent();
        }
    }
}
