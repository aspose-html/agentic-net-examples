// Apply an inline background-color style to a div identified by ID and save the changes.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><head><title>Test</title></head><body><div id='myDiv'>Content</div></body></html>";
                string baseUri = "about:blank";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                Aspose.Html.HTMLElement divElement = (Aspose.Html.HTMLElement)document.QuerySelector("#myDiv");
                if (divElement != null)
                {
                    divElement.Style.BackgroundColor = "rgb(255,0,0)";
                }
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}