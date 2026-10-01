// Convert HTML to GIF, read the generated image into a byte array, and output the byte array size for verification.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string inputHtmlPath = System.IO.Path.Combine(currentDir, "sample.html");
            string outputGifPath = System.IO.Path.Combine(currentDir, "output.gif");

            if (!System.IO.File.Exists(inputHtmlPath))
            {
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                System.IO.File.WriteAllText(inputHtmlPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputGifPath);

            byte[] imageBytes = System.IO.File.ReadAllBytes(outputGifPath);
            System.Console.WriteLine("Generated GIF byte array size: " + imageBytes.Length);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}