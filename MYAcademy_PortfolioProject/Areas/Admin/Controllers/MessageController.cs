using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;
        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList(string? search)
        {
            var query = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.SenderName.Contains(search) || x.Subject.Contains(search));
            }

            ViewBag.Search = search;
            ViewBag.UnreadCount = _context.Messages.Count(x => !x.IsRead);

            var values = query.OrderByDescending(x => x.SendDate).ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            if (!value.IsRead)
            {
                value.IsRead = true;
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult ToggleRead(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = !value.IsRead;
                _context.SaveChanges();
            }
            return RedirectToAction("MessageList");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Mesaj silindi.";
            }
            return RedirectToAction("MessageList");
        }
    }
}