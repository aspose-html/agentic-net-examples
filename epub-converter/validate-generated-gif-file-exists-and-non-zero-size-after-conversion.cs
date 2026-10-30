// Validate that the generated GIF file exists and has a non-zero file size after conversion.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, GIF!</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            if (System.IO.File.Exists(outputPath))
            {
                long size = new System.IO.FileInfo(outputPath).Length;
                if (size > 0)
                {
                    System.Console.WriteLine($"GIF conversion succeeded, file size: {size} bytes.");
                }
                else
                {
                    System.Console.WriteLine("GIF conversion failed: file size is zero.");
                }
            }
            else
            {
                System.Console.WriteLine("GIF conversion failed: file not found.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}