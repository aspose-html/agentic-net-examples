// Retrieve the ValidationResult returned by Validate and store it for further processing.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            var webAccessibility = new WebAccessibility();
            var validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            var document = new HTMLDocument("https://example.com");
            ValidationResult validationResult = validator.Validate(document);
            // validationResult can be used for further processing here
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}