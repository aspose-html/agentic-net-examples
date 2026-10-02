// Serialize input values only for select elements by customizing HTMLSaveOptions before saving HTML.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<select id='mySelect'>" +
                                 "<option value='1'>One</option>" +
                                 "<option value='2'>Two</option>" +
                                 "</select>" +
                                 "<input type='text' id='myInput' />" +
                                 "</body></html>";

            string outputPath = "output.html";

            using Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            HTMLCollection inputElements = doc.GetElementsByTagName("input");
            if (inputElements.Length > 0)
            {
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                input.Value = "Sample Text";
            }

            HTMLCollection selectElements = doc.GetElementsByTagName("select");
            if (selectElements.Length > 0)
            {
                Aspose.Html.HTMLSelectElement select = (Aspose.Html.HTMLSelectElement)selectElements[0];
                select.Value = "2";
            }

            HTMLSaveOptions options = new HTMLSaveOptions();
            options.SerializeInputValue = true;

            doc.Save(outputPath, options);
            Console.WriteLine($"HTML saved to '{Path.GetFullPath(outputPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}