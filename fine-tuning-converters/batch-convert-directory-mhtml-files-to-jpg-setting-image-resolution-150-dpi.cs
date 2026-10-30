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
            string inputDirectory = "InputMhtml";
            string outputDirectory = "OutputJpg";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            foreach (string mhtmlPath in Directory.GetFiles(inputDirectory, "*.mhtml"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(mhtmlPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;
                    options.BackgroundColor = System.Drawing.Color.Beige;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromPixels(800),
                            Aspose.Html.Drawing.Length.FromPixels(600)));

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine($"Converted '{mhtmlPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}