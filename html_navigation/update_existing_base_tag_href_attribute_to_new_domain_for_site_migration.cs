// Update existing base tag href attribute to a new domain for site migration.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the original HTML file
            string inputPath = "input.html";
            // Path where the updated HTML will be saved
            string outputPath = "output.html";
            // New domain to set in the <base> tag href attribute
            string newBaseHref = "https://newdomain.com/";

            // Load the existing HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Locate the <base> element
            var baseElements = document.GetElementsByTagName("base");
            if (baseElements.Length > 0)
            {
                // Cast the first <base> element to HTMLElement
                var baseElement = baseElements[0] as Aspose.Html.HTMLElement;
                if (baseElement != null)
                {
                    // Update the href attribute to the new domain
                    baseElement.SetAttribute("href", newBaseHref);
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}