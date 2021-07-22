using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProjectDemo.Entities.CustomerDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Users;

namespace Acme.ProjectDemo.Web.Pages.Admin.CustomerDetails
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDetailAppService _repo;
        private readonly ICurrentUser _currentUser;

        public IndexModel(ICustomerDetailAppService repo, ICurrentUser currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }

        public async Task OnGetAsync()
        {
            var user = _currentUser.Email;
            var data = await _repo.GetUserDetails("user@user.com");
        }
    }
}
