using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MYAcademy_PortfolioProject.Filters
{
    public class AdminNotificationFilter : IActionFilter
    {
        private readonly ILogger<AdminNotificationFilter> _logger;

        public AdminNotificationFilter(ILogger<AdminNotificationFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.RouteData.Values["area"]?.ToString() != "Admin") return;
            if (context.Controller is not Controller controller) return;

            var action = context.RouteData.Values["action"]?.ToString() ?? "";
            var isPost = context.HttpContext.Request.Method == "POST";

            string? verb = null;
            if (action.StartsWith("Create") && isPost) verb = "eklendi";
            else if (action.StartsWith("Update") && isPost) verb = "güncellendi";
            else if (action.StartsWith("Delete")) verb = "silindi";

            if (verb == null) return;

            if (context.Exception != null)
            {
                _logger.LogError(context.Exception, "Admin işlemi başarısız: {Action}", action);
                controller.TempData["Error"] = "İşlem sırasında bir hata oluştu. Kayıt başka kayıtlarla ilişkili olabilir.";

                var referer = context.HttpContext.Request.Headers["Referer"].ToString();
                context.ExceptionHandled = true;
                context.Result = new RedirectResult(string.IsNullOrEmpty(referer) ? "/Admin/Dashboard/Index" : referer);
                return;
            }

            var redirected = context.Result is RedirectToActionResult || context.Result is RedirectResult;
            if (redirected && !controller.TempData.ContainsKey("Success"))
            {
                controller.TempData["Success"] = "Kayıt başarıyla " + verb + ".";
            }
        }
    }
}