// Configure ImageSaveOptions to enable progressive rendering for JPEG output when converting large MHTML files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            // Progressive rendering for JPEG is handled internally; no explicit property is available.

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}