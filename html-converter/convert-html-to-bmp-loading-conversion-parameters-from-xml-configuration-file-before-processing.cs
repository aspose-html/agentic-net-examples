// Convert HTML to BMP by loading conversion parameters from an XML configuration file before processing.

using System;
using System.IO;
using System.Xml.Linq;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.html";
            string outputPath = "output.bmp";
            string configPath = "config.xml";

            // Ensure sample HTML exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Ensure configuration XML exists
            if (!File.Exists(configPath))
            {
                var defaultConfig = new XDocument(
                    new XElement("ConversionSettings",
                        new XElement("UseAntialiasing", "false"),
                        new XElement("HorizontalResolution", "96"),
                        new XElement("VerticalResolution", "96"),
                        new XElement("BackgroundColor", "Beige")
                    )
                );
                defaultConfig.Save(configPath);
            }

            // Load conversion parameters from XML
            XDocument configDoc = XDocument.Load(configPath);
            XElement root = configDoc.Element("ConversionSettings");

            bool useAntialiasing = bool.Parse(root.Element("UseAntialiasing")?.Value ?? "false");
            int horizontalResolution = int.Parse(root.Element("HorizontalResolution")?.Value ?? "96");
            int verticalResolution = int.Parse(root.Element("VerticalResolution")?.Value ?? "96");
            string bgColorName = root.Element("BackgroundColor")?.Value ?? "Transparent";
            Color backgroundColor = Color.FromName(bgColorName);

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Set up image save options for BMP
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = useAntialiasing;
            options.HorizontalResolution = horizontalResolution;
            options.VerticalResolution = verticalResolution;
            options.BackgroundColor = backgroundColor;

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}