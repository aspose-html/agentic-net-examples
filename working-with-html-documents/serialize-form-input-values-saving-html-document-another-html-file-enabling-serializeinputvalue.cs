// Serialize form input values when saving an HTML document to another HTML file by enabling HTMLSaveOptions.SerializeInputValue.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='sample' /></form></body></html>";
                string baseUri = "about:blank";

                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
                {
                    Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");
                    if (inputElements.Length > 0)
                    {
                        Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                        input.Value = "Text";
                    }

                    Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                    options.SerializeInputValue = true;

                    string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
                    doc.Save(outputPath, options);

                    System.Console.WriteLine("Document saved to: " + outputPath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}