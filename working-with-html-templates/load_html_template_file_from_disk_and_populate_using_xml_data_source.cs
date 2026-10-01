// Load an HTML template file from disk and populate it using an XML data source.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "template.html";
            string templateDataPath = "data.xml";
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);
            string resultPath = "output.html";
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());
            Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options, resultPath);
            document.Dispose();
            Console.WriteLine("Template conversion completed.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}