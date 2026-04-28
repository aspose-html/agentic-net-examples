// Batch convert a directory of MHTML files to JPG, setting each image resolution to 150 DPI.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;

namespace BatchMhtmlToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output directories (can be passed as arguments)
                string inputDir = args.Length > 0 ? args[0] : "input";
                string outputDir = args.Length > 1 ? args[1] : "output";

                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                // Process each MHTML file in the input directory
                foreach (string filePath in Directory.GetFiles(inputDir, "*.mhtml"))
                {
                    using (FileStream stream = File.OpenRead(filePath))
                    {
                        // Create rendering options and set resolution to 150 DPI
                        ImageRenderingOptions options = new ImageRenderingOptions();
                        options.VerticalResolution = 150;
                        options.HorizontalResolution = 150;

                        // Determine output JPEG file path
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                        // Create an image device with the options and output path
                        ImageDevice device = new ImageDevice(options, outputPath);

                        // Render the MHTML stream to JPEG
                        MhtmlRenderer renderer = new MhtmlRenderer();
                        renderer.Render(device, stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}