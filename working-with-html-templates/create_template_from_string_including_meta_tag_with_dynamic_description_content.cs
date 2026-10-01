// Create a template from a string that includes a meta tag with dynamic description content.

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
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"{{description}}\"></head><body><h1>Hello</h1></body></html>";
            string jsonData = "{\"description\":\"Dynamic description content\"}";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);
            resultDocument.Save(outputPath);

            document.Dispose();
            resultDocument.Dispose();

            Console.WriteLine("Template processed and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}