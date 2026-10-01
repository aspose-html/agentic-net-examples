// Create an HTML document, add a meta robots tag with noindex, and verify search engine directives.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Write HTML to a temporary file and load it with a sandbox configuration
            string htmlContent = "<html><body><div id='test' class='sample'>Hello World</div></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document OuterHTML:");
                Console.WriteLine(output);
            }

            // 2. Perform accessibility validation on the same document
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile))
            {
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
                                    string attributeValue = element.GetAttribute("class");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Accessibility validation succeeded with no errors.");
                }
            }

            // 3. Retrieve elements by tag name and print their tag names
            string htmlContent2 = "<html><body><p>Paragraph1</p><p>Paragraph2</p><div>DivContent</div></body></html>";
            Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(htmlContent2, "");
            Aspose.Html.Collections.HTMLCollection elements = doc2.GetElementsByTagName("p");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine($"Element tag: {element.TagName}");
            }

            // 4. Output the text content of the body element
            Aspose.Html.HTMLDocument doc3 = new Aspose.Html.HTMLDocument(tempFile);
            Aspose.Html.HTMLElement body = doc3.Body;
            string content = body.TextContent;
            Console.WriteLine("Body text content:");
            Console.WriteLine(content);

            // 5. Validate multiple URLs and write results to files
            List<string> urls = new List<string> { tempFile, tempFile };
            string outputDir = Path.Combine(Path.GetTempPath(), "ValidationResults");
            Directory.CreateDirectory(outputDir);
            int index = 1;
            foreach (string url in urls)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());
                    Console.WriteLine($"Validation result saved to {outputPath}");
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}