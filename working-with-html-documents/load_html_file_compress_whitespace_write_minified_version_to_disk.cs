// Load an HTML file, compress its whitespace, and write the minified version to disk.

using System;
using System.IO;
using System.Text;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Load HTML from a string, modify meta tags, and save to a file
            string htmlContent = "<html><head><meta name=\"author\" content=\"old\"></head><body><p>Hello World</p></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
                {
                    var metaElements = document.GetElementsByTagName("meta");
                    foreach (Aspose.Html.Dom.Element meta in metaElements)
                    {
                        if (meta.GetAttribute("name") == "author")
                        {
                            meta.SetAttribute("content", "new author");
                        }
                    }

                    string outputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                    document.Save(outputHtmlPath);
                }
            }

            // 2. Convert the saved HTML to a TIFF image with specific options
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlPath);
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");
            Aspose.Html.Converters.Converter.ConvertHTML(htmlDoc, options, imagePath);
            htmlDoc.Dispose();

            // 3. Create a new empty document, add a text node, and save
            using (var doc2 = new Aspose.Html.HTMLDocument())
            {
                var textNode = doc2.CreateTextNode("Sample text");
                doc2.Body.AppendChild(textNode);
                string doc2Path = Path.Combine(Directory.GetCurrentDirectory(), "emptyDoc.html");
                doc2.Save(doc2Path);
            }

            // 4. Create a document directly from an HTML string with a base URL and save
            string htmlString = "<html><body><h1>Title</h1></body></html>";
            var doc3 = new Aspose.Html.HTMLDocument(htmlString, "http://example.com/");
            string doc3Path = Path.Combine(Directory.GetCurrentDirectory(), "stringDoc.html");
            doc3.Save(doc3Path);
            doc3.Dispose();

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}