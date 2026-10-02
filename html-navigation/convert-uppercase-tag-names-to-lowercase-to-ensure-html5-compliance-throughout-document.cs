// Convert all uppercase tag names to lowercase to ensure HTML5 compliance throughout the document.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<HTML><BODY><DIV>Test</DIV></BODY></HTML>";
            // Load HTML content using Aspose.Html
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Convert uppercase tag names to lowercase
            string lowerHtml = Regex.Replace(htmlContent, @"<(/?)([A-Z]+)(\s|>)", m =>
                $"<{m.Groups[1].Value}{m.Groups[2].Value.ToLower()}{m.Groups[3].Value}");

            Console.WriteLine("Original HTML:");
            Console.WriteLine(htmlContent);
            Console.WriteLine();
            Console.WriteLine("HTML with lowercase tags:");
            Console.WriteLine(lowerHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}