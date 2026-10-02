// Embed fonts in XPS output by configuring XpsSaveOptions for accurate text rendering from HTML.

class Program
{
    static void Main()
    {
        try
        {
            // Define base directory
            string baseDir = System.IO.Path.GetFullPath(".");

            // Create a folder for custom fonts (populate with .ttf files as needed)
            string fontsFolder = System.IO.Path.Combine(baseDir, "fonts");
            if (!System.IO.Directory.Exists(fontsFolder))
            {
                System.IO.Directory.CreateDirectory(fontsFolder);
                // Place required font files into this folder for embedding.
            }

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Sample HTML that references a custom font
            string htmlContent = "<!DOCTYPE html><html><head><style>@font-face {font-family: 'CustomFont'; src: url('CustomFont.ttf'); } body {font-family: 'CustomFont', sans-serif;}</style></head><body><p>Hello, world with custom font!</p></body></html>";

            // Write HTML to a temporary file
            string htmlPath = System.IO.Path.Combine(baseDir, "sample.html");
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set XPS save options (fonts will be embedded automatically based on the configuration)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output XPS file path
            string outputPath = System.IO.Path.Combine(baseDir, "output.xps");

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("XPS file saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}