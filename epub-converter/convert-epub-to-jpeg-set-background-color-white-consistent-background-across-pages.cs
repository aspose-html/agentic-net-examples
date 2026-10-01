// Convert EPUB to JPEG and set ImageSaveOptions.BackgroundColor to white for consistent background across pages.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.jpg";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.BackgroundColor = System.Drawing.Color.White;
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}