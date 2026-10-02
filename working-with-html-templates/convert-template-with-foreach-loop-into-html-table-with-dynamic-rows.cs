// Convert a template that contains a foreach loop into an HTML table with dynamic rows.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string templateHtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><table border=\"1\"><tr><th>Name</th></tr>{% foreach var item in items %}<tr><td>{{item.Name}}</td></tr>{% end %}</table></body></html>";
            Aspose.Html.HTMLDocument templateDoc = new Aspose.Html.HTMLDocument(templateHtml, "about:blank");
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"items\":[{\"Name\":\"John\"},{\"Name\":\"Jane\"},{\"Name\":\"Bob\"}]}");
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templateDoc, data, options);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.html");
            resultDoc.Save(outputPath);
            Console.WriteLine("HTML generated and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}