using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _env;

        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSize = 2 * 1024 * 1024; // 2 MB

        public ProjectController(PortfolioContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        private void LoadCategories()
        {
            ViewBag.Categories = _context.Categories
                .ToList()
                .Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                })
                .ToList();
        }

        private string? ValidateImage(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
                return "Sadece .jpg, .jpeg, .png veya .webp dosyası yükleyebilirsiniz.";
            if (!file.ContentType.StartsWith("image/"))
                return "Yüklenen dosya bir görsel olmalıdır.";
            if (file.Length > MaxFileSize)
                return "Görsel en fazla 2 MB olabilir.";
            return null;
        }

        private string SaveImage(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var folder = Path.Combine(_env.WebRootPath, "uploads", "projects");
            Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid().ToString("N") + ext;
            using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return "/uploads/projects/" + fileName;
        }

        private void DeleteImage(string? path)
        {
            if (string.IsNullOrEmpty(path) || !path.StartsWith("/uploads/projects/")) return;
            var full = Path.Combine(_env.WebRootPath, "uploads", "projects", Path.GetFileName(path));
            if (System.IO.File.Exists(full))
            {
                System.IO.File.Delete(full);
            }
        }

        public IActionResult ProjectList(int? categoryId, string sort = "newest")
        {
            var query = _context.Projects.Include(x => x.Category).AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            query = sort switch
            {
                "oldest" => query.OrderBy(x => x.CreatedDate),
                "title" => query.OrderBy(x => x.ProjectTitle),
                _ => query.OrderByDescending(x => x.CreatedDate)
            };

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.SelectedCategory = categoryId;
            ViewBag.Sort = sort;

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            LoadCategories();
            return View(new Project());
        }

        [HttpPost]
        public IActionResult CreateProject(Project project, IFormFile? imageFile)
        {
            var hasFile = imageFile != null && imageFile.Length > 0;
            if (hasFile)
            {
                var error = ValidateImage(imageFile!);
                if (error != null) ModelState.AddModelError("ImageUrl", error);
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(project);
            }

            if (hasFile)
            {
                project.ImageUrl = SaveImage(imageFile!);
            }
            project.CreatedDate = DateTime.Now;

            _context.Projects.Add(project);
            _context.SaveChanges();

            TempData["Success"] = "Proje başarıyla eklendi.";
            return RedirectToAction("ProjectList");
        }


        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value == null)
            {
                return RedirectToAction("ProjectList");
            }
            LoadCategories();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project, IFormFile? imageFile)
        {
            
            var existing = _context.Projects.AsNoTracking().FirstOrDefault(x => x.ProjectId == project.ProjectId);
            if (existing == null)
            {
                return RedirectToAction("ProjectList");
            }
            project.ImageUrl = existing.ImageUrl;
            project.CreatedDate = existing.CreatedDate;

            var hasFile = imageFile != null && imageFile.Length > 0;
            if (hasFile)
            {
                var error = ValidateImage(imageFile!);
                if (error != null) ModelState.AddModelError("ImageUrl", error);
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(project);
            }

            if (hasFile)
            {
                DeleteImage(existing.ImageUrl);      
                project.ImageUrl = SaveImage(imageFile!);
            }

            _context.Projects.Update(project);
            _context.SaveChanges();

            TempData["Success"] = "Proje başarıyla güncellendi.";
            return RedirectToAction("ProjectList");
        }

        public IActionResult DeleteProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value != null)
            {
                DeleteImage(value.ImageUrl);
                _context.Projects.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Proje silindi.";
            }
            return RedirectToAction("ProjectList");
        }
    }
}