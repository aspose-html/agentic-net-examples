// Render an MHTML file to PNG, ensuring embedded CSS styles are applied correctly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Create a minimal MHTML file with embedded CSS if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string mhtmlContent = "<!DOCTYPE html><html><head><style>body{background-color:lightblue;}</style></head><body><h1>Hello, World!</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, mhtmlContent);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully rendered to PNG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}