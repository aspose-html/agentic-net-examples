// Load HTML content from a string, modify image src attributes, and output the updated markup.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src=\"old.png\" alt=\"test\"/></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            var images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.HTMLElement img in images)
            {
                img.SetAttribute("src", "new.png");
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Updated HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}