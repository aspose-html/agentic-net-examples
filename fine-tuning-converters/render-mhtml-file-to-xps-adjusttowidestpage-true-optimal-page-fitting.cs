// Render an MHTML file to XPS with AdjustToWidestPage true to ensure optimal page fitting.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""></head><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure XPS save options
                XpsSaveOptions options = new XpsSaveOptions();
                options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(8.3f), Length.FromInches(5.8f)));
                options.BackgroundColor = System.Drawing.Color.AliceBlue; // optional background color

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully converted to XPS at:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}