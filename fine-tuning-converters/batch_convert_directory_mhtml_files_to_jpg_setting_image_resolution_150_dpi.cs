// Batch convert a directory of MHTML files to JPG, setting each image resolution to 150 DPI.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "MhtmlFiles";
            string outputDir = "JpgOutput";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample MHTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputDir, "*.mhtml");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.mhtml");
                File.WriteAllText(samplePath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            string[] mhtmlFiles = Directory.GetFiles(inputDir, "*.mhtml");
            foreach (string mhtmlPath in mhtmlFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(mhtmlPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                using (Stream stream = File.OpenRead(mhtmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;
                    options.BackgroundColor = System.Drawing.Color.Beige;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromPixels(800),
                            Aspose.Html.Drawing.Length.FromPixels(600))
                    };

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine($"Converted '{mhtmlPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}