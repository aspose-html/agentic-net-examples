// Serialize form input values when saving an HTML document to another HTML file by enabling HTMLSaveOptions.SerializeInputValue.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='myInput'></form></body></html>";
                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, string.Empty))
                {
                    Aspose.Html.Collections.HTMLCollection inputElements = doc.GetElementsByTagName("input");
                    if (inputElements.Length > 0)
                    {
                        Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)inputElements[0];
                        input.Value = "Sample Text";
                    }

                    Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                    options.SerializeInputValue = true;

                    string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "output.html");
                    doc.Save(outputPath, options);
                    System.Console.WriteLine("HTML saved to: " + outputPath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}