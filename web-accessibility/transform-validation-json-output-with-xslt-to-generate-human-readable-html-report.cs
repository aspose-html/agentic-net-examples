// Transform validation JSON output using XSLT to generate a human‑readable HTML report.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string jsonPath = "validation.json";
            string xsltPath = "report.xslt";
            string outputPath = "report.html";

            // Create sample JSON file
            System.IO.File.WriteAllText(jsonPath, "{\"validationResult\":\"Success\",\"issues\":[]}");

            // Create simple XSLT template that reads JSON and produces HTML
            string xsltContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:json=""http://json.org/"">
  <xsl:output method=""html"" encoding=""UTF-8""/>
  <xsl:template match=""/"">
    <html>
      <head><title>Validation Report</title></head>
      <body>
        <h1>Validation Result: <xsl:value-of select=""json:validationResult""/></h1>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>";
            System.IO.File.WriteAllText(xsltPath, xsltContent);

            // Load JSON data as template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert using the XSLT template
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(xsltPath, templateData, loadOptions);

            // Save the resulting HTML report
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}