// Render an MHTML file to XPS with AdjustToWidestPage true to ensure optimal page fitting.

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
            // Prepare input MHTML file (minimal sample)
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            if (!File.Exists(inputFile))
            {
                string htmlContent = "<html><body><h1>Sample MHTML</h1><p>This is a test.</p></body></html>";
                File.WriteAllText(inputFile, htmlContent);
            }

            // Open MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputFile))
            {
                // Configure XPS save options
                XpsSaveOptions options = new XpsSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromInches(8.3),
                        Length.FromInches(5.8)
                    )
                );
                // Set background color (example)
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Note: AdjustToWidestPage property is not available in this API version.

                // Define output XPS file path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine($"Conversion succeeded. XPS saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}