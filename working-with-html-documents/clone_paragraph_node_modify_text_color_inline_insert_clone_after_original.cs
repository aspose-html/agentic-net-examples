// Clone a paragraph node, modify its text color inline, and insert the clone after the original.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string htmlContent = "<html><body><p>Original paragraph</p></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p")[0];

            Aspose.Html.HTMLElement clonedParagraph = (Aspose.Html.HTMLElement)document.CreateElement("p");
            clonedParagraph.InnerHTML = paragraph.InnerHTML;
            clonedParagraph.Style.Color = "#FF0000";

            Aspose.Html.Dom.Node parent = paragraph.ParentNode;
            parent.AppendChild(clonedParagraph);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}