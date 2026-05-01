// Serialize form input values when saving an HTML document to another HTML file by enabling HTMLSaveOptions.SerializeInputValue.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML source containing an input element
            string html = "<!DOCTYPE html><html><body><input type='text' id='myInput'></body></html>";
            // Path where the output HTML will be saved
            string outputPath = "output.html";

            // Create an HTMLDocument from the HTML string
            using (HTMLDocument doc = new HTMLDocument(html, string.Empty))
            {
                // Retrieve all input elements in the document
                HTMLCollection inputElements = doc.GetElementsByTagName("input");
                if (inputElements.Length > 0)
                {
                    // Access the first input element and set its value
                    HTMLInputElement input = (HTMLInputElement)inputElements[0];
                    input.Value = "Sample Text";
                }

                // Configure save options to serialize input values
                HTMLSaveOptions options = new HTMLSaveOptions();
                options.SerializeInputValue = true;

                // Save the document with the configured options
                doc.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}