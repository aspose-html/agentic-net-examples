// Load an HTML file, replace all <br> tags with newline characters, and save the cleaned file.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>Hello<br>World<br/>!<br />End</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <body> element
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Replace <br> tags with newline characters
            string html = body.InnerHTML;
            html = html.Replace("<br>", "\n")
                       .Replace("<br/>", "\n")
                       .Replace("<br />", "\n");
            body.InnerHTML = html;

            // Save the cleaned HTML document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}