// Serialize input values only for checkbox elements by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing an input element
            string htmlContent = "<!DOCTYPE html><html><body><input type='text' /></body></html>";
            string baseUrl = string.Empty;

            // Load the HTML document from the string
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, baseUrl))
            {
                // Get all input elements
                Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");

                // Set the value of the first input element, if any
                if (inputElements != null && inputElements.Length > 0)
                {
                    Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                    input.Value = "Text";
                }

                // Prepare save options to serialize input values
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.SerializeInputValue = true;

                // Define output path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

                // Save the modified document
                doc.Save(outputPath, options);
                Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}