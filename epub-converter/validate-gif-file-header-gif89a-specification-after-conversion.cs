// Validate that the GIF file header conforms to the GIF89a specification after conversion.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, GIF!</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                string outputPath = "output.gif";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                byte[] bytes = System.IO.File.ReadAllBytes(outputPath);
                if (bytes.Length >= 6)
                {
                    string header = System.Text.Encoding.ASCII.GetString(bytes, 0, 6);
                    if (header == "GIF89a")
                    {
                        System.Console.WriteLine("Valid GIF89a header.");
                    }
                    else
                    {
                        System.Console.WriteLine($"Invalid GIF header: {header}");
                    }
                }
                else
                {
                    System.Console.WriteLine("File too small to be a valid GIF.");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}