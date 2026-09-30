// Provide a base URL in HtmlLoadOptions when converting MHTML to ensure relative links resolve correctly in the PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "Dummy MHTML content");
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully. PDF saved to: " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}