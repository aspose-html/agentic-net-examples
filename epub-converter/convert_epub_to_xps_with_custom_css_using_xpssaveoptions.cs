// Convert an EPUB file to XPS and embed custom CSS during conversion using XpsSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string cssPath = "custom.css";
            string outputPath = "output.xps";

            // Create minimal placeholder files if they do not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllBytes(sourcePath, new byte[0]);
            }
            if (!System.IO.File.Exists(cssPath))
            {
                System.IO.File.WriteAllText(cssPath, "body { font-family: Arial; }");
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                string cssContent = System.IO.File.ReadAllText(cssPath);
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = cssContent;

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}