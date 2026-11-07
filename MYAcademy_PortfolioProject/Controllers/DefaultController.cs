using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;
        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();

                TempData["ContactError"] = error ?? "Lütfen formu kontrol edin.";
                return Redirect(Url.Action("Index", "Default") + "#contact");
            }

            message.SendDate = DateTime.Now;
            message.IsRead = false;
            if (string.IsNullOrWhiteSpace(message.Subject))
            {
                message.Subject = "Konu belirtilmedi";
            }

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["ContactSuccess"] = "Mesajınız başarıyla gönderildi. En kısa sürede dönüş yapacağım.";
            return Redirect(Url.Action("Index", "Default") + "#contact");
        }
    }
}