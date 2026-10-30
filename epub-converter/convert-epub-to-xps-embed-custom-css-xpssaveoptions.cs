// Convert an EPUB file to XPS and embed custom CSS during conversion using XpsSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "output.xps";
            string cssPath = "custom.css";

            // Create minimal sample files if they do not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllBytes(sourcePath, new byte[0]);
            }
            if (!System.IO.File.Exists(cssPath))
            {
                System.IO.File.WriteAllText(cssPath, "body { font-family: Arial; }");
            }

            System.IO.Stream epubStream = System.IO.File.OpenRead(sourcePath);
            string cssContent = System.IO.File.ReadAllText(cssPath);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContent;

            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, configuration, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}