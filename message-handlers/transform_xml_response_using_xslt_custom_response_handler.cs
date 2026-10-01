// Transform XML response using XSLT within a custom response handler.

using System;
using System.IO;

class XsltResponseHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _xsltPath;
    public XsltResponseHandler(string xsltPath)
    {
        _xsltPath = xsltPath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;

        string xmlText = context.Response.Content.ReadAsString();
        System.Xml.Xsl.XslCompiledTransform xslt = new System.Xml.Xsl.XslCompiledTransform();
        xslt.Load(_xsltPath);
        using (StringReader sr = new StringReader(xmlText))
        using (System.Xml.XmlReader xr = System.Xml.XmlReader.Create(sr))
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
            // Create sample XML file
            string xmlPath = "sample.xml";
            string xmlContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<greeting>
    <text>Hello, World!</text>
</greeting>";
            File.WriteAllText(xmlPath, xmlContent);

            // Create sample XSLT file
            string xsltPath = "transform.xslt";
            string xsltContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
  <xsl:output method=""text""/>
  <xsl:template match=""/"">
    <xsl:value-of select=""greeting/text""/>
  </xsl:template>
</xsl:stylesheet>";
            File.WriteAllText(xsltPath, xsltContent);

            // Configure Aspose.HTML and add the custom handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new XsltResponseHandler(xsltPath));

            // Load the XML document (triggers the handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(xmlPath, configuration))
            {
                // Convert to PDF just to complete the pipeline (optional)
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