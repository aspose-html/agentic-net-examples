// Locate an element by ID with GetElementById and apply an inline border-color style.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div id='myDiv'>Hello</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var element = (Aspose.Html.HTMLElement)document.GetElementById("myDiv");
            if (element != null)
            {
                element.Style.BorderColor = "red";
                element.Style.BorderStyle = "solid";
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}