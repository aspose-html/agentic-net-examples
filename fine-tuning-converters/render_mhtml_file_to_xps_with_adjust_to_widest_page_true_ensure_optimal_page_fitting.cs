// Render an MHTML file to XPS with AdjustToWidestPage true to ensure optimal page fitting.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(inputPath, minimalHtml);
            }

            // Open the MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure XPS save options
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.3f),
                        Aspose.Html.Drawing.Length.FromInches(5.8f)
                    )
                );
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Convert MHTML to XPS
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}