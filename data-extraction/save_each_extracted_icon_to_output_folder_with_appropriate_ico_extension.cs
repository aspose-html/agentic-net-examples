// Save each extracted icon to the output folder with appropriate .ico extension.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output folder
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // Sample icon image files (create empty placeholder files for demonstration)
            string[] iconFiles = { "icon1.png", "icon2.png" };
            foreach (string iconFile in iconFiles)
            {
                if (!File.Exists(iconFile))
                {
                    // Create a minimal PNG file (1x1 pixel) if it does not exist
                    byte[] pngHeader = new byte[]
                    {
                        0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A, // PNG signature
                        0x00,0x00,0x00,0x0D,0x49,0x48,0x44,0x52, // IHDR chunk
                        0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01, // width=1, height=1
                        0x08,0x02,0x00,0x00,0x00,0x90,0x77,0x53,0xDE,
                        0x00,0x00,0x00,0x0A,0x49,0x44,0x41,0x54,
                        0x08,0xD7,0x63,0x60,0x00,0x00,0x00,0x02,
                        0x00,0x01,0xE2,0x26,0x05,0x9B,0x00,0x00,
                        0x00,0x00,0x49,0x45,0x4E,0x44,0xAE,0x42,
                        0x60,0x82
                    };
                    File.WriteAllBytes(iconFile, pngHeader);
                }
            }

            // Process each icon file
            foreach (string iconFile in iconFiles)
            {
                // Create simple HTML that references the icon image
                string htmlContent = $"<html><body><img src=\"{iconFile}\"/></body></html>";
                string htmlPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");
                File.WriteAllText(htmlPath, htmlContent);

                // Configure Aspose.Html (optional fonts lookup)
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgentService.FontsSettings.SetFontsLookupFolder(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);

                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

                // Set image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

                // Define output .ico path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(iconFile) + ".ico");

                // Convert HTML to .ico image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                // Clean up temporary HTML file
                File.Delete(htmlPath);
            }

            Console.WriteLine("Icons have been extracted and saved to the output folder.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}