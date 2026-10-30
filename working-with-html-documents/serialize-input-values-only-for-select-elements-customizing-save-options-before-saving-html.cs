// Serialize input values only for select elements by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body>" +
                          "<input type='text' id='txt'/>" +
                          "<select id='sel'><option value='1'>One</option><option value='2' selected>Two</option></select>" +
                          "</body></html>";

            string outputPath = "output.html";

            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");
                if (inputElements.Length > 0)
                {
                    Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                    input.Value = "Sample Text";
                }

                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.SerializeInputValue = true;

                doc.Save(outputPath, options);
            }

            Console.WriteLine("HTML saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}