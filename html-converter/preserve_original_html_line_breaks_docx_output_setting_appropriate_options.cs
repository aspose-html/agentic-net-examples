// Preserve original HTML line breaks in DOCX output by setting appropriate options in DocSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.docx";

            // Create a minimal HTML file with line breaks
            string htmlContent = "<html><body><p>Line1</p>\n<p>Line2</p>\n<p>Line3</p></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Convert HTML to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, string.Empty, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}