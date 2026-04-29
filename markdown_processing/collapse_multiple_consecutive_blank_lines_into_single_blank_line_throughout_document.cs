// Collapse multiple consecutive blank lines into a single blank line throughout the document.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            string html = File.ReadAllText(inputPath);
            string collapsed = Regex.Replace(html, @"(\r?\n){2,}", "\n\n");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(collapsed, "");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}