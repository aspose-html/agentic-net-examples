// Export an MHTML document to PDF while preserving hyperlinks and interactive elements.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "input.mht";
            string resultPath = "output.pdf";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, resultPath);
            }

            Console.WriteLine("Conversion completed. PDF saved to " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}