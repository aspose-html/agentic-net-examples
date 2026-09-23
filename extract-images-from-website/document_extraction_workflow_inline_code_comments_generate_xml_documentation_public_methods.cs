// Document the extraction workflow with inline code comments and generate XML documentation for public methods.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Net;
using Aspose.Html.Services;

public class Program
{
    /// <summary>
    /// Entry point of the console application.
    /// </summary>
    public static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";
            string logPath = "extraction.log";

            // Ensure a minimal HTML file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><img src='image1.png'/><img src='image2.jpg'/></body></html>");
            }

            // Create configuration and attach custom network message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new MyMessageHandler());

            // Load the HTML document with the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // If any HTTP headers were captured, insert them as a comment node at the top of the document
                if (MyMessageHandler.CapturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", MyMessageHandler.CapturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                // Perform accessibility validation and log the result
                ValidateAccessibility(document, logPath);

                // Extract image sources using XPath and log them
                ExtractImageSources(document, logPath);

                // Save the modified document to the output file
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Validates the accessibility of the provided HTML document and appends the validation result to the log file.
    /// </summary>
    /// <param name="document">The HTML document to validate.</param>
    /// <param name="logPath">The path of the log file where the validation result will be appended.</param>
    public static void ValidateAccessibility(Aspose.Html.HTMLDocument document, string logPath)
    {
        // Create an accessibility validator
        Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

        // Perform validation
        ValidationResult validationResult = validator.Validate(document);

        // Save validation result as XML to a string writer
        using (StringWriter sw = new StringWriter())
        {
            validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
            // Append the XML result to the log file
            File.AppendAllText(logPath, sw.ToString() + Environment.NewLine);
        }
    }

    /// <summary>
    /// Extracts the 'src' attribute of all <img> elements in the document using XPath and logs each source to the specified log file.
    /// </summary>
    /// <param name="document">The HTML document to process.</param>
    /// <param name="logPath">The path of the log file where image sources will be recorded.</param>
    public static void ExtractImageSources(Aspose.Html.HTMLDocument document, string logPath)
    {
        // Evaluate XPath to select all image elements
        IXPathResult result = document.Evaluate("//img", document, document.CreateNSResolver(document), XPathResultType.Any, null);

        // Iterate over the result set
        Node node;
        while ((node = result.IterateNext()) != null)
        {
            // Cast the node to HTMLImageElement to access the Src property
            Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
            // Append the image source to the log file
            File.AppendAllText(logPath, img.Src + Environment.NewLine);
        }
    }
}

/// <summary>
/// Custom network message handler that captures response headers for later inspection.
/// </summary>
public class MyMessageHandler : Aspose.Html.Net.MessageHandler
{
    /// <summary>
    /// List that stores captured header strings.
    /// </summary>
    public static List<string> CapturedHeaders = new List<string>();

    /// <summary>
    /// Invoked for each network operation; captures response headers after the operation proceeds.
    /// </summary>
    /// <param name="context">The network operation context.</param>
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue with the next handler in the pipeline
        Next(context);

        // Capture all response headers
        foreach (object headerItem in context.Response.Headers)
        {
            if (headerItem != null)
            {
                CapturedHeaders.Add(headerItem.ToString());
            }
        }
    }
}