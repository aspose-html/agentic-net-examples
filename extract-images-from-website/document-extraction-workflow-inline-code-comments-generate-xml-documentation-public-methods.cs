// Document the extraction workflow with inline code comments and generate XML documentation for public methods.

using System;

namespace AsposeHtmlExtractionExample
{
    /// <summary>
    /// Provides methods to extract image sources from HTML content and validate accessibility.
    /// </summary>
    public static class HTMLProcessor
    {
        /// <summary>
        /// Extracts all image URLs from the specified HTML content, validates the document for accessibility,
        /// logs the validation report and image sources, and saves the processed document to a file.
        /// </summary>
        /// <param name="htmlContent">The HTML markup to process.</param>
        /// <param name="logPath">The file path where the log will be written.</param>
        /// <param name="outputPath">The file path where the processed HTML document will be saved.</param>
        public static void PerformExtraction(string htmlContent, string logPath, string outputPath)
        {
            // Ensure the log file starts empty.
            System.IO.File.WriteAllText(logPath, string.Empty + System.Environment.NewLine);

            // Load the HTML content using the two‑argument constructor (content, baseUri).
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // -----------------------------------------------------------------
                // Accessibility validation
                // -----------------------------------------------------------------
                // Create a validator via the WebAccessibility factory.
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

                // Validate the document and obtain the result.
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Serialize the validation result to XML and append it to the log.
                using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
                {
                    validationResult.SaveTo(stringWriter, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    System.IO.File.AppendAllText(logPath, stringWriter.ToString() + System.Environment.NewLine);
                }

                // -----------------------------------------------------------------
                // XPath extraction of <img> elements
                // -----------------------------------------------------------------
                // Evaluate an XPath expression that selects all img elements.
                Aspose.Html.Dom.XPath.IXPathResult xpathResult = document.Evaluate(
                    "//img",
                    document,
                    document.CreateNSResolver(document),
                    Aspose.Html.Dom.XPath.XPathResultType.Any,
                    null);

                // Iterate over the result set and log each image's src attribute.
                Aspose.Html.Dom.Node node;
                while ((node = xpathResult.IterateNext()) != null)
                {
                    Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                    System.IO.File.AppendAllText(logPath, img.Src + System.Environment.NewLine);
                }

                // -----------------------------------------------------------------
                // Save the (potentially modified) document to the specified output path.
                // -----------------------------------------------------------------
                document.Save(outputPath);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample HTML containing two images.
                string sampleHtml = "<html><body><img src='image1.png'/><img src='image2.jpg'/></body></html>";

                // Define deterministic file paths for log and output.
                string logFilePath = "extraction_log.txt";
                string outputFilePath = "processed_document.html";

                // Perform the extraction workflow.
                HTMLProcessor.PerformExtraction(sampleHtml, logFilePath, outputFilePath);

                System.Console.WriteLine("Extraction completed successfully.");
                System.Console.WriteLine("Log written to: " + logFilePath);
                System.Console.WriteLine("Processed HTML saved to: " + outputFilePath);
            }
            catch (System.Exception ex)
            {
                // Print a clear error message if something goes wrong.
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}