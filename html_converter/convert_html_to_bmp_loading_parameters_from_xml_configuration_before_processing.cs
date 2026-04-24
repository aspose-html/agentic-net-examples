// Convert HTML to BMP by loading conversion parameters from an XML configuration file before processing.

using System;
using System.Xml;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace HtmlToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                XmlDocument config = new XmlDocument();
                config.Load("config.xml");
                string inputPath = config.SelectSingleNode("//InputPath")?.InnerText;
                string outputPath = config.SelectSingleNode("//OutputPath")?.InnerText;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}