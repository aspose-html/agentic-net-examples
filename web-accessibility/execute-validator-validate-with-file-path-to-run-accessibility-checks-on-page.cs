// Execute validator.Validate with the file path to run accessibility checks on the page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    System.Console.WriteLine("Accessibility validation succeeded.");
                }
                else
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                System.Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}