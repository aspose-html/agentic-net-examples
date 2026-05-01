// Create a reusable HTML email template and populate it with user data from an XML file.

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
            Console.WriteLine(ex.Message);
        }
    }
}