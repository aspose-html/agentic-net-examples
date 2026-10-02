// Write a helper that converts MHTML to multiple image formats in a single pass using parallel tasks.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mht";
            string outputDir = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Define conversion tasks for different image formats
            Task[] tasks = new Task[]
            {
                Task.Run(() =>
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.UseAntialiasing = true;
                        string outPath = Path.Combine(outputDir, "output.jpeg");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                }),
                Task.Run(() =>
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                        options.UseAntialiasing = true;
                        string outPath = Path.Combine(outputDir, "output.png");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                }),
                Task.Run(() =>
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                        options.UseAntialiasing = true;
                        string outPath = Path.Combine(outputDir, "output.tiff");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                }),
                Task.Run(() =>
                {
                    using (Stream stream = File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                        options.UseAntialiasing = true;
                        string outPath = Path.Combine(outputDir, "output.bmp");
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outPath);
                    }
                })
            };

            // Wait for all conversions to complete
            Task.WaitAll(tasks);

            Console.WriteLine("MHTML conversion to multiple image formats completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}