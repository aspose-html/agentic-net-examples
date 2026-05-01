// Render an MHTML file to PDF while preserving form fields and interactive elements.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            string resultPath = "output.pdf";

            using (FileStream stream = File.OpenRead(sourcePath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertMHTML(stream, options, resultPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}