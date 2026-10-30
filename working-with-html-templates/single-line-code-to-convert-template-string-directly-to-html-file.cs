// Use a single line of code to convert a template string directly to an HTML file.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello {{name}}</h1></body></html>";
            string outputPath = "output.html";
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"name\":\"World\"}");
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.Converters.Converter.ConvertTemplate(new Aspose.Html.HTMLDocument(htmlContent, ""), data, options).Save(outputPath);
            System.Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}