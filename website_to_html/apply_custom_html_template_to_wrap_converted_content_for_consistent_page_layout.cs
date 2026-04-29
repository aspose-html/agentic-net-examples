// Apply a custom HTML template to wrap converted content for a consistent page layout.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string templateDataPath = "data.xml";
            TemplateData templateData = new TemplateData(templateDataPath);
            string resultPath = "output.html";
            TemplateLoadOptions options = new TemplateLoadOptions();
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());
            Converter.ConvertTemplate(document, templateData, options, resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}