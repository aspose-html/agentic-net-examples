// Add error handling for missing src attributes and log warnings without interrupting workflow.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an <img> missing the src attribute
            string htmlContent = "<html><body><img alt='no src'><img src='image.png'></body></html>";
            string baseUri = "about:blank";

            // Load the document using the two‑argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Log file path
            string logPath = "validation_warnings.log";
            File.WriteAllText(logPath, "Validation warnings:" + Environment.NewLine);

            // -----------------------------------------------------------------
            // Detect <img> elements without a src attribute using XPath
            // -----------------------------------------------------------------
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = doc.Evaluate(
                "//img[not(@src)]",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            Aspose.Html.Dom.Node node;
            while ((node = xpathResult.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string warning = $"Warning: <img> element missing src attribute. OuterHTML: {img.OuterHTML}";
                    File.AppendAllText(logPath, warning + Environment.NewLine);
                }
            }

            // -----------------------------------------------------------------
            // Run the accessibility validator (optional – logs all rule results)
            // -----------------------------------------------------------------
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(doc);

            foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
            {
                // Log each validation detail using its default string representation
                File.AppendAllText(logPath, detail.ToString() + Environment.NewLine);
            }

            Console.WriteLine("Validation completed. See log at " + Path.GetFullPath(logPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}