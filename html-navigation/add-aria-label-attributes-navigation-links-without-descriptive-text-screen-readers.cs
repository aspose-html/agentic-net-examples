// Add aria‑label attributes to navigation links lacking descriptive text for screen readers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with navigation links lacking descriptive text
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<nav>
<ul>
<li><a href='home.html'></a></li>
<li><a href='about.html'>About</a></li>
<li><a href='contact.html'></a></li>
</ul>
</nav>
</body>
</html>";

            // Load HTML from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all anchor elements
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
            for (int i = 0; i < links.Length; i++)
            {
                var anchor = links[i] as Aspose.Html.HTMLAnchorElement;
                if (anchor != null)
                {
                    string text = anchor.TextContent != null ? anchor.TextContent.Trim() : string.Empty;
                    if (string.IsNullOrEmpty(text))
                    {
                        string href = anchor.GetAttribute("href") ?? string.Empty;
                        string ariaLabel = !string.IsNullOrEmpty(href) ? href : "navigation link";
                        anchor.SetAttribute("aria-label", ariaLabel);
                    }
                }
            }

            // Save modified HTML
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine($"Modified HTML saved to: {outputPath}");

            // Run accessibility validation
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
            else
            {
                Console.WriteLine("Accessibility validation passed with no errors.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}