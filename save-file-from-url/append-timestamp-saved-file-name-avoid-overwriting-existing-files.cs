// Append a timestamp to the saved file name to avoid overwriting existing files.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><meta name=\"description\" content=\"old\"></meta></head><body><p>Hello World</p></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }

                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                Directory.CreateDirectory(outputDir);
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                string outputPath = Path.Combine(outputDir, $"result_{timestamp}.html");
                document.Save(outputPath);
                Console.WriteLine($"Saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}