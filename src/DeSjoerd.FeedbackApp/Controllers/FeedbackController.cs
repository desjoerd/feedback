using Microsoft.AspNetCore.Mvc;

namespace DeSjoerd.FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}