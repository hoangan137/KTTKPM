using ASC.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASC.Web.Areas.ServiceRequests.Controllers

{
    [Area("ServiceRequests")]
    public class DashboardController : BaseController
    {
        public IOptions<ApplicationSettings> _settings;
         public DashboardController(IOptions<ApplicationSettings> settings)
        {  _settings = settings; }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
