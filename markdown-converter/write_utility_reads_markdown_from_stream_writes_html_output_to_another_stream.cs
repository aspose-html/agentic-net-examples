// Write a utility that reads Markdown from a stream and writes the HTML output to another stream.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdownContent = "# Sample Title\nThis is a **markdown** example.";

            // Create input stream containing the markdown
            using (MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(markdownContent)))
            {
                // Write the markdown stream to a temporary file
                string tempMarkdownPath = Path.GetTempFileName();
                using (FileStream tempFile = File.Create(tempMarkdownPath))
                {
                    inputStream.CopyTo(tempFile);
                }

                // Define a temporary file path for the HTML output
                string tempHtmlPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".html");

                // Convert markdown file to HTML file
                Aspose.Html.Converters.Converter.ConvertMarkdown(tempMarkdownPath, tempHtmlPath);

                // Read the generated HTML file into an output stream
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (FileStream htmlFile = File.OpenRead(tempHtmlPath))
                    {
                        htmlFile.CopyTo(outputStream);
                    }

                    // Reset stream position for further reading if needed
                    outputStream.Position = 0;

                    // Demonstrate the result by writing HTML to console
                    string htmlResult = Encoding.UTF8.GetString(outputStream.ToArray());
                    Console.WriteLine(htmlResult);
                }

                // Clean up temporary files
                File.Delete(tempMarkdownPath);
                File.Delete(tempHtmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}