// Document the extraction workflow with inline code comments and generate XML documentation for public methods.

using System;
using System.IO;
using System.Collections.Generic;

namespace AsposeHtmlExample
{
    /// <summary>
    /// Demonstrates accessibility validation, XPath extraction, and network header capture using Aspose.HTML for .NET.
    /// </summary>
    class Program
    {
        static void Main()
        {
            const string inputHtmlPath = "sample.html";
            const string outputHtmlPath = "output.html";
            const string logPath = "log.txt";

            try
            {
                // Prepare a minimal HTML file.
                if (!File.Exists(inputHtmlPath))
                {
                    string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Test Document</h1>
    <img src='image1.png' alt='Image 1' />
    <img src='image2.jpg' alt='Image 2' />
</body>
</html>";
                    File.WriteAllText(inputHtmlPath, sampleHtml);
                }

                // Clear previous log.
                if (File.Exists(logPath))
                {
                    File.Delete(logPath);
                }

                ValidateDocument(inputHtmlPath, logPath);
                ExtractImageSources(inputHtmlPath, logPath);
                ProcessDocumentWithNetworkHandler(inputHtmlPath, outputHtmlPath, logPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Performs accessibility validation on the specified HTML document and logs the result in XML format.
        /// </summary>
        /// <param name="htmlPath">Path to the HTML file to validate.</param>
        /// <param name="logPath">Path to the log file where validation output will be appended.</param>
        public static void ValidateDocument(string htmlPath, string logPath)
        {
            // Load the document.
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Create the validator.
                Aspose.Html.Accessibility.AccessibilityValidator validator =
                    new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

                // Run validation.
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Save validation result as XML to a string.
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    File.AppendAllText(logPath, sw.ToString() + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Extracts the src attribute of all &lt;img&gt; elements using XPath and logs each value.
        /// </summary>
        /// <param name="htmlPath">Path to the HTML file to process.</param>
        /// <param name="logPath">Path to the log file where image sources will be appended.</param>
        public static void ExtractImageSources(string htmlPath, string logPath)
        {
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Evaluate XPath to select all img elements.
                Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                    "//img",
                    doc,
                    doc.CreateNSResolver(doc),
                    Aspose.Html.Dom.XPath.XPathResultType.Any,
                    null);

                Aspose.Html.Dom.Node node;
                while ((node = result.IterateNext()) != null)
                {
                    Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                    File.AppendAllText(logPath, img.Src + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Loads the HTML document with a custom network message handler that captures response headers,
        /// inserts them as a comment node at the top of the document, and saves the modified document.
        /// </summary>
        /// <param name="htmlPath">Path to the HTML file to load.</param>
        /// <param name="outputPath">Path where the processed HTML document will be saved.</param>
        /// <param name="logPath">Path to the log file where captured headers will be appended.</param>
        public static void ProcessDocumentWithNetworkHandler(string htmlPath, string outputPath, string logPath)
        {
            // Configure Aspose.HTML with a custom network service.
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new NetworkMessageHandler());

            // Load the document using the custom configuration.
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // If any headers were captured, insert them as a comment node.
                if (NetworkMessageHandler.CapturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", NetworkMessageHandler.CapturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                // Save the modified document.
                document.Save(outputPath);
            }

            // Log captured headers.
            if (NetworkMessageHandler.CapturedHeaders.Count > 0)
            {
                File.AppendAllText(logPath, "Captured Headers:" + Environment.NewLine);
                foreach (string header in NetworkMessageHandler.CapturedHeaders)
                {
                    File.AppendAllText(logPath, header + Environment.NewLine);
                }
            }
        }
    }

    /// <summary>
    /// Custom message handler that records all response headers from network operations.
    /// </summary>
    class NetworkMessageHandler : Aspose.Html.Net.MessageHandler
    {
        public static List<string> CapturedHeaders = new List<string>();

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            // Continue the request pipeline.
            Next(context);

            // Capture response headers.
            foreach (object headerItem in context.Response.Headers)
            {
                if (headerItem != null)
                {
                    CapturedHeaders.Add(headerItem.ToString());
                }
            }
        }
    }
}