// Append a timestamp to the saved file name to avoid overwriting existing files.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Original description\"></head><body><h1>Hello World</h1></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "Updated description");
                    }
                }

                string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
                System.IO.Directory.CreateDirectory(outputDir);
                string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string outputPath = System.IO.Path.Combine(outputDir, $"result_{timestamp}.html");
                document.Save(outputPath);
                System.Console.WriteLine($"Document saved to: {outputPath}");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}