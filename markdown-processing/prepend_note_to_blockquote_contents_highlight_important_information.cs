// Prepend the word “NOTE:” to all blockquote contents to highlight important information.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new empty HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a <style> element and set its CSS content
                Aspose.Html.Dom.Element style = document.CreateElement("style");
                style.TextContent = "body { font-family: Arial; background-color: #f0f0f0; }";

                // Get the <head> element and append the style element
                Aspose.Html.Dom.Element head = System.Linq.Enumerable.First<Aspose.Html.Dom.Element>(document.GetElementsByTagName("head"));
                head.AppendChild(style);

                // Save the document to a file
                string outputPath = "output.html";
                document.Save(outputPath);

                System.Console.WriteLine("HTML document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}