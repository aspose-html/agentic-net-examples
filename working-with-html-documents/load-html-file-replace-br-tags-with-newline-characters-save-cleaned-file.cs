// Load an HTML file, replace all <br> tags with newline characters, and save the cleaned file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>Hello<br>World<br/>Again<br />End</body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <body> element
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("body"));

            // Replace <br> tags with newline characters
            string htmlContent = body.InnerHTML;
            htmlContent = htmlContent.Replace("<br>", "\n")
                                     .Replace("<br/>", "\n")
                                     .Replace("<br />", "\n");
            body.InnerHTML = htmlContent;

            // Save the cleaned HTML to a new file
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}