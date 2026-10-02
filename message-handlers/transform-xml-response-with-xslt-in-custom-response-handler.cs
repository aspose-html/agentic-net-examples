// Transform XML response using XSLT within a custom response handler.

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomResponseHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _xsltPath;
    public CustomResponseHandler(string xsltPath)
    {
        _xsltPath = xsltPath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;

        string xmlText = context.Response.Content.ReadAsString();
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(_xsltPath);

        using (StringReader sr = new StringReader(xmlText))
        using (XmlReader xr = XmlReader.Create(sr))
        using (StringWriter sw = new StringWriter())
        {
            xslt.Transform(xr, null, sw);
            string transformed = sw.ToString();
            Console.WriteLine(transformed);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string xsltPath = "sample.xslt";
            string xmlPath = "sample.xml";

            // Create a simple XSLT that transforms XML to HTML
            File.WriteAllText(xsltPath,
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
  <xsl:output method=""html"" encoding=""UTF-8""/>
  <xsl:template match=""/"">
    <html><body>
      <h1>Transformed Content</h1>
      <p><xsl:value-of select=""/root/message""/></p>
    </body></html>
  </xsl:template>
</xsl:stylesheet>");

            // Create a simple XML file
            File.WriteAllText(xmlPath,
@"<?xml version=""1.0"" encoding=""UTF-8""?>
<root>
  <message>Hello from XML!</message>
</root>");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomResponseHandler(xsltPath));

            // Load an HTML document that references the XML file
            string htmlContent = $"<html><body><iframe src=\"{xmlPath}\"></iframe></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                // No further actions needed; the handler will output the transformed result.
                // Optionally, convert the document to PDF to demonstrate full pipeline.
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}