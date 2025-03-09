using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
namespace ASC.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
