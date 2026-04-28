// Convert all uppercase tag names to lowercase to ensure HTML5 compliance throughout the document.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            string htmlContent = File.ReadAllText(inputPath);

            string lowerCaseHtml = Regex.Replace(
                htmlContent,
                @"<([A-Z][A-Z0-9]*)\b",
                m => "<" + m.Groups[1].Value.ToLower(),
                RegexOptions.Compiled);

            HTMLDocument document = new HTMLDocument(lowerCaseHtml, "");

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}