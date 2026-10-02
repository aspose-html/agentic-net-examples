// Use QuerySelectorAll to retrieve all <div> elements and apply a blue background style.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><div>First</div><div>Second</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("div");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "blue";
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}