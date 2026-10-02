// Serialize input values only for text fields by customizing HTMLSaveOptions before saving HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' id='txt1'><input type='checkbox' id='chk1'></form></body></html>";
            string outputPath = "output.html";

            using Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");
            for (int i = 0; i < inputElements.Length; i++)
            {
                Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[i];
                if (input.Type == "text")
                {
                    input.Value = "Sample Text";
                }
            }

            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.SerializeInputValue = true;
            doc.Save(outputPath, options);
            Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}