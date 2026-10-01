// Remove all deprecated <marquee> tags and replace them with CSS animations for modern effect.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection marquees = document.GetElementsByTagName("marquee");
                foreach (Aspose.Html.Dom.Element marquee in marquees)
                {
                    marquee.ParentNode.RemoveChild(marquee);
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Deprecated <marquee> tags removed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}