using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.ViewModels;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalProjects = await _context.Projects.CountAsync(),
                ActiveProjects = await _context.Projects.CountAsync(x => x.IsActive),
                SkillCount = await _context.Skills.CountAsync(),
                ExperienceCount = await _context.Experiences.CountAsync(),
                EducationCount = await _context.Educations.CountAsync(),
                TotalMessages = await _context.Messages.CountAsync(),
                UnreadMessages = await _context.Messages.CountAsync(x => !x.IsRead),

                LastMessages = await _context.Messages
                    .OrderByDescending(x => x.SendDate)
                    .Take(5)
                    .ToListAsync(),

                LastProjects = await _context.Projects
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(3)
                    .ToListAsync(),

                CategorySummaries = await _context.Categories
                    .Select(c => new CategorySummary
                    {
                        CategoryName = c.CategoryName,
                        ProjectCount = c.Projects.Count()
                    })
                    .OrderByDescending(x => x.ProjectCount)
                    .ToListAsync()
            };

            var start = DateTime.Today.AddDays(-6);
            var dates = await _context.Messages
                .Where(x => x.SendDate >= start)
                .Select(x => x.SendDate.Date)
                .ToListAsync();

            string[] dayNames = { "Paz", "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt" };
            for (int i = 0; i < 7; i++)
            {
                var day = start.AddDays(i);
                model.Last7Days.Add(new DayCount
                {
                    Label = dayNames[(int)day.DayOfWeek],
                    Count = dates.Count(d => d == day)
                });
            }

            return View(model);
        }
    }
}