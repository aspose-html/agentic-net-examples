// Create an HTML document, add a form with input fields, and save as HTML for testing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><form><input type='text' name='myInput' /></form></body></html>";
            string inputPath = "input.html";
            File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection inputs = doc.GetElementsByTagName("input");
                if (inputs.Length > 0)
                {
                    Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputs[0];
                    input.Value = "Sample Text";
                }

                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.SerializeInputValue = true;

                string outputPath = "output.html";
                doc.Save(outputPath, options);
                Console.WriteLine($"Saved output to {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}