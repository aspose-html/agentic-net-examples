// Convert an EPUB file to XPS while specifying custom page dimensions via XpsSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "sample.xps";

            if (!File.Exists(inputPath))
            {
                // Create a placeholder EPUB file if it does not exist
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600)
                    )
                );
                options.BackgroundColor = Color.LightGray;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}