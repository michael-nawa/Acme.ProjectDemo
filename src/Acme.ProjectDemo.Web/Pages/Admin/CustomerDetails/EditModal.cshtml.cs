using System;
using System.Threading.Tasks;
using Acme.ProjectDemo.Entities.CustomerDetail;
using Microsoft.AspNetCore.Mvc;

namespace Acme.ProjectDemo.Web.Pages.Admin.CustomerDetails
{
    public class EditModalModel : ProjectDemoPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid id { get; set; }

        [BindProperty]
        public CreateUpdateCustomerDetailDto CustomerDetailModal { get; set; }

        private readonly ICustomerDetailAppService _repo;

        public EditModalModel(ICustomerDetailAppService repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            var data = await _repo.GetAsync(id);
            CustomerDetailModal = ObjectMapper.Map<CustomerDetailDto, CreateUpdateCustomerDetailDto>(data);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _repo.UpdateAsync(id, CustomerDetailModal);
            return NoContent();
        }
    }
}
