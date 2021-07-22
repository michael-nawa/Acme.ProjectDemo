using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.ProjectDemo.Pages
{
    public class Index_Tests : ProjectDemoWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
