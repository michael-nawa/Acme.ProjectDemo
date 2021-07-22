using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acme.ProjectDemo.Entities.CustomerDetail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;
using Volo.Abp.Users;

namespace Acme.ProjectDemo.Web.Pages.Customer.CustomerDetails
{
    public class IndexModel : ProjectDemoPageModel
    {
        [BindProperty]
        public CreateUpdateCustomerDetailDto CustomerDetailModal { get; set; } = new CreateUpdateCustomerDetailDto();
        public CustomerDetailDto customerDetailDto { get; set; }
        public bool hasData { get; set; }
        public string userEmail { get; set; }
        public Guid Id { get; set; }


        private readonly ICustomerDetailAppService _repo;
        private readonly ICurrentUser _currentUser;
        private readonly IAlertManager _alertManager;
        private readonly IWebHostEnvironment _env;

        public IndexModel(ICustomerDetailAppService repo, ICurrentUser currentUser, IAlertManager alertManager, IWebHostEnvironment env)
        {
            _repo = repo;
            _currentUser = currentUser;
            _alertManager = alertManager;
            _env = env;
        }

        public async Task OnGetAsync()
        {
            await checkUserDataAsync();

            if (hasData)
            {
                CustomerDetailModal = ObjectMapper.Map<CustomerDetailDto, CreateUpdateCustomerDetailDto>(customerDetailDto);
            }
            else
            {
                CustomerDetailModal.UserEmail = userEmail;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = (Object)null;
            await checkUserDataAsync();
            await UploadFiles();

            if (hasData)
            {
                try
                {
                    Debug.WriteLine($"Is Updating");
                    result = await _repo.UpdateAsync(Id, CustomerDetailModal);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"ERROR: {e}");
                }
            }
            else
            {
                try
                {
                    Debug.WriteLine($"Is Creating");
                    result = await _repo.CreateAsync(CustomerDetailModal);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"ERROR: {e}");
                }

            }

            if (result != null)
            {
                _alertManager.Alerts.Add(AlertType.Success, "Profile Updated!");
            }
            else
            {
                _alertManager.Alerts.Add(AlertType.Danger, "Error while updating profile");
            }

            return Page();
        }

        private async Task UploadFiles()
        {
            //check if image was uploaded  
            if (CustomerDetailModal.ProfilePhotoFile != null)
            {
                try
                {
                    var profileTitle = await UploadFile(
                    CustomerDetailModal,
                    CustomerDetailModal.ProfilePhotoFile.FileName,
                    CustomerDetailModal.ProfilePhotoFile
                    );
                    if (profileTitle != null)
                    {
                        CustomerDetailModal.ProfilePhoto = profileTitle;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"ERROR: {e}");
                }

            }

            //check if document was uploaded
            if (CustomerDetailModal.DocumentFile != null)
            {
                try
                {
                    var documentFile = await UploadFile(
                     CustomerDetailModal,
                     CustomerDetailModal.DocumentFile.FileName,
                     CustomerDetailModal.DocumentFile,
                     "Documents"
                     );
                    if (documentFile != null)
                    {
                        CustomerDetailModal.UploadDocuments = documentFile;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"ERROR: {e}");
                }
            }
        }

        public async Task<string> UploadFile(CreateUpdateCustomerDetailDto model, String fileName, IFormFile formFile, string folderName = "Images")
        {
            var uniqueFileName = GetUniqueFileName(fileName);
            var dir = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var filePath = Path.Combine(dir, uniqueFileName);
            await formFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Guid.NewGuid().ToString().Substring(0, 15)
                   + Path.GetExtension(fileName);
        }

        public async Task<bool> checkUserDataAsync()
        {
            userEmail = _currentUser.Email;
            customerDetailDto = await _repo.GetUserDetails(userEmail);

            if (customerDetailDto != null)
            {
                hasData = true;
                Id = customerDetailDto.Id;
                return hasData;
            }
            else
            {
                hasData = false;
                return hasData;
            }
        }
    }
}
