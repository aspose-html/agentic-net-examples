// Convert HTML to BMP after applying a custom CSS stylesheet that changes layout before rendering.

public class Program
{
    public static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string cssPath = "style.css";
            string outputPath = "output.bmp";

            // Create sample HTML that references the custom CSS
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"></head><body><div class=\"box\">Hello</div></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            // Create custom CSS that changes layout
            string cssContent = ".box { width: 200px; height: 200px; background-color: red; } body { margin: 0; }";
            System.IO.File.WriteAllText(cssPath, cssContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set up image save options for BMP
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.Beige;

            // Convert HTML to BMP
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}