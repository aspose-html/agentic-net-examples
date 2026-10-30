// Configure sandbox to limit JavaScript memory usage, load a script‑intensive page, and monitor resource consumption.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Set JavaScript timeout as a resource limit proxy
            var runtime = config.GetService<Aspose.Html.Services.IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = System.TimeSpan.FromSeconds(5);
            }

            // Sample HTML with many script blocks
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>";
            for (int i = 0; i < 100; i++)
            {
                htmlContent += "<script>var arr = []; for (var j=0;j<1000;j++) {arr.push(j);} console.log('script " + i + "');</script>";
            }
            htmlContent += "</body></html>";

            // Record memory usage before loading
            long memBefore = System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64;

            // Load the document with the configured sandbox
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", config))
            {
                // Access document content to ensure processing
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine("Document text length: " + text.Length);
            }

            // Record memory usage after loading
            long memAfter = System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64;
            System.Console.WriteLine("Memory before: " + memBefore);
            System.Console.WriteLine("Memory after: " + memAfter);
            System.Console.WriteLine("Memory delta: " + (memAfter - memBefore));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}