// Configure sandbox to allow scripts but limit execution time, load a page, and verify script timeout.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create configuration and enable script execution
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                configuration.Security |= Aspose.Html.Sandbox.Scripts;

                // Set JavaScript execution timeout (if supported)
                var runtime = configuration.GetService<Aspose.Html.Services.IRuntimeService>();
                if (runtime != null)
                {
                    runtime.JavaScriptTimeout = System.TimeSpan.FromSeconds(2);
                }

                // Sample HTML containing a long‑running script
                string html = "<!DOCTYPE html><html><head><script>var start = Date.now(); while (Date.now() - start < 5000) {} </script></head><body><p>Hello World</p></body></html>";

                // Load the document with the sandbox configuration
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
                {
                    string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                    System.Console.WriteLine(text);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}