// Convert an EPUB to PDF and set both left and right margins to 0.5 inches for balanced appearance.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input EPUB file path
            string inputPath = System.IO.Path.Combine("input", "sample.epub");
            // Ensure the input file exists (create a minimal placeholder if needed)
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(inputPath));
                // Create an empty EPUB file as placeholder (real EPUB content should be placed here)
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Define output PDF file path
            string outputPath = System.IO.Path.Combine("output", "result.pdf");
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputPath));

            // Open EPUB file stream
            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                // Configure PDF save options with margins of 0.5 inches on left and right
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5), // page width
                        Aspose.Html.Drawing.Length.FromInches(11)   // page height
                    ),
                    new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(0.5), // left margin
                        Aspose.Html.Drawing.Length.FromInches(0),   // top margin
                        Aspose.Html.Drawing.Length.FromInches(0.5), // right margin
                        Aspose.Html.Drawing.Length.FromInches(0)    // bottom margin
                    )
                );

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}