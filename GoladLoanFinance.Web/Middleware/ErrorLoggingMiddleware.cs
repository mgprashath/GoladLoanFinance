namespace GoldLoanFinance.Web.Middleware
{
    using System.Diagnostics;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;

    public sealed class ErrorLoggingMiddleware : IMiddleware
    {
        private static readonly object _lock = new();
        private readonly IWebHostEnvironment _env;

        public ErrorLoggingMiddleware(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                sw.Stop();
                WriteToFile(context, ex, sw.Elapsed);
                throw; 
            }
        }

        private string ResolveLogFilePath()
        {
            var rootPath = _env.ContentRootPath;
            if (rootPath.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            {
                var p = Directory.GetParent(rootPath)?.Parent?.Parent?.Parent;
                if (p != null) rootPath = p.FullName;
            }

            var logsDir = Path.Combine(rootPath, "Logs");
            Directory.CreateDirectory(logsDir);

            var fileName = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";   
            return Path.Combine(logsDir, fileName);
        }

        private void WriteToFile(HttpContext ctx, Exception ex, TimeSpan elapsed)
        {
            var sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------------");
            sb.AppendLine($"Utc:        {DateTime.UtcNow:O}");
            sb.AppendLine($"Path:       {ctx.Request?.Method} {ctx.Request?.Path}");
            sb.AppendLine($"Query:      {ctx.Request?.QueryString}");
            sb.AppendLine($"TraceId:    {ctx.TraceIdentifier}");
            sb.AppendLine($"Elapsed:    {elapsed.TotalMilliseconds} ms");
            sb.AppendLine($"Message:    {ex.Message}");
            sb.AppendLine($"StackTrace: {ex.StackTrace}");
            if (ex.InnerException != null)
                sb.AppendLine($"Inner:      {ex.InnerException.Message}");
            sb.AppendLine();

            var logFile = ResolveLogFilePath();  
            lock (_lock)
            {
                File.AppendAllText(logFile, sb.ToString());
            }
        }
    }
}
