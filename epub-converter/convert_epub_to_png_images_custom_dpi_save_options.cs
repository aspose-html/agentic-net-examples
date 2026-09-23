// Convert an EPUB file to PNG images with a custom DPI setting via appropriate save options.

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);
            string epubPath = System.IO.Path.Combine(dataDir, "sample.epub");
            if (!System.IO.File.Exists(epubPath))
            {
                System.IO.File.WriteAllBytes(epubPath, new byte[0]);
            }
            using (System.IO.FileStream stream = System.IO.File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputDir);
            }
            System.Console.WriteLine("EPUB conversion completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}