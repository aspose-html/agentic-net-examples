// Apply a custom CSS class to all code block nodes by modifying their syntax properties.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><style>.custom-code{background-color:#f0f0f0;}</style></head><body><p>Example:</p><pre><code>int x = 5;</code></pre></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("code");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.SetAttribute("class", "custom-code");
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}