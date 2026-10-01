// Serialize input values only for text fields by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an input element
            string htmlContent = "<html><body><input type='text' id='myInput'></body></html>";

            // Create an HTML document from the content
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(string.Empty, htmlContent);

            // Get the collection of input elements
            Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");

            if (inputElements.Length == 0)
                throw new InvalidOperationException("No input elements found in the document.");

            // Cast the first element to HTMLInputElement and set its value
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
            input.Value = "Text";

            // Prepare save options to serialize the input value
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.SerializeInputValue = true;

            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the modified document
            doc.Save(outputPath, options);

            Console.WriteLine($"Document saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}