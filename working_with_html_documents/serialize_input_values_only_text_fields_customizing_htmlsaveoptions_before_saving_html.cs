// Serialize input values only for text fields by customizing HTMLSaveOptions before saving HTML.

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
            // HTML content containing a text input field
            string html = "<!DOCTYPE html><html><body><input type=\"text\" id=\"myInput\"/></body></html>";
            // Create an HTMLDocument from the string
            HTMLDocument doc = new HTMLDocument(html, string.Empty);

            // Retrieve all input elements
            HTMLCollection inputElements = doc.GetElementsByTagName("input");

            // Set the value of the first input element (assumed to be a text field)
            if (inputElements.Length > 0)
            {
                HTMLInputElement input = (HTMLInputElement)inputElements[0];
                input.Value = "Hello World";
            }

            // Configure save options to serialize input values into the output HTML
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.SerializeInputValue = true;

            // Save the document with the customized options
            string outputPath = "output.html";
            doc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}