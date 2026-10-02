// Transform validation JSON output using XSLT to generate a human‑readable HTML report.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string jsonPath = "validation.json";
            string xsltPath = "report.xslt";
            string outputPath = "report.html";

            // Create sample JSON if it does not exist
            if (!File.Exists(jsonPath))
            {
                string sampleJson = @"{
  ""validationResult"": {
    ""status"": ""Failed"",
    ""issues"": [
      { ""type"": ""Error"", ""message"": ""Missing alt attribute on img tag."" },
      { ""type"": ""Warning"", ""message"": ""Low contrast text."" }
    ]
  }
}";
                File.WriteAllText(jsonPath, sampleJson);
            }

            // Create sample XSLT if it does not exist
            if (!File.Exists(xsltPath))
            {
                string sampleXslt = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
  <xsl:output method=""html"" indent=""yes""/>
  <xsl:template match=""/"">
    <html>
      <head>
        <title>Validation Report</title>
        <style>
          body { font-family: Arial, sans-serif; margin: 20px; }
          .error { color: red; }
          .warning { color: orange; }
        </style>
      </head>
      <body>
        <h1>Validation Report</h1>
        <p>Status: <xsl:value-of select=""validationResult/status""/></p>
        <h2>Issues</h2>
        <ul>
          <xsl:for-each select=""validationResult/issues/issue"">
            <li class=""{translate(type, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')}"">
              <strong><xsl:value-of select=""type""/></strong>: <xsl:value-of select=""message""/>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>";
                File.WriteAllText(xsltPath, sampleXslt);
            }

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert JSON using XSLT to HTML
            Aspose.Html.Converters.Converter.ConvertTemplate(xsltPath, templateData, loadOptions, outputPath);

            Console.WriteLine("HTML report generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}