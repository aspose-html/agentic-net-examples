// Control the presence of a CSS class attribute by binding its value from the JSON data source.

using System;
using System.Text.Json;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><div id=\"myDiv\">Content</div></body></html>";

            // Sample JSON data source
            string jsonContent = "{\"className\":\"highlight\"}";

            // Parse JSON to get the class name
            using JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);
            string className = jsonDoc.RootElement.GetProperty("className").GetString();

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find the target element
            Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)document.QuerySelector("#myDiv");
            if (element != null && !string.IsNullOrEmpty(className))
            {
                // Bind the class attribute from JSON data
                element.SetAttribute("class", className);
            }

            // Save the modified document
            document.Save("output.html");
            Console.WriteLine("Document saved as output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}