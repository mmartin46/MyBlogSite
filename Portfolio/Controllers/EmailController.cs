using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class EmailController : Controller
    {
        const int INVALID_VALUE = -1;
        private readonly ISenderRepository _senderRepository = null;
        private readonly Services.IEmailSender _emailSender = null;

        public EmailController(ISenderRepository senderRepository, Services.IEmailSender emailSender)
        {
            _senderRepository = senderRepository;
            _emailSender = emailSender;
        }

        public ViewResult Index()
        {
            return View();
        }
        
        public ViewResult AddSender(bool didSend, int sendId)
        {
            ViewBag.didSend = didSend;
            ViewBag.sendId = sendId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSender(SenderModel senderModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _senderRepository.AddSender(senderModel);
                // If the ID is invalid or the model state is valid, set didSend
                // to true.
                if (id >= INVALID_VALUE)
                {
                    var emailSent = await _emailSender.SendEmailAsync(senderModel.Email, senderModel.Subject, senderModel.Message);

                    if (emailSent)
                    {
                        return RedirectToAction(nameof(AddSender), new { didSend = true, sendId = id });
                    }
                    else
                    {
                        return RedirectToAction(nameof(AddSender), new { didSend = false, sendId = id });
                    }
                }
            }
            return View();
        }
     
        
    }
}
