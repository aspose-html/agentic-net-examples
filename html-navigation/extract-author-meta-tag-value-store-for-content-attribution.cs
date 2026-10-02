// Extract the value of the author meta tag and store it for content attribution.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><meta name=\"author\" content=\"John Doe\"><title>Sample</title></head><body><p>Hello World</p></body></html>";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
                using (var inputStream = new System.IO.MemoryStream(bytes))
                using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
                {
                    var metaElements = document.GetElementsByTagName("meta");
                    string author = null;
                    foreach (Aspose.Html.Dom.Element meta in metaElements)
                    {
                        if (meta.GetAttribute("name") == "author")
                        {
                            author = meta.GetAttribute("content");
                            break;
                        }
                    }
                    System.Console.WriteLine("Author: " + (author ?? "Not found"));
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}