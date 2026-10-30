// Fetch HTML content from a list of URLs, validate each page, and save results as XML files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>
            {
                "https://example.com",
                "https://example.org"
            };

            System.IO.Directory.CreateDirectory("ValidationResults");

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    string outputPath = System.IO.Path.Combine("ValidationResults", $"validation_result_{index}.xml");
                    System.IO.File.WriteAllText(outputPath, validationResult.SaveToString());
                }
                index++;
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}