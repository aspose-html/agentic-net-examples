// Generate descriptive alt text from image filenames for images lacking alt attributes.

using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<img src='images/photo1.jpg'/>" +
                                 "<img src='images/logo.png' alt='Company Logo'/>" +
                                 "<img src='images/banner.gif'/>" +
                                 "</body></html>";

            // Load HTML from string using two-argument constructor
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string src = img.GetAttribute("src");
                        string fileName = Path.GetFileNameWithoutExtension(src ?? string.Empty);
                        string autoAlt = TextInfoToTitleCase(fileName);
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static string TextInfoToTitleCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string spaced = input.Replace('-', ' ').Replace('_', ' ');
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(spaced);
    }
}