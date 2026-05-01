// Use QuerySelector to select the first unordered list and set its border-color using internal CSS.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Dom.Element ul = document.QuerySelector("ul");
            if (ul != null)
            {
                ul.SetAttribute("style", "border-color:#ff0000;");
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}