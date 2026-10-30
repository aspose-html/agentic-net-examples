// Identify and list all elements with role attributes for accessibility compliance review.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div role=\"banner\">Header</div><nav role=\"navigation\">Menu</nav><section>Content</section></body></html>";

            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, html);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile))
            {
                var allElements = document.GetElementsByTagName("*");
                foreach (Aspose.Html.Dom.Element element in allElements)
                {
                    string role = element.GetAttribute("role");
                    if (!string.IsNullOrEmpty(role))
                    {
                        Aspose.Html.HTMLElement htmlElement = (Aspose.Html.HTMLElement)element;
                        Console.WriteLine($"Tag: {htmlElement.TagName}, Role: {role}");
                    }
                }
            }

            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}