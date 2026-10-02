// Use a single line of code to convert a template string directly to an HTML file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello {{name}}</h1></body></html>";
            string jsonData = "{\"name\":\"World\"}";
            string outputPath = "output.html";

            Aspose.Html.Converters.Converter.ConvertTemplate(
                new Aspose.Html.HTMLDocument(htmlContent, ""),
                new Aspose.Html.Converters.TemplateData(jsonData),
                new Aspose.Html.Loading.TemplateLoadOptions()
            ).Save(outputPath);

            System.Console.WriteLine("HTML file saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}