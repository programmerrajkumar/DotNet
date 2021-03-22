using System;
using LoggingFeature.OptimizedLogging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LoggingFeature.Page
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogIndexPageRequestStarted(DateTime.Now.ToString());

            using (_logger.BeginScope("Scope:Razor Index"))
            {

                _logger.LogInformation(CustomEvent.OnGetStarted, "On Get Started");

                var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                byte one = 1, two = 2, three = 3;
                _logger.LogWarning("Razor Index Page OnGet. from {placeholder1} @ {placeholder2}", processName, DateTime.Now);
                _logger.LogError("Ready {three} {two} {one} GO", one, two, three);

                _logger.LogCritical(CustomEvent.OnGetComplete, new Exception("Exception during On Get Completed"), "On Get Completed");
            }

            _logger.LogIndexPageRequestEnded(DateTime.Now.ToString());
        }
    }

    public class CustomEvent
    {
        public const int OnGetStarted = 3000;

        public const int OnGetComplete = 3001;
    }
}
