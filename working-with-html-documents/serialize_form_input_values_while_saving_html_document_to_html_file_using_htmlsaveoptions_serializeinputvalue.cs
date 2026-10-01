// Serialize form input values when saving an HTML document to another HTML file by enabling HTMLSaveOptions.SerializeInputValue.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an input element
            string htmlContent = "<!DOCTYPE html><html><body><input type='text' /></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);

            // Get all input elements
            Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");

            // Modify the first input element's value if it exists
            if (inputElements.Length > 0)
            {
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                input.Value = "Text";
            }

            // Set save options to serialize input values
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.SerializeInputValue = true;

            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the modified document
            doc.Save(outputPath, options);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}