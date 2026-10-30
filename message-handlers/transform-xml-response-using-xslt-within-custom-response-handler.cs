// Transform XML response using XSLT within a custom response handler.

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;

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

        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(_xsltPath);

        using (StringReader sr = new StringReader(xmlText))
        using (XmlReader xr = XmlReader.Create(sr))
        using (StringWriter sw = new StringWriter())
        {
            xslt.Transform(xr, null, sw);
            string transformed = sw.ToString();
            Console.WriteLine("Transformed Output:");
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
            // Prepare sample XML
            string xmlPath = "sample.xml";
            if (!File.Exists(xmlPath))
            {
                File.WriteAllText(xmlPath, @"<?xml version=""1.0"" encoding=""UTF-8""?>
<catalog>
  <book id=""bk101"">
    <author>Gambardella, Matthew</author>
    <title>XML Developer's Guide</title>
  </book>
</catalog>");
            }

            // Prepare XSLT
            string xsltPath = "transform.xslt";
            if (!File.Exists(xsltPath))
            {
                File.WriteAllText(xsltPath, @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
  <xsl:output method=""html"" encoding=""UTF-8""/>
  <xsl:template match=""/"">
    <html>
      <body>
        <h2>Book Catalog</h2>
        <xsl:for-each select=""catalog/book"">
          <div>
            <strong>Title:</strong> <xsl:value-of select=""title""/><br/>
            <strong>Author:</strong> <xsl:value-of select=""author""/>
          </div>
          <hr/>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>");
            }

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new XsltResponseHandler(xsltPath));

            // Load the XML document (will trigger the custom handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(xmlPath, "about:blank", configuration))
            {
                // Convert to PDF (output file)
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPdf = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);
                Console.WriteLine($"PDF saved to: {outputPdf}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}