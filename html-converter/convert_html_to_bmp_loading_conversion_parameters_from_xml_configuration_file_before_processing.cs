// Convert HTML to BMP by loading conversion parameters from an XML configuration file before processing.

using System;
using System.IO;
using System.Xml.Linq;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.bmp";
            string configPath = "config.xml";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            if (!File.Exists(configPath))
            {
                var defaultConfig = new XDocument(
                    new XElement("ConversionOptions",
                        new XElement("UseAntialiasing", "false"),
                        new XElement("HorizontalResolution", "96"),
                        new XElement("VerticalResolution", "96"),
                        new XElement("BackgroundColor", "Beige")
                    )
                );
                defaultConfig.Save(configPath);
            }

            XDocument configDoc = XDocument.Load(configPath);
            XElement root = configDoc.Element("ConversionOptions");
            bool useAntialiasing = bool.Parse(root.Element("UseAntialiasing")?.Value ?? "false");
            int hRes = int.Parse(root.Element("HorizontalResolution")?.Value ?? "96");
            int vRes = int.Parse(root.Element("VerticalResolution")?.Value ?? "96");
            string bgColorName = root.Element("BackgroundColor")?.Value ?? "White";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = useAntialiasing;
            options.HorizontalResolution = hRes;
            options.VerticalResolution = vRes;
            options.BackgroundColor = Color.FromName(bgColorName);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}