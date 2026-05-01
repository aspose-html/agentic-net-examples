// Serialize input values only for checkbox elements by customizing HTMLSaveOptions before saving HTML.

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
            // HTML source containing checkbox and other inputs
            string html = @"<html><body>
                <input type='checkbox' id='c1' />
                <input type='checkbox' id='c2' />
                <input type='text' id='t1' />
                </body></html>";

            // Create an HTMLDocument from the string
            HTMLDocument doc = new HTMLDocument(html, string.Empty);

            // Retrieve all input elements
            HTMLCollection inputElements = doc.GetElementsByTagName("input");

            // Iterate through inputs and set value for checkboxes only
            for (int i = 0; i < inputElements.Length; i++)
            {
                HTMLInputElement input = (HTMLInputElement)inputElements[i];
                if (input.Type != null && input.Type.Equals("checkbox", StringComparison.OrdinalIgnoreCase))
                {
                    // Example: set a custom value for the checkbox
                    input.Value = "Checked";
                }
            }

            // Configure save options to serialize input values
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.SerializeInputValue = true;

            // Save the modified document
            string outputPath = "output.html";
            doc.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}