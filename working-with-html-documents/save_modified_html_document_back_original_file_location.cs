// Save the modified HTML document back to the original file location.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><meta charset=\"utf-8\"></head><body>Hello, Aspose.HTML!</body></html>";
            string inputPath = "input.html";
            string outputPathFromFile = "output_from_file.html";
            string outputPathFromStream = "output_from_stream.html";

            // Create a minimal input file
            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // -------------------------------------------------
            // Load document from file path and modify meta tag
            // -------------------------------------------------
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("charset") == "utf-8")
                    {
                        meta.SetAttribute("charset", "iso-8859-1");
                    }
                }

                // Save the modified document
                document.Save(outputPathFromFile);
            }

            // -------------------------------------------------
            // Load document from in‑memory stream and modify meta tag
            // -------------------------------------------------
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, string.Empty))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("charset") == "utf-8")
                    {
                        meta.SetAttribute("charset", "iso-8859-1");
                    }
                }

                // Save the modified document
                document.Save(outputPathFromStream);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}