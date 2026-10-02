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

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><p>Line1<br/>Line2<br/>Line3</p></body></html>");
            }

            using (Stream stream = File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}