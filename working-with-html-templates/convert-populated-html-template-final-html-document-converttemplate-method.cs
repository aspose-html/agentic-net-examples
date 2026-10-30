// Convert a populated HTML template to a final HTML document using the ConvertTemplate method.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "template.html";
            string templateDataPath = "data.json";
            string resultPath = "output.html";

            if (!System.IO.File.Exists(sourcePath))
            {
                string templateContent = "<html><head><title>{{title}}</title></head><body><h1>{{header}}</h1></body></html>";
                System.IO.File.WriteAllText(sourcePath, templateContent);
            }

            if (!System.IO.File.Exists(templateDataPath))
            {
                string jsonContent = "{\"title\":\"Sample Title\",\"header\":\"Hello World\"}";
                System.IO.File.WriteAllText(templateDataPath, jsonContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);
            resultDoc.Save(resultPath);

            document.Dispose();
            resultDoc.Dispose();

            System.Console.WriteLine("Template conversion completed. Output saved to: " + resultPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}