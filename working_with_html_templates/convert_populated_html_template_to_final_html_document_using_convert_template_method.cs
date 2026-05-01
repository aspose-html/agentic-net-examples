// Convert a populated HTML template to a final HTML document using the ConvertTemplate method.

using System;
using Aspose.Html;
using Aspose.Html.Loading;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "template.html";
            string templateDataPath = "data.xml";
            TemplateData templateData = new TemplateData(templateDataPath);
            string resultPath = "output.html";
            TemplateLoadOptions options = new TemplateLoadOptions();
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());
            Converter.ConvertTemplate(document, templateData, options, resultPath);
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}