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
            string htmlContent = "<!DOCTYPE html><html><body><input type='checkbox' id='cb1'/><input type='text' id='txt1'/></body></html>";
            using (HTMLDocument doc = new HTMLDocument(htmlContent, "about:blank"))
            {
                HTMLCollection inputs = doc.GetElementsByTagName("input");
                // First input is the checkbox
                HTMLInputElement checkbox = (HTMLInputElement)inputs[0];
                checkbox.Value = "CheckedValue";
                checkbox.Checked = true;

                HTMLSaveOptions options = new HTMLSaveOptions();
                options.SerializeInputValue = true;

                string outputPath = "output.html";
                doc.Save(outputPath, options);
                Console.WriteLine($"HTML saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}