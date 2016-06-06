using DeSjoerd.FeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeSjoerd.FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly FeedbackContext _feedbackContext;

        public FeedbackController(FeedbackContext feedbackContext)
        {
            if (feedbackContext == null) throw new ArgumentNullException(nameof(feedbackContext));

            _feedbackContext = feedbackContext;
        }

        public IActionResult Index()
        {
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Feedback feedback)
        {
            _feedbackContext.Feedbacks.Add(feedback);

            await _feedbackContext.SaveChangesAsync();

            return View("Index");
        }
    }
}