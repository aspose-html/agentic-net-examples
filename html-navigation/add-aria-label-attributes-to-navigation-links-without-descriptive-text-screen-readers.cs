// Add aria‑label attributes to navigation links lacking descriptive text for screen readers.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><nav><ul><li><a href=\"home.html\"></a></li><li><a href=\"about.html\">About</a></li><li><a href=\"contact.html\"></a></li></ul></nav></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri))
            {
                // Add aria-label to links without descriptive text
                Aspose.Html.Collections.HTMLCollection anchors = document.GetElementsByTagName("a");
                for (int i = 0; i < anchors.Length; i++)
                {
                    Aspose.Html.Dom.Element element = anchors[i] as Aspose.Html.Dom.Element;
                    if (element != null)
                    {
                        Aspose.Html.HTMLAnchorElement anchor = element as Aspose.Html.HTMLAnchorElement;
                        if (anchor != null)
                        {
                            string text = anchor.TextContent != null ? anchor.TextContent.Trim() : string.Empty;
                            if (string.IsNullOrEmpty(text))
                            {
                                string href = anchor.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    anchor.SetAttribute("aria-label", href);
                                }
                            }
                        }
                    }
                }

                // Validate accessibility
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("aria-label");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }

                // Save modified HTML
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}