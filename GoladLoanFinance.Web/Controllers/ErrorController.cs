using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GoldLoanFinance.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var feat = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (feat?.Error != null)
                AppendToDailyLog($"EX {DateTime.UtcNow:O} {feat.Path}\n{feat.Error}\n");

            return View("Error"); 
        }

        [Route("Error/Status/{code}")]
        public IActionResult Status(int code)
        {
            var f = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            AppendToDailyLog($"SC {DateTime.UtcNow:O} {code} {f?.OriginalPath}{f?.OriginalQueryString}\n");
            if (code == 404) return View("Status404"); 
            return View("Status");                     
        }

        private static void AppendToDailyLog(string text)
        {
            var root = AppContext.BaseDirectory;
            if (root.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}",
                              StringComparison.OrdinalIgnoreCase))
                root = Directory.GetParent(root)!.Parent!.Parent!.Parent!.FullName;

            var dir = Path.Combine(root, "Logs");
            Directory.CreateDirectory(dir);

            var file = Path.Combine(dir, $"Log_{DateTime.Now:yyyy-MM-dd}.txt");
            System.IO.File.AppendAllText(file, text + Environment.NewLine + "-----------------------------" + Environment.NewLine);
        }
    }   
}
    