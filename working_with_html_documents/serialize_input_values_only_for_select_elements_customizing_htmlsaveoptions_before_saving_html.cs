// Serialize input values only for select elements by customizing HTMLSaveOptions before saving HTML.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

namespace SerializeInputValueExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<!DOCTYPE html><html><body><input type='text' id='myInput'></body></html>";
                HTMLDocument doc = new HTMLDocument(html, string.Empty);
                HTMLCollection inputElements = doc.GetElementsByTagName("input");
                if (inputElements.Length > 0)
                {
                    HTMLInputElement input = (HTMLInputElement)inputElements[0];
                    input.Value = "Sample Text";
                }
                HTMLSaveOptions options = new HTMLSaveOptions();
                options.SerializeInputValue = true;
                string outputPath = "output.html";
                doc.Save(outputPath, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}