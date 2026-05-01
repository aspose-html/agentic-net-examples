// Create an HTML document, add a form with input fields, and save as HTML for testing.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

namespace HtmlFormExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML content with a simple form and an input field
                string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='username' /></form></body></html>";
                string outputPath = "form.html";

                // Create an HTMLDocument from the string content
                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);

                // Retrieve all input elements in the document
                HTMLCollection inputElements = doc.GetElementsByTagName("input");

                // Set a value for the first input element
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                input.Value = "test";

                // Configure save options to serialize the input's value into the saved HTML
                HTMLSaveOptions options = new HTMLSaveOptions();
                options.SerializeInputValue = true;

                // Save the modified document to a file
                doc.Save(outputPath, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}