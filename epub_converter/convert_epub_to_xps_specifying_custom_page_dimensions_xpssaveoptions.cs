// Convert an EPUB file to XPS while specifying custom page dimensions via XpsSaveOptions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.xps";

            using (Stream stream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromPixels(500),
                        Length.FromPixels(500)
                    )
                );
                options.BackgroundColor = System.Drawing.Color.LightGray;

                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}