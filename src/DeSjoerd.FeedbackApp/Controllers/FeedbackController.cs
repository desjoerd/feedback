using DeSjoerd.FeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeSjoerd.FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index() {
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Feedback feedback)
        {
            return View("Index");
        }
    }
}