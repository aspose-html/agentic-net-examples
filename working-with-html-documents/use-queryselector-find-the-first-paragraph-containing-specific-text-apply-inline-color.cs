// Use QuerySelector to find the first paragraph containing specific text and apply inline color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p><p>Another paragraph</p></body></html>";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element paragraph = document.QuerySelector("p");
            if (paragraph != null)
            {
                paragraph.SetAttribute("style", "color:rgb(255,0,0);");
            }

            document.Save(outputPath);
            Console.WriteLine("Document saved to " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}