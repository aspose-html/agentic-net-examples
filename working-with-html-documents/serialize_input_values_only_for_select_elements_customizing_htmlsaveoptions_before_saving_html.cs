// Serialize input values only for select elements by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content with an input element
            string htmlContent = "<!DOCTYPE html><html><body><input type=\"text\" /></body></html>";
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Write the sample HTML to a file (required for HTMLDocument constructor)
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath, string.Empty))
            {
                // Get all input elements
                Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");

                // Modify the value of the first input element, if present
                if (inputElements.Length > 0)
                {
                    Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                    input.Value = "Text";
                }

                // Set save options to serialize input values
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.SerializeInputValue = true;

                // Save the modified document
                doc.Save(outputPath, options);
            }

            Console.WriteLine("Document saved successfully to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}