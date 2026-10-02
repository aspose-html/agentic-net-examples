// Use the validator in a console application to process a list of HTML file paths via command‑line arguments.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] filePaths = args.Length > 0 ? args : new string[] { "sample.html" };
            foreach (string path in filePaths)
            {
                if (!System.IO.File.Exists(path))
                {
                    if (path == "sample.html")
                    {
                        System.IO.File.WriteAllText(path, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
                    }
                    else
                    {
                        System.Console.WriteLine($"File not found: {path}");
                        continue;
                    }
                }

                var document = new Aspose.Html.HTMLDocument(path);
                var validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                var validationResult = validator.Validate(document);
                System.Console.WriteLine($"Validation result for '{path}': Success = {validationResult.Success}");
                System.Console.WriteLine(validationResult.SaveToString());
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}