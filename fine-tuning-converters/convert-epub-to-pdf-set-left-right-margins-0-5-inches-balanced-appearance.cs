// Convert an EPUB to PDF and set both left and right margins to 0.5 inches for balanced appearance.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file path (ensure this file exists)
            string inputPath = "sample.epub";

            // Output PDF file path
            string outputPath = Path.Combine("output", "result.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options with custom margins
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                // Define page size (A4) and margins (0.5 inches left and right)
                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.27),
                        Aspose.Html.Drawing.Length.FromInches(11.69)
                    ),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(0.5), // left
                        Aspose.Html.Drawing.Length.FromInches(0),   // top
                        Aspose.Html.Drawing.Length.FromInches(0.5), // right
                        Aspose.Html.Drawing.Length.FromInches(0)    // bottom
                    )
                );

                options.PageSetup.AnyPage = page;

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine("EPUB successfully converted to PDF.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}