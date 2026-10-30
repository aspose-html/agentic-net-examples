// Convert an EPUB file to JPEG using the static Converter.ConvertEPUB method with default settings.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data";
            string inputFile = System.IO.Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);

            if (!System.IO.File.Exists(inputFile))
            {
                System.IO.File.WriteAllBytes(inputFile, new byte[0]);
            }

            string outputPath = System.IO.Path.Combine(outputDir, "output.jpg");

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputFile))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}