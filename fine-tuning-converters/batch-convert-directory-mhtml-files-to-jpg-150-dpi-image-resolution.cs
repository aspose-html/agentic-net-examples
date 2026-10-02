// Batch convert a directory of MHTML files to JPG, setting each image resolution to 150 DPI.

using System;
using System.IO;
using System.Drawing;

namespace BatchMhtmlToJpg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDir = "InputMhtml";
                string outputDir = "OutputJpg";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);
                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                // Create a minimal sample MHTML file if none exist
                if (Directory.GetFiles(inputDir, "*.mhtml").Length == 0)
                {
                    string samplePath = Path.Combine(inputDir, "sample.mhtml");
                    File.WriteAllText(samplePath, "<!-- Sample MHTML content placeholder -->");
                }

                foreach (string filePath in Directory.GetFiles(inputDir, "*.mhtml"))
                {
                    using (Stream stream = File.OpenRead(filePath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.HorizontalResolution = 150;
                        options.VerticalResolution = 150;
                        options.BackgroundColor = Color.Beige;
                        options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page()
                        {
                            Size = new Aspose.Html.Drawing.Size(
                                Aspose.Html.Drawing.Length.FromPixels(800),
                                Aspose.Html.Drawing.Length.FromPixels(600))
                        };

                        string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    }
                }

                Console.WriteLine("Batch conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}