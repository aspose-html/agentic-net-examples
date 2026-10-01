// Use QuerySelector to select the first unordered list and set its border-color using internal CSS.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string inputPath = "input.html";
            string outputPath = "output.html";
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Modify the first paragraph element
            Aspose.Html.Dom.Element element = document.QuerySelector("p");
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}