// Render an MHTML file to PDF while preserving form fields and interactive elements.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string resultPath = "sample.pdf";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, resultPath);
            }

            Console.WriteLine("MHTML has been successfully converted to PDF: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}