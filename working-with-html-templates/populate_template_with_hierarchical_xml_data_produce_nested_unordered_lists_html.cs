// Populate a template with hierarchical XML data to produce nested unordered lists in HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "template.html";
            string dataPath = "data.xml";
            string outputPath = "result.html";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><div id=\"content\"></div></body></html>");
            }

            if (!File.Exists(dataPath))
            {
                string xmlContent = "<root><item><title>Item 1</title><subitems><subitem>Sub 1</subitem></subitems></item></root>";
                File.WriteAllText(dataPath, xmlContent);
            }

            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(dataPath);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);
            resultDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}