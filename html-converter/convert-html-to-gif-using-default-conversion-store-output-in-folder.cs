// Convert an HTML file to a GIF image using default conversion and store the output in a folder.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputFolder = "output";
            System.IO.Directory.CreateDirectory(outputFolder);
            if (!System.IO.File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose!</h1></body></html>";
                System.IO.File.WriteAllText(inputHtmlPath, sampleHtml);
            }
            string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(inputHtmlPath) + ".gif");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}