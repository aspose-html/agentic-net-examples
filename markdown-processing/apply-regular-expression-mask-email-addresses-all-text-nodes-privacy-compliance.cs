// Apply a regular expression to mask email addresses within all text nodes for privacy compliance.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>Contact: john.doe@example.com and jane@domain.org</p></body></html>";

            // Regular expression to match email addresses
            Regex emailRegex = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Load HTML document from string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                // Iterate over all elements
                Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");
                for (int i = 0; i < allElements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = allElements[i];
                    Node child = element.FirstChild;
                    while (child != null)
                    {
                        if (child.NodeType == Aspose.Html.Dom.Node.TEXT_NODE)
                        {
                            Aspose.Html.Dom.Text textNode = (Aspose.Html.Dom.Text)child;
                            string original = textNode.Data;
                            string masked = emailRegex.Replace(original, "[masked email]");
                            if (!original.Equals(masked))
                            {
                                textNode.Data = masked;
                            }
                        }
                        child = child.NextSibling;
                    }
                }

                // Save the modified document as MHTML
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine($"Document saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}