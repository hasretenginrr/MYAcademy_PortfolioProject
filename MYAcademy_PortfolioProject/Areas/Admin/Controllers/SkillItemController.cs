using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillItemController : Controller
    {
        private readonly PortfolioContext _context;
        public SkillItemController(PortfolioContext context)
        {
            _context = context;
        }

        // Create ve Update formlarındaki "Yetenek" açılır listesini doldurur
        private void LoadSkills()
        {
            ViewBag.Skills = _context.Skills
                .ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.SkillId.ToString()
                })
                .ToList();
        }

        public IActionResult SkillItemList()
        {
            var values = _context.SkillItems
                .Include(x => x.Skill)
                .OrderBy(x => x.SkillId)
                .ThenBy(x => x.SkillItemId)
                .ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkillItem()
        {
            LoadSkills();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkillItem(SkillItem skillItem)
        {
            _context.SkillItems.Add(skillItem);
            _context.SaveChanges();
            return RedirectToAction("SkillItemList");
        }

        [HttpGet]
        public IActionResult UpdateSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            if (value == null)
            {
                return RedirectToAction("SkillItemList");
            }
            LoadSkills();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkillItem(SkillItem skillItem)
        {
            _context.SkillItems.Update(skillItem);
            _context.SaveChanges();
            return RedirectToAction("SkillItemList");
        }

        public IActionResult DeleteSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            if (value != null)
            {
                _context.SkillItems.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("SkillItemList");
        }
    }
}