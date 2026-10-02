// Define inline double‑curly‑brace expressions in the template to insert first name values.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello, {{FirstName}}!</p></body></html>";
            string outputPath = "output.html";
            string jsonData = "{\"FirstName\":\"John\"}";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "");
            var data = new Aspose.Html.Converters.TemplateData(jsonData);
            var options = new Aspose.Html.Loading.TemplateLoadOptions();

            var resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);
            resultDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}