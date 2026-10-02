// Use TemplateData to bind a list of products from JSON and generate a repeating product card layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<html><body><div data-repeat='products'><h2>{{name}}</h2><p>{{price}}</p></div></body></html>";
            string jsonData = "{\"products\":[{\"name\":\"Product 1\",\"price\":\"$10\"},{\"name\":\"Product 2\",\"price\":\"$20\"}]}";

            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(htmlTemplate, data, loadOptions);

            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Template conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}