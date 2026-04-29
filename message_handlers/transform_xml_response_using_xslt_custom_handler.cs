// Transform XML response using XSLT within a custom response handler.

using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class XsltTransformHandler : MessageHandler
{
    private readonly string _xsltPath;
    public XsltTransformHandler(string xsltPath)
    {
        _xsltPath = xsltPath;
    }

    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request/response pipeline
        Next(context);

        // If there is no content, nothing to transform
        if (context.Response.Content == null)
            return;

        // Read the XML response as a string
        string xmlText = context.Response.Content.ReadAsString();

        // Load the XSLT stylesheet
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(_xsltPath);

        // Apply the transformation
        using (StringReader sr = new StringReader(xmlText))
        using (XmlReader xr = XmlReader.Create(sr))
        using (StringWriter sw = new StringWriter())
        {
            xslt.Transform(xr, null, sw);
            string transformed = sw.ToString();

            // Output the transformed XML (could be logged or further processed)
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
            // Create Aspose.HTML configuration
            Configuration configuration = new Configuration();

            // Obtain the network service to register custom handlers
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Register the XSLT transformation handler (provide path to your XSLT file)
            network.MessageHandlers.Add(new XsltTransformHandler("transform.xslt"));

            // Load an HTML document using the configured network service
            using (HTMLDocument document = new HTMLDocument("https://example.com", "https://example.com", configuration))
            {
                // Set PDF conversion options (default options used here)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF
                Converter.ConvertHTML(document, options, "output.pdf");
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}