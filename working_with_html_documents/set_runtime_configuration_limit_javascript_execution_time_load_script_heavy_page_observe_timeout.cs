// Set runtime configuration to limit JavaScript execution time, load a script‑heavy page, and observe timeout.

using System;
using Aspose.Html;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            var runtime = config.GetService<IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(5);
            }

            string url = "https://example.com/script-heavy.html";

            using (var document = new Aspose.Html.HTMLDocument(url, config))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}