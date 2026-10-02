// Create a template from a string that includes a meta tag with dynamic description content.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"{{description}}\"></head><body><h1>Hello</h1></body></html>";
            string jsonData = "{\"description\":\"Dynamic description from template\"}";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);
            result.Save(outputPath);

            result.Dispose();
            document.Dispose();

            Console.WriteLine("Template conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}