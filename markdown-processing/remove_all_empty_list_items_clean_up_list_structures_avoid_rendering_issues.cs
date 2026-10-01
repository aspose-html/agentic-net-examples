// Remove all empty list items to clean up list structures and avoid rendering issues.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Create a sample HTML file with empty list items
                System.IO.File.WriteAllText(inputPath,
                    "<html><body><ul><li>Item 1</li><li>   </li><li></li><li>Item 2</li></ul></body></html>");

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                // Get all <li> elements
                Aspose.Html.Collections.HTMLCollection liCollection = document.GetElementsByTagName("li");

                // Remove empty <li> elements (iterate backwards to avoid index issues)
                for (int i = liCollection.Length - 1; i >= 0; i--)
                {
                    Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)liCollection[i];
                    if (string.IsNullOrWhiteSpace(li.InnerHTML))
                    {
                        li.ParentNode.RemoveChild(li);
                    }
                }

                // Save the cleaned HTML document
                document.Save(outputPath);
                System.Console.WriteLine("Empty list items removed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}