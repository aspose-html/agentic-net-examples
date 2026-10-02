// Configure runtime to limit memory usage, load a large HTML document, and monitor memory consumption.

using System;
using System.Text;
using System.Diagnostics;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define a memory limit (e.g., 200 MB)
            const long memoryLimitBytes = 200L * 1024 * 1024;

            // Measure memory before loading
            long beforeMemory = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory before loading: {beforeMemory / (1024 * 1024)} MB");

            // Create a large HTML content (~50 MB)
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><title>Large Document</title></head><body>");
            for (int i = 0; i < 500000; i++)
            {
                sb.AppendLine($"<p>Paragraph {i}: Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>");
            }
            sb.AppendLine("</body></html>");
            string largeHtml = sb.ToString();

            // Load the HTML document using the two‑argument constructor (content, baseUri)
            var document = new Aspose.Html.HTMLDocument(largeHtml, "about:blank");

            // Measure memory after loading
            long afterMemory = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory after loading: {afterMemory / (1024 * 1024)} MB");

            long usedMemory = afterMemory - beforeMemory;
            Console.WriteLine($"Additional memory used: {usedMemory / (1024 * 1024)} MB");

            // Check against the limit
            if (usedMemory > memoryLimitBytes)
            {
                Console.WriteLine("Warning: Memory usage exceeds the configured limit.");
            }
            else
            {
                Console.WriteLine("Memory usage is within the configured limit.");
            }

            // Optional: Dispose the document explicitly
            document.Dispose();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}