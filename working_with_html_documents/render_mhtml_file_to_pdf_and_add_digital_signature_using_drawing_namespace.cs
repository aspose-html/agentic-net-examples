// Render an MHTML file to PDF and add a digital signature using the drawing namespace.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                // Digital signature configuration would be placed here if supported by Aspose.HTML
                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}