// Define inline double‑curly‑brace expressions in the template to insert first name values.

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
            string htmlContent = "<html><body><p>Hello {{FirstName}}!</p></body></html>";
            string outputPath = "output.html";
            HTMLDocument document = new HTMLDocument(htmlContent, "");
            string jsonData = "{\"FirstName\":\"John\"}";
            TemplateData data = new TemplateData(jsonData);
            TemplateLoadOptions options = new TemplateLoadOptions();
            Converter.ConvertTemplate(document, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}