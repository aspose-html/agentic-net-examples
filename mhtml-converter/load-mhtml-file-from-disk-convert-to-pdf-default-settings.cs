// Load an MHTML file from disk and convert it to PDF using default settings.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

            if (!System.IO.File.Exists(inputPath))
            {
                string minimalHtml = "<html><body><h1>Hello MHTML</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, minimalHtml);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}