using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutStyleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   }

/*Access Modifiers
 Public--> Her yerden erişilebilir.
Private --> sadece o sınıf tarafından erişilebilir.
Protected --> sadece o sınıf ve o sınıftan türetilmiş sınıflar tarafından erişilebilir.
Internal -->sadece o katman ve o katmanın içindeki sınıflar tarafından erişilebilir.
 */
