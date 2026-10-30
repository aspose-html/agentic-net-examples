// Create a <style> element with CSS rules, append it to the HTML head, and generate the final document.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a <style> element and add CSS rules
                Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
                string css = "body { background-color: #f0f0f0; } p { color: red; }";
                Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
                styleElement.AppendChild(textNode);

                // Get the <head> element; create it if it does not exist
                Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
                if (head == null)
                {
                    head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                // Append the <style> element to the <head>
                head.AppendChild(styleElement);

                // Save the final document
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