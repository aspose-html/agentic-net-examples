// Validate the generated HTML file by reading its contents and checking for expected heading tags.

using System;
using Aspose.Html;

namespace ValidateHtml
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");
                Aspose.Html.HTMLElement body = document.Body;
                string content = body.TextContent;

                bool hasH1 = content.Contains("<h1>") && content.Contains("</h1>");
                bool hasH2 = content.Contains("<h2>") && content.Contains("</h2>");

                Console.WriteLine("Heading validation:");
                Console.WriteLine($"H1 present: {hasH1}");
                Console.WriteLine($"H2 present: {hasH2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}