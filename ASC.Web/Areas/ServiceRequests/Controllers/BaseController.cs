using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
namespace ASC.Web.Areas.ServiceRequests.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        // public IActionResult Index()
        //{
        //     return View();
        // }
    }
}
