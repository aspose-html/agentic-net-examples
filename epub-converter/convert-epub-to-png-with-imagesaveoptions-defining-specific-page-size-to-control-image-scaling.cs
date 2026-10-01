// Convert EPUB to PNG with ImageSaveOptions defining a specific page size to control image scaling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();

                // Define page size (800x600 pixels)
                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600)));

                options.PageSetup.AnyPage = page;

                // Set resolution
                options.HorizontalResolution = 150;
                options.VerticalResolution = 150;

                // Optional background color
                options.BackgroundColor = System.Drawing.Color.White;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion to PNG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}