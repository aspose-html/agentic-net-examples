// Serialize input values only for checkbox elements by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a checkbox and a text input
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <form>
        <input type=""checkbox"" name=""agree"" />
        <input type=""text"" name=""username"" />
    </form>
</body>
</html>";

            // Load HTML from string
            using (HTMLDocument doc = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all input elements
                HTMLCollection inputElements = doc.GetElementsByTagName("input");

                // Set value only for checkbox inputs
                for (int i = 0; i < inputElements.Length; i++)
                {
                    HTMLInputElement input = (HTMLInputElement)inputElements[i];
                    string type = input.GetAttribute("type");
                    if (string.Equals(type, "checkbox", StringComparison.OrdinalIgnoreCase))
                    {
                        input.Value = "CheckedValue";
                    }
                }

                // Configure HTML save options to serialize input values
                HTMLSaveOptions saveOptions = new HTMLSaveOptions();
                saveOptions.SerializeInputValue = true;

                // Define output path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

                // Save the document with the customized options
                doc.Save(outputPath, saveOptions);

                Console.WriteLine($"HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}